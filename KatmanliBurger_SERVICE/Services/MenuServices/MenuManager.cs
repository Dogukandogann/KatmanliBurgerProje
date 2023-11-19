using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using KatmanliBurger_SERVICE.Services.BurgerGarnitureMappingServices;
using KatmanliBurger_SERVICE.Services.BurgerMenuMappingServices;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.DTOs;
using KatmanliBurger_SERVICE.Services.GarnitureServices;
using KatmanliBurger_SERVICE.Services.MenuByProductMappingServices;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBurger_SERVICE.Services.MenuServices
{
	public class MenuManager : IMenuService
	{
		private readonly IMenuDal _menuDal;
		private readonly IBurgerDal _burgerDal;
		private readonly IBurgerMenuMappingDal _burgerMenuMappingDal;
		private readonly IBurgerGarnitureMappingDal _burgerGarnitureMappingDal;
		private readonly IGarnitureDal _garnitureDal;
		private readonly IByProductDal _byProductDal;
		private readonly IMenuByProductMappingDal _menuProductMappingDal;

		public MenuManager(IMenuDal menuDal, IBurgerDal burgerDal, IBurgerMenuMappingDal burgerMenuMappingDal, IBurgerGarnitureMappingDal burgerGarnitureMappingDal, IGarnitureDal garnitureDal, IByProductDal byProductDal, IMenuByProductMappingDal menuProductMappingDal)
		{
			_menuDal = menuDal;
			_burgerDal = burgerDal;
			_burgerMenuMappingDal = burgerMenuMappingDal;
			_burgerGarnitureMappingDal = burgerGarnitureMappingDal;
			_garnitureDal = garnitureDal;
			_byProductDal = byProductDal;
			_menuProductMappingDal = menuProductMappingDal;
		}

		public void Create(Menu entity)
		{
			_menuDal.Create(entity);
		}

		public IEnumerable<Menu> GetAll()
		{
			return _menuDal.GetAll();
		}

		public Menu GetById(int id)
		{
			return _menuDal.GetById(id);
		}

		public void Update(Menu entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_menuDal.Update(entity);
		}

		public void UpdateStatus(int id)
		{
			var menu = _menuDal.GetById(id);
			menu.Status = menu.Status == Status.Active ? Status.Passive : Status.Active;
			menu.UpdatedDate = DateTime.Now;
			_menuDal.Update(menu);
		}


		public MenuDto GetMenu(int menuId)
		{
			var selectedMenu = _menuDal.GetById(menuId);
			var burgerMapping = _burgerMenuMappingDal.GetByMenuId(menuId);
			var burgers = _burgerDal.GetByIdList(burgerMapping.Select(x => x.BurgerId).ToList()).ToList();
			var garnitureMapping = _burgerGarnitureMappingDal.GetByBurgerIds(burgers.Select(x => x.Id).ToList()).ToList();
			var garnitures = _garnitureDal.GetByIdList(garnitureMapping.Select(x => x.GarnitureId).ToList()).ToList();
			var productMapping = _menuProductMappingDal.GetByMenuId(menuId).ToList();
			var products = _byProductDal.GetByIdList(productMapping.Select(x => x.ByProductId).ToList()).ToList();
			var allGarnitures = _garnitureDal.GetAll().ToList();
			var allProducts = _byProductDal.GetAll().ToList();
			var allBurgers = _burgerDal.GetAll().ToList();

			MenuDto menuDto = new MenuDto()
			{
				Menu = selectedMenu,
				Burgers = burgers,
				BurgerGarnitureMappings = garnitureMapping,
				Byproducts = products,
				MenuByProductMappings = productMapping,
				Garnitures = garnitures,
				AllGarnitures = allGarnitures,
				AllByproducts = allProducts,
				AllBurgers = allBurgers,
				Size = new List<CustomSelectItem>
				{
					new CustomSelectItem { Text=Size.Small.ToString(), Value="0"},
					new CustomSelectItem { Text=Size.Medium.ToString(), Value="1"},
					new CustomSelectItem { Text=Size.Large.ToString(), Value="2"}
				}
			};

			return menuDto;
		}
		public void UpdateMenu(MenuDto dto, int menuId, int[] selectedburgers, int[] selectedcitilezzetler, int[] selectedicecekler, int[] selectedtatlilar)
		{
			var selectedMenu = _menuDal.GetById(menuId);//menü getir
			dto.Menu.Id = menuId;
			selectedMenu = dto.Menu;
			_menuDal.Update(selectedMenu);
			var burgerMapping = _burgerMenuMappingDal.GetByMenuId(menuId);//menü burger ara tablosunu getir
			int[] allProducts = selectedcitilezzetler
										.Concat(selectedicecekler)
										.Concat(selectedtatlilar)
										.ToArray();
			var productMapping = _menuProductMappingDal.GetByMenuId(menuId);
			foreach (var item in selectedburgers)
			{
				if (!burgerMapping.Any(x => x.BurgerId.Equals(item)))
				{
					BurgerMenuMapping burgerMenuMapping = new BurgerMenuMapping()
					{
						MenuId = menuId,
						BurgerId = item
					};
					_burgerMenuMappingDal.Create(burgerMenuMapping);
				}

			}
			foreach (var item in burgerMapping)
			{
				if (!selectedburgers.Contains(item.BurgerId))
				{
					_burgerMenuMappingDal.Delete(_burgerMenuMappingDal.GetAll().Where(x => x.Id == item.Id).ToList());
				}
			}

			foreach (var item in allProducts)
			{
				if (!productMapping.Any(x => x.ByProductId.Equals(item)))
				{
					MenuByProductMapping productMenuMapping = new MenuByProductMapping()
					{
						MenuId = menuId,
						ByProductId = item
					};
					_menuProductMappingDal.Create(productMenuMapping);
				}

			}
			foreach (var item in productMapping)
			{
				if (!allProducts.Contains(item.ByProductId))
				{
					_menuProductMappingDal.Delete(_menuProductMappingDal.GetAll().Where(x => x.Id == item.Id).ToList());
				}
			}

		}


	}
}
