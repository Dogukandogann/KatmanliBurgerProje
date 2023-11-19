using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_SERVICE.Services.BasketServices;
using KatmanliBurger_SERVICE.Services.BurgerOrderMappingServices;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.MenuOrderMappingServices;
using KatmanliBurger_SERVICE.Services.MenuServices;
using KatmanliBurger_SERVICE.Services.OrderByProductMappingServices;
using KatmanliBurger_SERVICE.Services.OrderServices;
using KatmanliBurger_UI.Helpers;
using KatmanliBurger_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace KatmanliBurger_UI.Controllers
{
	public class BasketsController : Controller
	{
		private IBasketService _basketManager;
		private IBasketSessionHelper _basketSessionHelper;
		private IByProductService _byProductManager;
		private IMenuService _menuManager;
		private IBurgerService _burgerManager;
		private IOrderService _orderManager;
		private IBurgerOrderMappingService _burgerOrderMappingManager;
		private IMenuOrderMappingService _menuOrderMappingManager;
		private IOrderByProductMappingService _orderByProductMappingManager;
		private readonly UserManager<AppUser> _userManager;

		public BasketsController(IBasketService basketManager, IBasketSessionHelper basketSessionHelper, IByProductService byProductManager, IMenuService menuManager, IBurgerService burgerManager, IOrderService orderService, IBurgerOrderMappingService burgerOrderMappingManager, IMenuOrderMappingService menuOrderMappingManager, IOrderByProductMappingService orderByProductMappingManager, UserManager<AppUser> userManager)
		{
			_basketManager = basketManager;
			_basketSessionHelper = basketSessionHelper;
			_byProductManager = byProductManager;
			_menuManager = menuManager;
			_burgerManager = burgerManager;
			_orderManager = orderService;
			_burgerOrderMappingManager = burgerOrderMappingManager;
			_menuOrderMappingManager = menuOrderMappingManager;
			_orderByProductMappingManager = orderByProductMappingManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				TempData["message"] = " Logout";
				TempData["adress"] = "/Default/Logout";
			}
			else
			{
				TempData["message"] = " Login";
				TempData["adress"] = "/Login/Index";
			}

			var model = new BasketListViewModel
			{
				Basket = _basketSessionHelper.GetBasket("basket")
			};
			
			return View(model);
		}

		public IActionResult AddToBasket(int byProductId = default, int menuId = default, int burgerId = default, int menuQuantity = default, string allMenuDescription = default, float menuPrice = default)
		{
			ByProduct product = _byProductManager.GetById(byProductId);
			Menu menu = _menuManager.GetById(menuId);
			Burger burger = _burgerManager.GetById(burgerId);

			var basket = _basketSessionHelper.GetBasket("basket");

			_basketManager.AddToBasket(basket, product, menu, burger);

			if (menuId != default && (menuQuantity != default || allMenuDescription != default || menuPrice!=default))
			{
				var basketLine = basket.BasketLines.Where(x => x.Menu.Id == menuId).FirstOrDefault();

				if (menuQuantity != 0)
				{
					basketLine.MenuQuantity = menuQuantity;
				}

				if (allMenuDescription != default)
				{
					basketLine.Description = RefactorDescription(allMenuDescription);
				}

                if (menuPrice!=default)
                {
					basketLine.Menu.Price = (decimal)menuPrice;
                }
            }

			_basketSessionHelper.SetBasket("basket", basket);

			return RedirectToAction("Index", "Baskets");
		}

		private string RefactorDescription(string allMenuDescription)
		{
			string[] lines = allMenuDescription.Split('\n', StringSplitOptions.RemoveEmptyEntries);
			StringBuilder modifiedDescription = new StringBuilder();

			foreach (string line in lines)
			{
				string formattedLine = line.EndsWith('\n') ? line : $"{line}\n";
				string[] parts = formattedLine.Split(':');

				if (parts[0].Contains('-'))
				{
					int burgerId = int.Parse(parts[0].Split('-')[0].Trim());
					string burgerName = _burgerManager.GetById(burgerId).Name;
					modifiedDescription.AppendLine($"{burgerName}-{parts[0].Split('-')[1]}:{parts[1]}");
				}
				else
				{
					modifiedDescription.AppendLine(formattedLine);
				}
			}

			return modifiedDescription.ToString();
		}
		public IActionResult RemoveFromBasket(int byProductId = default, int menuId = default, int burgerId = default, int removeAll = default)
		{
			var basket = _basketSessionHelper.GetBasket("basket");
			_basketManager.RemoveFromBasket(basket, byProductId, menuId, burgerId, removeAll);
			_basketSessionHelper.SetBasket("basket", basket);

			return RedirectToAction("Index");
		}

		public IActionResult AddToOrder()
		{
			Basket basket = _basketSessionHelper.GetBasket("basket");
			OrderListViewModel model = new OrderListViewModel();
			Order newOrder = new Order() { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
			_orderManager.Create(newOrder);

			var order = _orderManager.GetById(newOrder.Id);

			foreach (var item in basket.BasketLines)
			{
				if (item.Burger is not null)
				{
					order.BurgerOrders = new List<BurgerOrderMapping>()
					{
					   new BurgerOrderMapping
					   {
						BurgerId=item.Burger.Id,
						OrderId=order.Id
					   }
					};
					order.TotalPrice += item.BurgerQuantity * item.Burger.Price * 1.1m;
					_burgerOrderMappingManager.Create(order.BurgerOrders);

				}
				if (item.Menu is not null)
				{
					order.MenuOrders = new List<MenuOrderMapping>()
					{
						new MenuOrderMapping
						{
							MenuId=item.Menu.Id,
							OrderId=order.Id
						}
					};
					order.TotalPrice += item.MenuQuantity * item.Menu.Price * 1.1m;
					_menuOrderMappingManager.Create(order.MenuOrders);
				}

				if (item.ByProduct is not null)
				{
					order.OrderByProducts = new List<OrderByProductMapping>
					{
						new OrderByProductMapping
						{
							ByProductId=item.ByProduct.Id,
							OrderId = order.Id
						}
					};
					order.TotalPrice += item.ByProductQuantity * item.ByProduct.Price * 1.1m;
					_orderByProductMappingManager.Create(order.OrderByProducts);
				}

				order.Description = item.Description;
			}
			
			_orderManager.Update(order);

			model.OrderNo = order.Id;
			model.TotalPrice = order.TotalPrice;
			TempData["info"] = "Kapat";
			return RedirectToAction("CompletedOrderList", model);
		}

		public async Task<IActionResult> CompletedOrderList(OrderListViewModel model)
		{
            _basketSessionHelper.Clear();
			AppUser user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user!=null)
            {
				model.AppUser = user;
				var orders = _orderManager.GetAll().Where(x => x.UserId == model.AppUser.Id).ToList();
				model.Orders = _orderManager.OrderWithDetailList(orders);
				return View(model);
			}
            else
            {
				return RedirectToAction("Index", "Login");
            }

        }
	}
}
