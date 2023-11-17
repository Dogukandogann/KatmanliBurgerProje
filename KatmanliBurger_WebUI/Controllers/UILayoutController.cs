using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
