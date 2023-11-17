using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Concretes.EntityFramework;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.BurgerOrderMappingServices
{
	public class BurgerOrderMappingManager : IBurgerOrderMappingService
		
	{
		private readonly IBurgerOrderMappingDal _burgerOrderMappingDal;

		public BurgerOrderMappingManager(IBurgerOrderMappingDal burgerOrderMappingDal)
		{
			_burgerOrderMappingDal = burgerOrderMappingDal;
		}

		public void Create(IEnumerable<BurgerOrderMapping> entities)
		{
			 _burgerOrderMappingDal.Create(entities);
		}

		public void Delete(IEnumerable<BurgerOrderMapping> entities)
		{
			_burgerOrderMappingDal.Delete(entities);
		}

		public IEnumerable<BurgerOrderMapping> GetAll(Expression<Func<BurgerOrderMapping, bool>> expression = null)
		{
			return _burgerOrderMappingDal.GetAll(expression);
		}

		public IEnumerable<BurgerOrderMapping> GetByBurgerId(int id)
		{
			return _burgerOrderMappingDal.GetByBurgerId(id);
		}

		public IEnumerable<BurgerOrderMapping> GetByOrderId(int id)
		{
			return _burgerOrderMappingDal.GetByOrderId(id);
		}

		public void Update(IEnumerable<BurgerOrderMapping> entities)
		{
			foreach (var entity in entities)
			{
				entity.UpdatedDate = DateTime.Now;
			}
			_burgerOrderMappingDal.Update(entities);
		}
	}
}
