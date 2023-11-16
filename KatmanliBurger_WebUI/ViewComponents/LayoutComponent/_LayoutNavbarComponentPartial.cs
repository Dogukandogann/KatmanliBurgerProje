using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
