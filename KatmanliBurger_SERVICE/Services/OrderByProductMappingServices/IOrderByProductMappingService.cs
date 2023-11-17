using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_SERVICE.Services.OrderByProductMappingServices
{
    public interface IOrderByProductMappingService
    {
		void Create(IEnumerable<OrderByProductMapping> entities);
		void Update(IEnumerable<OrderByProductMapping> entities);
		IEnumerable<OrderByProductMapping> GetByProductId(int id);
		IEnumerable<OrderByProductMapping> GetByOrderId(int id);
		IEnumerable<OrderByProductMapping> GetAll(Expression<Func<OrderByProductMapping, bool>> expression = null);
		void Delete(IEnumerable<OrderByProductMapping> entities);
	}
}
