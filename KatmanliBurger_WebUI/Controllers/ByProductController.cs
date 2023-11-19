using AutoMapper;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.CategoryServices;
using KatmanliBurger_UI.DTOs.ProductViewDtos;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ByProductController : Controller
	{
		IByProductService _byProductService;
		ICategoryService _categoryService;

		public ByProductController(IByProductService byProductService, ICategoryService categoryService)
		{
			_byProductService = byProductService;
            _categoryService = categoryService;
		}

		public IActionResult Index()
		{
			var products = _byProductService.GetProductsWithCategories();
			return View(products);
		}

		public IActionResult CreateByProduct()
		{
			try
			{
				ProductEditDto model = new();
				model.Categories = (List<Category>)_categoryService.GetAll();
				model.Size = new List<Size>() { Size.Small, Size.Medium, Size.Large };
				return View(model);
			}
			catch (Exception)
			{
				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "ByProduct");
			}
		}

		[HttpPost]
        public IActionResult CreateByProduct(ProductEditDto model)
        {
			try
			{
				ByProduct product = new()
				{
					Name = model.ByProduct.Name,
					Price = model.ByProduct.Price,
					Image = model.ByProduct.Image,
					Description = model.ByProduct.Description,
					Size = model.ByProduct.Size,
					Piece = model.ByProduct.Piece,
					CategoryId = model.ByProduct.CategoryId,
				};
				_byProductService.Create(product);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{

				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Kayit_Basarisiz");
				return RedirectToAction("Index", "ByProduct");
			}
        }
        public IActionResult Edit(int id)
		{
			try
			{
				ProductEditDto productViewDto = new ProductEditDto()
				{
					ByProduct = _byProductService.GetById(id),
					Categories = (List<Category>)_categoryService.GetAll(),
					Size = new List<Size>() { Size.Small, Size.Medium, Size.Large }
				};
				return View(productViewDto);
			}
			catch (Exception)
			{

				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "ByProduct");
			}
		}

		[HttpPost]
        public IActionResult Edit(ProductEditDto model , int id)
        {
			try
			{
				var product = _byProductService.GetById(id);
				product.Name = model.ByProduct.Name;
				product.Price = model.ByProduct.Price;
				product.Description = model.ByProduct.Description;
				product.CategoryId = model.ByProduct.CategoryId;
				product.Size = model.ByProduct.Size;
				product.Image = model.ByProduct.Image;

				_byProductService.Update(product);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Guncelleme_Basarisiz");
				return RedirectToAction("Index", "ByProduct");
			}
        }

		public IActionResult Delete(int id)
		{
			try
			{
				_byProductService.UpdateStatus(id);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Silme_Basarisiz");
				return RedirectToAction("Index", "ByProduct");
			}
		}
	}
}

