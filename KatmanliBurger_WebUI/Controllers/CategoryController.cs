using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.CategoryServices;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
	{
		ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var categories = _categoryService.GetAll();
			return View(categories);
		}
        public IActionResult CreateByCategory()
        {
            try
            {
				Category model = new();
				return View(model);
			}
            catch (Exception)
            {
				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "Category");
			}
           
        }
		[HttpPost]
        public IActionResult CreateByCategory(Category model)
        {
            try
            {
				_categoryService.Create(model);
				return RedirectToAction("Index");
			}
            catch (Exception)
            {
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Kayit_Basarisiz");
				return RedirectToAction("Index", "Category");
			}
			
			
        }
        public IActionResult Edit(int id)
        {
            try
            {
				var category = _categoryService.GetById(id);

				return View(category);
			}
            catch (Exception)
            {
				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "Category");
			}
            
        }
        [HttpPost]
        public IActionResult Edit(Category model, int id)
        {
			try
			{
				var category = _categoryService.GetById(id);
				category.Name = model.Name;

				_categoryService.Update(model);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Guncelleme_Basarisiz");
				return RedirectToAction("Index", "Category");
			}
           
        }
        public IActionResult Delete(int id)
        {
			try
			{
				_categoryService.UpdateStatus(id);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Silme_Basarisiz");
				return RedirectToAction("Index", "Category");
			}
            

        }
    }
}
