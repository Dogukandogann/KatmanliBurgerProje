using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IMenuOrderMappingDal : IBaseDal<MenuOrderMapping>
    {
        IEnumerable<MenuOrderMapping> GetAll(Expression<Func<MenuOrderMapping, bool>> filter = null);
        void Create(IEnumerable<MenuOrderMapping> entities);
        void Update(IEnumerable<MenuOrderMapping> entities);
        void Delete(IEnumerable<MenuOrderMapping> entities);
        IEnumerable<MenuOrderMapping> GetByOrderId(int id);
        IEnumerable<MenuOrderMapping> GetByMenuId(int id);
    }
}
