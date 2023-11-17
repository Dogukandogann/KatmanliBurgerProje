using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstracts
{
    public interface IMenuOrderMappingDal:IBaseDal<MenuOrderMapping>
    {
		void Create(IEnumerable<MenuOrderMapping> entities);
		void Update(IEnumerable<MenuOrderMapping> entities);

		IEnumerable<MenuOrderMapping> GetByOrderId(int id);
		IEnumerable<MenuOrderMapping> GetByMenuId(int id);
		
		void Delete(IEnumerable<MenuOrderMapping> entities);
		IEnumerable<MenuOrderMapping> GetAll(Expression<Func<MenuOrderMapping, bool>> expression = null);
	}
}
