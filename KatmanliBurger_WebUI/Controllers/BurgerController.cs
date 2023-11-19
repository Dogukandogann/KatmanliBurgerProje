using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_SERVICE.Services.BurgerServices;
using KatmanliBurger_SERVICE.Services.GarnitureServices;
using KatmanliBurger_UI.DTOs.BurgerViewDtos;
using KatmanliBurger_UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
	[Authorize(Roles = "Admin")]
    public class BurgerController : Controller
    {
        IBurgerService _burgerService;
        IGarnitureService _garnitureService;
        IBurgerGarnitureMappingDal _burgerGarnitureMappingDal;

        public BurgerController(IBurgerService burgerService, IGarnitureService garnitureService, IBurgerGarnitureMappingDal burgerGarnitureMappingDal)
        {
            _burgerService = burgerService;
            _garnitureService = garnitureService;
            _burgerGarnitureMappingDal = burgerGarnitureMappingDal;
        }

        public IActionResult Index()
        {
			var burgers = _burgerService.GetAll();
            return View(burgers);
        }

        public IActionResult CreateBurger()
        {
            try
            {
				var garnitures = _garnitureService.GetAll();
				BurgerCreateDto model = new();
				model.Garnitures = garnitures;
				return View(model);
			}
            catch (Exception)
            {
				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "Burger");

			}
        }

        [HttpPost]
        public IActionResult CreateBurger(BurgerCreateDto model, int[] selectedgarniture)
        {
            try
            {
				if (!ModelState.IsValid)
				{
					var garnitures = _garnitureService.GetAll();
					model.Garnitures = garnitures;
					return View(model);
				}

				Burger burger = new()
				{
					Name = model.Name,
					Description = model.Description,
					Price = model.Price,
					Image = model.Image
				};

				_burgerService.Create(burger);
				burger.BurgerGarnitures = new List<BurgerGarnitureMapping>();

				foreach (var item in selectedgarniture)
				{
					burger.BurgerGarnitures.Add(new BurgerGarnitureMapping() { GarnitureId = item, BurgerId = burger.Id });
				}

				_burgerGarnitureMappingDal.Create(burger.BurgerGarnitures);

				return RedirectToAction("Index");
			}
            catch (Exception)
            {
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Kayit_Basarisiz");
				return RedirectToAction("Index", "Burger");
			}
        }

        public IActionResult Edit(int id)
        {
            try
            {
				var burger = _burgerService.GetById(id);
				burger.BurgerGarnitures = (ICollection<BurgerGarnitureMapping>)_burgerGarnitureMappingDal.GetByBurgerId(id);
				BurgerUpdateDto dto = new BurgerUpdateDto()
				{
					Name = burger.Name,
					Image = burger.Image,
					Description = burger.Description,
					Id = burger.Id,
					Price = burger.Price,
					Garnitures = burger.BurgerGarnitures
				};

				dto.AllGarnitures = _garnitureService.GetAll();

				return View(dto);
			}
            catch (Exception)
            {
				TempData["hata"] = ErrorMessageProvider.GetErrorMessage("Genel_Hata");
				return RedirectToAction("Index", "Burger");
			}
        }

        [HttpPost]
        public IActionResult Edit(BurgerUpdateDto model, int[] selectedgarniture, int id)
        {
            try
            {
				var burger = _burgerService.GetById(id);
				burger.Name = model.Name;
				burger.Price = model.Price;
				burger.Description = model.Description;
				burger.Image = model.Image;
				burger.BurgerGarnitures = (ICollection<BurgerGarnitureMapping>)model.Garnitures;
				_burgerService.Update(burger);
				var mappings = _burgerGarnitureMappingDal.GetByBurgerId(id);

				foreach (var item in mappings)
				{
					if (!selectedgarniture.Any(x => x == item.GarnitureId))
					{
						_burgerGarnitureMappingDal.Delete(item);
					}
				}

				foreach (var item in selectedgarniture)
				{
					if (!mappings.Any(x => x.GarnitureId == item))
					{
						_burgerGarnitureMappingDal.Create(new BurgerGarnitureMapping()
						{
							GarnitureId = item,
							BurgerId = id
						});
					}
				}

				return RedirectToAction("Index");
			}
            catch (Exception)
            {
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Guncelleme_Basarisiz");
				return RedirectToAction("Index", "Burger");
			}
        }

        public IActionResult Delete(int id)
        {
			try
			{
				_burgerService.UpdateStatus(id);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				TempData["exception"] = ErrorMessageProvider.GetErrorMessage("Silme_Basarisiz");
				return RedirectToAction("Index", "Burger");
			}
        }
    }
}
