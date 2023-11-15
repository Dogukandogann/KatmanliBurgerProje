using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
