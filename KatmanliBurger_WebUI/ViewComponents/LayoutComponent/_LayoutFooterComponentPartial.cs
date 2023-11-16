using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
