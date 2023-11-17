using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstracts
{
    public interface IMenuByProductMappingDal:IBaseDal<MenuByProductMapping>
    {
		void Create(IEnumerable<MenuByProductMapping> entities);
		void Update(IEnumerable<MenuByProductMapping> entities);

		IEnumerable<MenuByProductMapping> GetByProductId(int id);
		IEnumerable<MenuByProductMapping> GetByMenuId(int id);

		void Delete(IEnumerable<MenuByProductMapping> entities);
		IEnumerable<MenuByProductMapping> GetAll(Expression<Func<MenuByProductMapping, bool>> expression = null);
		List<MenuByProductMapping> GetProductsForMenu();
	}
}
