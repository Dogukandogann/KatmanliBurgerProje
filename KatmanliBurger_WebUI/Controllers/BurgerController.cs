using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using KatmanliBurger_Service.Service.BurgerService;
using KatmanliBurger_WebUI.DTOs.BurgerViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_UI.Controllers
{
    public class BurgerController : Controller
    {
        IBurgerService _burgerService;
        IGarnitureDal _garnitureDal;
        IBurgerGarnitureMappingDal _burgerGarnitureMappingDal;

        public BurgerController(IBurgerService burgerService, IGarnitureDal garnitureDal, IBurgerGarnitureMappingDal burgerGarnitureMappingDal)
        {
            _burgerService = burgerService;
            _garnitureDal = garnitureDal;
            _burgerGarnitureMappingDal = burgerGarnitureMappingDal;
        }

        public IActionResult Index()
        {

           var burgers = _burgerService.GetAll();
            return View(burgers);
        }

        public IActionResult CreateBurger()
        {
            var garnitures = _garnitureDal.GetAll();
            BurgerCreateDto model = new();
            model.Garnitures = garnitures;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBurger(BurgerCreateDto model, int[] selectedgarniture)
        {
            Burger burger = new()
            {
                Name = model.Name,
                Description=model.Description,
                Price =model.Price,
                Image=model.Image
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
        public IActionResult Edit(int id)
        {
            var burger = _burgerService.GetById(id);
            burger.BurgerGarnitures= (ICollection<BurgerGarnitureMapping>)_burgerGarnitureMappingDal.GetByBurgerId(id);
            BurgerUpdateDto dto = new BurgerUpdateDto()
            {
                Name=burger.Name,
                Image=burger.Image,
                Description=burger.Description,
                Id=burger.Id,
                Price= burger.Price,
                Garnitures = burger.BurgerGarnitures
            };
            
            dto.AllGarnitures = _garnitureDal.GetAll();
            

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(BurgerUpdateDto model, int[] selectedgarniture, int id)
        {
            var burger = _burgerService.GetById(id);
            burger.Name = model.Name;
            burger.Price= model.Price;
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
                    //if (selectedgarniture.Any(x=>x==item.GarnitureId))
                    //{
                    //    _burgerGarnitureMappingDal.Create(item);
                    //}
                    //else
                    //{
                    //    
                    //}
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
        public IActionResult Delete(int id)
        {
            
            _burgerService.UpdateStatus(id);
            return RedirectToAction("Index");

        }
    }
}
