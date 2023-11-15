using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IBurgerOrderMappingDal : IBaseDal<BurgerOrderMapping>
    {
        IEnumerable<BurgerOrderMapping> GetAll(Expression<Func<BurgerOrderMapping, bool>> filter = null);
        void Create(IEnumerable<BurgerOrderMapping> entities);
        void Update(IEnumerable<BurgerOrderMapping> entities);
        void Delete(IEnumerable<BurgerOrderMapping> entities);
        IEnumerable<BurgerOrderMapping> GetByBurgerId(int id);
        IEnumerable<BurgerOrderMapping> GetByOrderId(int id);
    }
}
