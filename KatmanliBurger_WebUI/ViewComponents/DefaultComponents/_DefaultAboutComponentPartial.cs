using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.CategoryServices;
using KatmanliBurger_SERVICE.Services.MenuServices;
using KatmanliBurger_WebUI.DTOs.MenuProductViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
