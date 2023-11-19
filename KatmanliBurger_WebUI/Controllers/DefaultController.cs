using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.ParameterServices;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	
	public class DefaultController : Controller
    {

		private readonly UserManager<AppUser> _userManager;
		private readonly IParameterService _parameterService;

		public DefaultController(UserManager<AppUser> userManager, IParameterService parameterService)
		{
			_userManager = userManager;
			_parameterService = parameterService;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
				var errorMessages = _parameterService.GetAll().ToList();
				ErrorMessageProvider.LoadErrorMessages(errorMessages);
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
			catch (Exception)
			{

				return RedirectToAction("ErrorPage", "Error");
			}
			
		}
	}
}
