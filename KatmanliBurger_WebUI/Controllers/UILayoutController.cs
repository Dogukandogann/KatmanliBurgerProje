using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
