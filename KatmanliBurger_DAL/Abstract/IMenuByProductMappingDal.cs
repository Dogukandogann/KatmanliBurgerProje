using KatmanliBurger_DAL.Abstract.Base;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstract
{
    public interface IMenuByProductMappingDal : IBaseDal<MenuByProductMapping>
    {
        IEnumerable<MenuByProductMapping> GetAll(Expression<Func<MenuByProductMapping, bool>> filter = null);
        void Create(IEnumerable<MenuByProductMapping> entities);
        void Update(IEnumerable<MenuByProductMapping> entities);
        void Delete(IEnumerable<MenuByProductMapping> entities);
        IEnumerable<MenuByProductMapping> GetByProductId(int id);
        IEnumerable<MenuByProductMapping> GetByMenuId(int id);
    }
}
