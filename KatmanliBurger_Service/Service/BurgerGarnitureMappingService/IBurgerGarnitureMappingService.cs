using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.BurgerGarnitureMappingService
{
    public interface IBurgerGarnitureMappingService
    {

        IEnumerable<BurgerGarnitureMapping> GetAll(Expression<Func<BurgerGarnitureMapping, bool>> filter = null);
        void Create(IEnumerable<BurgerGarnitureMapping> entities);
        void Update(IEnumerable<BurgerGarnitureMapping> entities);
        void Delete(IEnumerable<BurgerGarnitureMapping> entities);
        IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id);

    }
}
