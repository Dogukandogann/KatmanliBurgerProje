using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstracts
{
    public interface IBurgerOrderMappingDal:IBaseDal<BurgerOrderMapping>
    {
		void Create(IEnumerable<BurgerOrderMapping> entities);
		void Update(IEnumerable<BurgerOrderMapping> entities);

		IEnumerable<BurgerOrderMapping> GetByOrderId(int id);
		IEnumerable<BurgerOrderMapping> GetByBurgerId(int id);
	
		void Delete(IEnumerable<BurgerOrderMapping> entities);
		IEnumerable<BurgerOrderMapping> GetAll(Expression<Func<BurgerOrderMapping,bool>>expression=null);
	}
}
