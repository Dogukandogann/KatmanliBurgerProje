using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.MenuByProductMappingService
{
    public interface IMenuByProductMappingService
    {
        IEnumerable<MenuByProductMapping> GetAll(Expression<Func<MenuByProductMapping, bool>> filter = null);
        void Create(IEnumerable<MenuByProductMapping> entities);
        void Update(IEnumerable<MenuByProductMapping> entities);
        void Delete(IEnumerable<MenuByProductMapping> entities);
        IEnumerable<MenuByProductMapping> GetByMenuId(int id);
        IEnumerable<MenuByProductMapping> GetByProductId(int id);
    }
}
