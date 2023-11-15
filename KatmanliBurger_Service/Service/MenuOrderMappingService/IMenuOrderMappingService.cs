using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.MenuOrderMappingService
{
    public interface IMenuOrderMappingService 
    {
        IEnumerable<MenuOrderMapping> GetAll(Expression<Func<MenuOrderMapping, bool>> filter = null);
        void Create(IEnumerable<MenuOrderMapping> entities);
        void Update(IEnumerable<MenuOrderMapping> entities);
        void Delete(IEnumerable<MenuOrderMapping> entities);
        IEnumerable<MenuOrderMapping> GetByMenuId(int id);
        IEnumerable<MenuOrderMapping> GetByOrderId(int id);
    }
}
