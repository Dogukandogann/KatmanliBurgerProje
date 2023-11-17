using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Concretes.EntityFramework;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.OrderByProductMappingServices
{
	public class OrderByProductMappingManager : IOrderByProductMappingService
	{
		private readonly IOrderByProductMappingDal _orderByProductMappingDal;

		public OrderByProductMappingManager(IOrderByProductMappingDal orderByProductMappingDal)
		{
			_orderByProductMappingDal = orderByProductMappingDal;
		}

		public void Create(IEnumerable<OrderByProductMapping> entities)
		{
			_orderByProductMappingDal.Create(entities);
		}

		public void Delete(IEnumerable<OrderByProductMapping> entities)
		{
			_orderByProductMappingDal.Delete(entities);
		}

		public IEnumerable<OrderByProductMapping> GetAll(Expression<Func<OrderByProductMapping, bool>> expression = null)
		{
			return _orderByProductMappingDal.GetAll(expression);
		}

		public IEnumerable<OrderByProductMapping> GetByOrderId(int id)
		{
			return _orderByProductMappingDal.GetByOrderId(id);
		}

		public IEnumerable<OrderByProductMapping> GetByProductId(int id)
		{
			return _orderByProductMappingDal.GetByProductId(id);
		}

		public void Update(IEnumerable<OrderByProductMapping> entities)
		{
			foreach (var entity in entities)
			{
				entity.UpdatedDate = DateTime.Now;
			}
			_orderByProductMappingDal.Update(entities);
		}
	}
}
