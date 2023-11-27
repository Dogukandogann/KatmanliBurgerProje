using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.CustomerMessageServices;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	
	public class CustomerMessageController : Controller
    {
        private readonly ICustomerMessageService _customerMessage;

        public CustomerMessageController(ICustomerMessageService customerMessage)
        {
            _customerMessage = customerMessage;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_customerMessage.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
				_customerMessage.UpdateStatus(id);
				return RedirectToAction("Index");
			}
            catch (Exception)
            {
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Silme_Basarisiz");
				return RedirectToAction("Index", "CustomerMessage");
			}
            
        }

        [HttpPost]
        public IActionResult Create(CustomerMessage customerMessage)
        {

            
            try
            {
				_customerMessage.Create(customerMessage);
				return RedirectToAction("Index","Default");
			}
            catch (Exception)
            {
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Kayit_Basarisiz");
				return RedirectToAction("Index", "Default");
			}
           
		}
    }
}
