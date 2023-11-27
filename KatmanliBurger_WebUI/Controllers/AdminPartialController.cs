using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.ParameterServices;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
    public class AdminPartialController : Controller
    {
        private readonly IParameterService _parameterService;

        public AdminPartialController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        public IActionResult Index()
        {
          
            return View(_parameterService.GetAll());
        }
        public IActionResult Details(int id) 
        {
            _parameterService.GetById(id);
            return View(_parameterService.GetById(id));
        }
        [HttpPost]
		public IActionResult Details(int id,ParameterDetail model)
		{
			
            var detail = _parameterService.GetById(id);
            detail.Code = model.Code;
            detail.Description = model.Description;
            _parameterService.Update(detail);

            return RedirectToAction("Index");
		}
	}
}
