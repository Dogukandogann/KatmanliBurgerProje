using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.BurgerGarnitureMappingServices;
using KatmanliBurger_SERVICE.Services.BurgerMenuMappingServices;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.DTOs;
using KatmanliBurger_SERVICE.Services.GarnitureServices;
using KatmanliBurger_SERVICE.Services.MenuByProductMappingServices;
using KatmanliBurger_SERVICE.Services.MenuServices;
using KatmanliBurger_UI.DTOs.MenuViewDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class MenuController : Controller
    {
		private readonly IBurgerService _burgerService;
		private readonly IBurgerMenuMappingService _burgerMenuMappingService;
		private readonly IGarnitureService _garnitureService;
		private readonly IBurgerGarnitureMappingService _burgerGarniturMappingService;
		private readonly IByProductService _byProductService;
		private readonly IMenuByProductMappingService _menuByProductMappingService;
		private readonly IMenuService _menuService;

		public MenuController(IBurgerService burgerService, IBurgerMenuMappingService burgerMenuMappingService, IGarnitureService garnitureService, IBurgerGarnitureMappingService burgerGarniturMappingService, IByProductService byProductService, IMenuByProductMappingService menuByProductMappingService, IMenuService menuService)
		{
			_burgerService = burgerService;
			_burgerMenuMappingService = burgerMenuMappingService;
			_garnitureService = garnitureService;
			_burgerGarniturMappingService = burgerGarniturMappingService;
			_byProductService = byProductService;
			_menuByProductMappingService = menuByProductMappingService;
			_menuService = menuService;
		}

		public IActionResult Index()
		{
			var menus = _menuService.GetAll();
			return View(menus);
		}
		public IActionResult Create()
		{

			var burgers = _burgerService.GetAll();
			var products = _byProductService.GetAll();

			var tatlilar = products.Where(x => x.CategoryId == 3).ToList();

			var citirlar = products.Where(x => x.CategoryId == 2).ToList();

			var icecekler = products.Where(x => x.CategoryId == 1).ToList();

			MenuCreateDto model = new();
			model.Burgers = (List<Burger>)burgers;
			model.Tatlilar = (List<ByProduct>)tatlilar;
			model.CıtırLezzetler = (List<ByProduct>)citirlar;
			model.Icecekler = (List<ByProduct>)icecekler;
			return View(model);
		}
		[HttpPost]
		public IActionResult Create(MenuCreateDto model, int[] selectedburgers, int[] selectedcitilezzetler, int[] selectedicecekler, int[] selectedtatlilar)
		{
			Menu menu = new Menu();
			menu.Description = model.Description;
			menu.Price = model.Price;
			menu.Image = model.Image;
			menu.Name = model.Name;

			_menuService.Create(menu);

			if (selectedburgers != null && selectedburgers.Any())
			{

				menu.BurgerMenus = new List<BurgerMenuMapping>();
				foreach (var burgerId in selectedburgers)
				{
					menu.BurgerMenus.Add(new BurgerMenuMapping() { BurgerId = burgerId, MenuId = menu.Id });

				}
				_burgerMenuMappingService.Create(menu.BurgerMenus);
			}


			if (selectedcitilezzetler != null && selectedcitilezzetler.Any())
			{

				menu.MenuByProducts = new List<MenuByProductMapping>();
				foreach (var item in selectedcitilezzetler)
				{
					menu.MenuByProducts.Add(new MenuByProductMapping() { ByProductId = item, MenuId = menu.Id });
				}
				_menuByProductMappingService.Create(menu.MenuByProducts);

			}
			if (selectedicecekler != null && selectedicecekler.Any())
			{
				menu.MenuByProducts = new List<MenuByProductMapping>();
				foreach (var item in selectedicecekler)
				{
					menu.MenuByProducts.Add(new MenuByProductMapping() { ByProductId = item, MenuId = menu.Id });
				}
				_menuByProductMappingService.Create(menu.MenuByProducts);
			}

			if (selectedtatlilar != null && selectedtatlilar.Any())
			{
				menu.MenuByProducts = new List<MenuByProductMapping>();
				foreach (var item in selectedtatlilar)
				{
					menu.MenuByProducts.Add(new MenuByProductMapping() { ByProductId = item, MenuId = menu.Id });
				}
				_menuByProductMappingService.Create(menu.MenuByProducts);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var model = _menuService.GetMenu(id);

			return View(model);
		}
		[HttpPost]
		public IActionResult Update(MenuDto dto, int id, int[] selectedburgers, int[] selectedcitilezzetler, int[] selectedicecekler, int[] selectedtatlilar)
		{
			_menuService.UpdateMenu(dto, id, selectedburgers, selectedcitilezzetler, selectedicecekler, selectedtatlilar);

			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{

			_menuService.UpdateStatus(id);
			return RedirectToAction("Index");

		}

	}
}
