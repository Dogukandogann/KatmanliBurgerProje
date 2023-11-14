using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IBurgerGarnitureMappingDal : IBaseDal<BurgerGarnitureMapping>
    {
        void Craete(IEnumerable<BurgerGarnitureMapping> entities);
        void Update(IEnumerable<BurgerGarnitureMapping> entities);
        IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id);
    }
}
