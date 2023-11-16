using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
