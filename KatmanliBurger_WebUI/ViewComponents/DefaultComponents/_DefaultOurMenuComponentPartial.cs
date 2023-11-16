using KatmanliBurger_Service.Service.BurgerService;
using KatmanliBurger_Service.Service.ByProductService;
using KatmanliBurger_Service.Service.CategoryService;
using KatmanliBurger_Service.Service.MenuService;
using KatmanliBurger_UI.DTOs.MenuProductViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        private readonly IBurgerService _burgerManager;
        private readonly IMenuService _menuManager;
        private readonly IByProductService _byProductManager;
        private readonly ICategoryService _categoryManager;

        public _DefaultOurMenuComponentPartial(IBurgerService burgerManager, IMenuService menuManager, IByProductService byProductManager, ICategoryService categoryManager)
        {
            _burgerManager = burgerManager;
            _menuManager = menuManager;
            _byProductManager = byProductManager;
            _categoryManager = categoryManager;
        }

        public IViewComponentResult Invoke()
        {

            MenuProductViewDto model = new MenuProductViewDto();
            model.Burgers = _burgerManager.GetAll();
            model.Menus = _menuManager.GetAll();
            model.ByProducts = _byProductManager.GetAll();
            model.Categories = _categoryManager.GetAll();
            return View(model);
           
        }
    }
}
