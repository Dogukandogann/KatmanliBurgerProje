using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.ViewComponents.LayoutComponent
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
