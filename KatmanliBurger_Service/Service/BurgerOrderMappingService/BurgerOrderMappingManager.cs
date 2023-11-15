using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerOrderMappingService
{
    public class BurgerOrderMappingManager : IBurgerOrderMappingService
    {
        private readonly IBurgerOrderMappingDal _burgerOrderMappingDal;

        public BurgerOrderMappingManager(IBurgerOrderMappingDal burgerOrderMappingDal)
        {
            _burgerOrderMappingDal = burgerOrderMappingDal;
        }

        public void Create(IEnumerable<BurgerOrderMapping> entities)
        {
             _burgerOrderMappingDal.Create(entities);
        }

        public void Delete(IEnumerable<BurgerOrderMapping> entities)
        {
            _burgerOrderMappingDal.Delete(entities);
        }

        public IEnumerable<BurgerOrderMapping> GetAll(Expression<Func<BurgerOrderMapping, bool>> filter = null)
        {
            return _burgerOrderMappingDal.GetAll(filter);
        }

        public IEnumerable<BurgerOrderMapping> GetByBurgerId(int id)
        {
            return _burgerOrderMappingDal.GetByBurgerId(id);
        }

        public IEnumerable<BurgerOrderMapping> GetByOrderId(int id)
        {
            return _burgerOrderMappingDal.GetByOrderId(id);
        }

        public void Update(IEnumerable<BurgerOrderMapping> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedDate=DateTime.Now;
            }
            _burgerOrderMappingDal.Update(entities);
        }
    }
}
