using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _userRole;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IPasswordHasher<AppUser> _passwordHasher;

		public RegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> userRole, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
		{
			_userManager = userManager;
			_userRole = userRole;
			_signInManager = signInManager;
			_passwordHasher = passwordHasher;
		}

		public IActionResult Register()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterVM model)
		{
			if (ModelState.IsValid)
			{
				if (model.ConfirmPassword == model.Password)
				{
					AppUser appUser = new AppUser()
					{
						Email = model.Email,
						FirstName = model.FirstName,
						LastName = model.LastName,
						Address = model.Adress,
						UserName = model.Email,

					};

					IdentityResult identityResult = await _userManager.CreateAsync(appUser, model.Password);
					if (identityResult.Succeeded)
					{
						//string userId = appUser.Id;
						//string userRoleId = _userRole.Roles.FirstOrDefault(x => x.Name.Equals("user")).ToString();
						await _userManager.AddToRoleAsync(appUser, "User");
						return RedirectToAction("Index", "Login");
					}
					else
					{
						foreach (var error in identityResult.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
					}
				}
				else
				{
					ModelState.AddModelError("", "Şifreler uyuşmuyor.");
					return View();
				}

			}
			return View(model);
		}
	}
}
