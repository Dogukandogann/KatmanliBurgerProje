using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
