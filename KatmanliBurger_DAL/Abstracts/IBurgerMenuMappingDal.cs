using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Abstracts
{
    public interface IBurgerMenuMappingDal:IBaseDal<BurgerMenuMapping>
    {
		void Create(IEnumerable<BurgerMenuMapping> entities);
		void Update(IEnumerable<BurgerMenuMapping> entities);

		IEnumerable<BurgerMenuMapping> GetByMenuId(int id);
		IEnumerable<BurgerMenuMapping> GetByBurgerId(int id);
		
		void Delete(IEnumerable<BurgerMenuMapping> entities);
		List<BurgerMenuMapping> GetBurgerNamesForMenu();
	}
}
