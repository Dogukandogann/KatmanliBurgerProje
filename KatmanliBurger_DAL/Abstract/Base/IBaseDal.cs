using KatmanliBurger_DATA.Abstracts;
using System.Linq.Expressions;

namespace KatmanliBurger_DAL.Abstract.Base
{
    public interface IBaseDal<T> where T : BaseEntity, new()
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetByIdList(List<int> ids);
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
