using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
