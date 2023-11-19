using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(RoleVM roleView)
		{
			IdentityResult identityResult = await _roleManager.CreateAsync(new AppRole() { Name = roleView.Name });
			if (identityResult.Succeeded)
			{
				return RedirectToAction(""); //Admin sayfasına gidecek
			}
			return View();
		}
	}
}
