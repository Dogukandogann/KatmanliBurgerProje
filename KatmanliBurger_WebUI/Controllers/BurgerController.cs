using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_Service.Service.BurgerService;
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

            
            return View(Tuple.Create<Burger, IEnumerable<Garniture>>(new Burger(), _garnitureDal.GetAll()));
        }

        [HttpPost]
        public IActionResult Index([Bind(Prefix = "Item1")] Burger model, int[] SelectedGarnitures)
        {
         
            _burgerService.Create(model);

            model.BurgerGarnitures = new List<BurgerGarnitureMapping>()
            {
                new BurgerGarnitureMapping()
                {
                    GarnitureId = SelectedGarnitures.First(),
                    BurgerId=model.Id
                },
                 new BurgerGarnitureMapping()
                {
                    GarnitureId = SelectedGarnitures.Last(),
                    BurgerId=model.Id
                }
            };

            _burgerGarnitureMappingDal.Create(model.BurgerGarnitures);

            return View();
        }

           
        public IActionResult Edit(int id)
        {
           var burger= _burgerService.GetById(id);
			var mappings= _burgerGarnitureMappingDal.GetByBurgerId(id);
         var garniture=  _garnitureDal.GetByIdList(mappings.Select(x => x.GarnitureId).ToList());
            return View(Tuple.Create<Burger, IEnumerable<Garniture>,IEnumerable<Garniture>>(burger, garniture,_garnitureDal.GetAll()));
        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Burger model, int[] SelectedGarnitures, int id)
        {
            var burger = _burgerService.GetById(id);
            burger.BurgerGarnitures.ToList();
            burger.Name = model.Name;
            burger.Price= model.Price;
            burger.Description = model.Description;
            _burgerService.Update(burger);

            var mappings = _burgerGarnitureMappingDal.GetByBurgerId(id);

            foreach (var item in mappings)
            {
                if (SelectedGarnitures.Any(x=>x==item.GarnitureId))
                {
                    //_burgerGarnitureMappingDal.Create(item);
                }
                //else
                //{
                //    _burgerGarnitureMappingDal.Delete(item);
                //}
            }

            foreach (var item in SelectedGarnitures)
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
           
            return View();
        }
    }
}
