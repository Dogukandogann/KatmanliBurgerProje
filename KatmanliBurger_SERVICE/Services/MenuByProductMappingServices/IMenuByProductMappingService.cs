using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.MenuByProductMappingServices
{
    public interface IMenuByProductMappingService
    {
		void Create(IEnumerable<MenuByProductMapping> entities);
		void Update(IEnumerable<MenuByProductMapping> entities);
		IEnumerable<MenuByProductMapping> GetByMenuId(int id);
		IEnumerable<MenuByProductMapping> GetByProductId(int id);
		IEnumerable<MenuByProductMapping> GetAll(Expression<Func<MenuByProductMapping, bool>> expression = null);
		void Delete(IEnumerable<MenuByProductMapping> entities);
		List<MenuByProductMapping> GetProductsForMenu();
	}
}
