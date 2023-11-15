using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.OrderByProductMappingService
{
    public interface IOrderByProductMappingService
    {
        IEnumerable<OrderByProductMapping> GetAll(Expression<Func<OrderByProductMapping, bool>> filter = null);
        void Create(IEnumerable<OrderByProductMapping> entities);
        void Update(IEnumerable<OrderByProductMapping> entities);
        void Delete(IEnumerable<OrderByProductMapping> entities);
        IEnumerable<OrderByProductMapping> GetByOrderId(int id);
        IEnumerable<OrderByProductMapping> GetByProductId(int id);
    }
}
