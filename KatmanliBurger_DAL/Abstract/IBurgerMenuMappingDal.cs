using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IBurgerMenuMappingDal : IBaseDal<BurgerMenuMapping>
    {
        void Create(IEnumerable<BurgerMenuMapping> entities);
        void Update(IEnumerable<BurgerMenuMapping> entities);
        void Delete(IEnumerable<BurgerMenuMapping> entities);
        IEnumerable<BurgerMenuMapping> GetByMenuId(int id);
        IEnumerable<BurgerMenuMapping> GetByBurgerId(int id);
    }
}
