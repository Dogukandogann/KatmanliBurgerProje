using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.CustomerMessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CustomerMessageController : Controller
    {
        private readonly ICustomerMessageService _customerMessage;

        public CustomerMessageController(ICustomerMessageService customerMessage)
        {
            _customerMessage = customerMessage;
        }

        public IActionResult Index()
        {
            return View(_customerMessage.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _customerMessage.UpdateStatus(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(CustomerMessage customerMessage)
        {
            _customerMessage.Create(customerMessage);
			return RedirectToAction("Index");
		}
    }
}
