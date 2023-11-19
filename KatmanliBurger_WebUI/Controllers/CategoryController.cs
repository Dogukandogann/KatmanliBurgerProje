using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.CategoryServices;
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
            Category model = new();
            return View(model);
        }
		[HttpPost]
        public IActionResult CreateByCategory(Category model)
        {
			
			_categoryService.Create(model);
			return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
         
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category model, int id)
        {
            var category = _categoryService.GetById(id);
           category.Name= model.Name;

            _categoryService.Update(model);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {

            _categoryService.UpdateStatus(id);
            return RedirectToAction("Index");

        }
    }
}
