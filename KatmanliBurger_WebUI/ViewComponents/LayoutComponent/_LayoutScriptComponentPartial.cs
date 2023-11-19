using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.ViewComponents.LayoutComponent
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
