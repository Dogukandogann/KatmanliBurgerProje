using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult ErrorPage()
		{
			return View();
		}
	}
}
