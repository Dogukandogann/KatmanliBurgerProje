using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.ByProductService
{
    public interface IByProductService
    {
        void Create(ByProduct entity);
        void Update(ByProduct entity);
        void UpdateStatus(int id);
        ByProduct GetById(int id);
        IEnumerable<ByProduct> GetAll();
    }
}
