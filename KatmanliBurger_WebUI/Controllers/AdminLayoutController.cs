using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
