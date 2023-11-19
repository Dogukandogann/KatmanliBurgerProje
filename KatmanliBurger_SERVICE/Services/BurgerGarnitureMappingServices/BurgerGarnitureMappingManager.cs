using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.BurgerGarnitureMappingServices
{
	public class BurgerGarnitureMappingManager : IBurgerGarnitureMappingService
	{
		private readonly IBurgerGarnitureMappingDal _burgerGarnitureMappingDal;

		public BurgerGarnitureMappingManager(IBurgerGarnitureMappingDal burgerGarnitureMappingDal)
		{
			_burgerGarnitureMappingDal = burgerGarnitureMappingDal;
		}

		public void Create(IEnumerable<BurgerGarnitureMapping> entities)
		{
			_burgerGarnitureMappingDal.Create(entities);
			
		}

		public void Delete(IEnumerable<BurgerGarnitureMapping> entities)
		{
			_burgerGarnitureMappingDal.Delete(entities);
		}

		public IEnumerable<BurgerGarnitureMapping> GetAll(Expression<Func<BurgerGarnitureMapping, bool>> expression = null)
		{
			return _burgerGarnitureMappingDal.GetAll(expression);
		}

		public IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id)
		{
			return _burgerGarnitureMappingDal.GetByBurgerId(id);
		}

		public IEnumerable<BurgerGarnitureMapping> GetByBurgerIds(List<int> burgerIds)
		{
			return _burgerGarnitureMappingDal.GetByBurgerIds(burgerIds);
		}

		public void Update(IEnumerable<BurgerGarnitureMapping> entities)
		{
			foreach (var entity in entities)
			{
				entity.UpdatedDate = DateTime.Now;
			}
			_burgerGarnitureMappingDal.Update(entities);
		}
	}
}
