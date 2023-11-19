using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	public class DefaultController : Controller
    {

		private readonly UserManager<AppUser> _userManager;

		public DefaultController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				AppUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
				TempData["message"] = " Logout";
				TempData["adress"] = "/Default/Logout";
				if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
				{
					TempData["admin"] = "/Category/Index";
				}
			}
			else
			{
				TempData["message"] = " Login";
				TempData["adress"] = "/Login/Index";
			}
			return View();
		}
	}
}
