using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
	public class MenuUIController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
