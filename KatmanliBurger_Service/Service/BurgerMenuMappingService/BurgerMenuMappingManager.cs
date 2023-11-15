using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerMenuMappingService
{
    public class BurgerMenuMappingManager : IBurgerMenuMappingService
    {
        private readonly IBurgerMenuMappingDal _burgerMenuMappingDal;

        public BurgerMenuMappingManager(IBurgerMenuMappingDal burgerMenuMappingDal)
        {
            _burgerMenuMappingDal = burgerMenuMappingDal;
        }

        public void Create(IEnumerable<BurgerMenuMapping> entities)
        {
            _burgerMenuMappingDal.Create(entities);
        }

        public void Delete(IEnumerable<BurgerMenuMapping> entities)
        {
            _burgerMenuMappingDal.Delete(entities);
        }

        public IEnumerable<BurgerMenuMapping> GetAll(Expression<Func<BurgerMenuMapping, bool>> filter = null)
        {
            return _burgerMenuMappingDal.GetAll(filter);
        }

        public IEnumerable<BurgerMenuMapping> GetByBurgerId(int id)
        {
           return  _burgerMenuMappingDal.GetByBurgerId(id);
        }

        public IEnumerable<BurgerMenuMapping> GetByMenuId(int id)
        {
            return _burgerMenuMappingDal.GetByMenuId(id);
        }

        public void Update(IEnumerable<BurgerMenuMapping> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedDate = DateTime.Now;
            }
            _burgerMenuMappingDal.Update(entities);
        }
    }
}
