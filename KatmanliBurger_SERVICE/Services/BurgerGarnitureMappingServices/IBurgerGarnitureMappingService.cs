using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.BurgerGarnitureMappingServices
{
    public interface IBurgerGarnitureMappingService
    {
		IEnumerable<BurgerGarnitureMapping> GetAll(Expression<Func<BurgerGarnitureMapping, bool>> expression = null);
		void Create(IEnumerable<BurgerGarnitureMapping> entities);
		void Update(IEnumerable<BurgerGarnitureMapping> entities);
		IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id);
		void Delete(IEnumerable<BurgerGarnitureMapping> entities);
	}
}
