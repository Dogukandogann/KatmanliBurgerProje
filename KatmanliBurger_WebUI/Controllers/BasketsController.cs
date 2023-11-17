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
using KatmanliBurger_WebUI.Helpers;
using KatmanliBurger_WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
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
			var model = new BasketListViewModel
			{
				Basket = _basketSessionHelper.GetBasket("basket")
			};
			return View(model);
		}

		public IActionResult AddToBasket(int byProductId = default, int menuId = default, int burgerId = default)
		{
			//Sepetten ürünü çek idye göre
			ByProduct product = _byProductManager.GetById(byProductId);
			Menu menu = _menuManager.GetById(menuId);
			Burger burger = _burgerManager.GetById(burgerId);

			var basket = _basketSessionHelper.GetBasket("basket");
			_basketManager.AddToBasket(basket, product, menu, burger);
			_basketSessionHelper.SetBasket("basket", basket);

			return RedirectToAction("Index", "Baskets");
		}

		public IActionResult RemoveFromBasket(int byProductId = default, int menuId = default, int burgerId = default)
		{
			//Sepetten ürünü çek idye göre
			//ByProduct product = _byProductManager.GetById(byProductId);
			//Menu menu = _menuManager.GetById(menuId);
			//Burger burger = _burgerManager.GetById(burgerId);

			var basket = _basketSessionHelper.GetBasket("basket");
			_basketManager.RemoveFromBasket(basket, byProductId, menuId, burgerId);
			_basketSessionHelper.SetBasket("basket", basket);

			return RedirectToAction("Index");
		}

		public IActionResult AddToOrder()
		{
			OrderListViewModel model = new OrderListViewModel();
			Order newOrder = new Order() { UserId = "e768f722-5d9f-40dd-a8ed-a7e9a19d9238" };
			_orderManager.Create(newOrder);


			



			var order = _orderManager.GetById(newOrder.Id);

			Basket basket = _basketSessionHelper.GetBasket("basket");

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
			var order = _orderManager.GetById(model.OrderNo);
			AppUser user = await _userManager.FindByIdAsync(order.UserId);
			model.AppUser = user;
			var orders=_orderManager.GetAll().Where(x=>x.UserId==model.AppUser.Id).ToList();
			model.Orders= _orderManager.OrderWithDetailList(orders);
			return View(model);
		}
	}
}
