using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
