using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IOrderByProductMappingDal : IBaseDal<OrderByProductMapping>
    {
        IEnumerable<OrderByProductMapping> GetAll(Expression<Func<OrderByProductMapping, bool>> filter = null);
        void Create(IEnumerable<OrderByProductMapping> entities);
        void Update(IEnumerable<OrderByProductMapping> entities);
        void Delete(IEnumerable<OrderByProductMapping> entities);
        IEnumerable<OrderByProductMapping> GetByOrderId(int id);
        IEnumerable<OrderByProductMapping> GetByProductId(int id);
    }
}
