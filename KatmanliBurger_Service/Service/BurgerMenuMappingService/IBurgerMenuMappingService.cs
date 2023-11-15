using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerMenuMappingService
{
    public interface IBurgerMenuMappingService
    {
        IEnumerable<BurgerMenuMapping> GetAll(Expression<Func<BurgerMenuMapping, bool>> filter = null);
        void Create(IEnumerable<BurgerMenuMapping> entities);
        void Update(IEnumerable<BurgerMenuMapping> entities);
        void Delete(IEnumerable<BurgerMenuMapping> entities);
        IEnumerable<BurgerMenuMapping> GetByBurgerId(int id);
        IEnumerable<BurgerMenuMapping> GetByMenuId(int id); 

    }
}
