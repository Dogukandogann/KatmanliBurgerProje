using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerGarnitureMappingService
{
    public class BurgerGarnitureMappingManager : IBurgerGarnitureMappingService
    {
        private readonly IBurgerGarnitureMappingDal _burgerGarnitureMappingDal;

        public BurgerGarnitureMappingManager(IBurgerGarnitureMappingDal burgerGarnitureMappingDal)
        {
            _burgerGarnitureMappingDal = burgerGarnitureMappingDal;
        }

        public void Create(IEnumerable<BurgerGarnitureMapping> entities)
        {
            _burgerGarnitureMappingDal.Create(entities);
        }

        public void Delete(IEnumerable<BurgerGarnitureMapping> entities)
        {
            _burgerGarnitureMappingDal.Delete(entities);
        }

        public IEnumerable<BurgerGarnitureMapping> GetAll(Expression<Func<BurgerGarnitureMapping, bool>> filter = null)
        {
            return _burgerGarnitureMappingDal.GetAll(filter);
        }

        public IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id)
        {
            return _burgerGarnitureMappingDal.GetByBurgerId(id);
        }

        public void Update(IEnumerable<BurgerGarnitureMapping> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedDate = DateTime.Now;
            } 
            _burgerGarnitureMappingDal.Update(entities);
        }
    }
}
