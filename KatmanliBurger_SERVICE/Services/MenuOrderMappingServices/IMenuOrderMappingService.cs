using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.MenuOrderMappingServices
{
	public interface IMenuOrderMappingService
	{
		void Create(IEnumerable<MenuOrderMapping> entities);
		void Update(IEnumerable<MenuOrderMapping> entities);
		IEnumerable<MenuOrderMapping> GetByMenuId(int id);
		IEnumerable<MenuOrderMapping> GetByOrderId(int id);
		IEnumerable<MenuOrderMapping> GetAll(Expression<Func<MenuOrderMapping, bool>> expression = null);
		void Delete(IEnumerable<MenuOrderMapping> entities);
	}
}
