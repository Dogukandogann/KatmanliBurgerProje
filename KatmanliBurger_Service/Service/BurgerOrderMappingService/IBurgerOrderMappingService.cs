using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerOrderMappingService
{
    public interface IBurgerOrderMappingService
    {
        IEnumerable<BurgerOrderMapping> GetAll(Expression<Func<BurgerOrderMapping, bool>> filter = null);
        void Create(IEnumerable<BurgerOrderMapping> entities);
        void Update(IEnumerable<BurgerOrderMapping> entities);
        void Delete(IEnumerable<BurgerOrderMapping> entities);
        IEnumerable<BurgerOrderMapping> GetByBurgerId(int id);
        IEnumerable<BurgerOrderMapping> GetByOrderId(int id);
    }
}
