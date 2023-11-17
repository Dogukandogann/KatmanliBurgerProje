using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IPasswordHasher<AppUser> _passwordHasher;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_passwordHasher = passwordHasher;
		}

		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserVM vm)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = await _userManager.FindByEmailAsync(vm.Email);
				if (appUser != null)
				{
					await _signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, vm.Password, false, false);
					if (signInResult.Succeeded)
					{
						return RedirectToAction("Index", "Default"); //Gideceği yer..
					}
					ModelState.AddModelError("", "Wrong credantion information");
				}
			}
			return View(vm);

		}
	}
}
