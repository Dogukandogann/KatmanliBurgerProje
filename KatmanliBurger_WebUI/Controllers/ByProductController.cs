using AutoMapper;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using KatmanliBurger_SERVICE.Services.CategoryServices;
using KatmanliBurger_WebUI.DTOs.ProductViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.Controllers
{
	public class ByProductController : Controller
	{
		IByProductService _byProductService;
		ICategoryService _categoryService;
		IMapper _mapper;

		public ByProductController(IByProductService byProductService, ICategoryService categoryService, IMapper mapper)
		{
			_byProductService = byProductService;
            _categoryService = categoryService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var products = _byProductService.GetProductsWithCategories();
			return View(products);
		}
		public IActionResult CreateByProduct()
		{
			ProductEditDto model = new();
			model.Categories = (List<Category>)_categoryService.GetAll();
			model.Size = new List<Size>() { Size.Small, Size.Medium, Size.Large };
			return View(model);
		}
		[HttpPost]
        public IActionResult CreateByProduct(ProductEditDto model)
        {
			ByProduct product = new()
			{
				Name=model.ByProduct.Name,
				Price=model.ByProduct.Price,
				Image=model.ByProduct.Image,
				Description=model.ByProduct.Description,
				Size=model.ByProduct.Size,
				Piece=model.ByProduct.Piece,
				CategoryId=model.ByProduct.CategoryId,
			};
			_byProductService.Create(product);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
		{
			ProductEditDto productViewDto = new ProductEditDto()
			{
				ByProduct = _byProductService.GetById(id),
				Categories = (List<Category>)_categoryService.GetAll(),
				Size = new List<Size>() { Size.Small,Size.Medium,Size.Large }
			};           
			return View(productViewDto);
		}
		[HttpPost]
        public IActionResult Edit(ProductEditDto model , int id)
        {
            var product = _byProductService.GetById(id);
			product.Name = model.ByProduct.Name;
			product.Price=model.ByProduct.Price;
			product.Description = model.ByProduct.Description;
			product.CategoryId = model.ByProduct.CategoryId;
			product.Size = model.ByProduct.Size;
			product.Image = model.ByProduct.Image;

			_byProductService.Update(product);

            return RedirectToAction("Index");
        }
		public IActionResult Delete(int id)
		{

			_byProductService.UpdateStatus(id);
			return RedirectToAction("Index");

		}

	}
}

