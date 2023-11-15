using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_Service.Service.MenuOrderMappingService
{
    public class MenuOrderMappingManager : IMenuOrderMappingService
    {
        private readonly IMenuOrderMappingDal _menuOrderMappingDal;

        public MenuOrderMappingManager(IMenuOrderMappingDal menuOrderMappingDal)
        {
            _menuOrderMappingDal = menuOrderMappingDal;
        }

        public void Create(IEnumerable<MenuOrderMapping> entities)
        {
            _menuOrderMappingDal.Create(entities);
        }

        public void Delete(IEnumerable<MenuOrderMapping> entities)
        {
            _menuOrderMappingDal.Delete(entities);
        }

        public IEnumerable<MenuOrderMapping> GetAll(Expression<Func<MenuOrderMapping, bool>> filter = null)
        {
           return _menuOrderMappingDal.GetAll(filter);
        }

        public IEnumerable<MenuOrderMapping> GetByMenuId(int id)
        {
            return _menuOrderMappingDal.GetByMenuId(id);
        }

        public IEnumerable<MenuOrderMapping> GetByOrderId(int id)
        {
            return _menuOrderMappingDal.GetByOrderId(id);
        }

        public void Update(IEnumerable<MenuOrderMapping> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedDate = DateTime.Now;
            }
            _menuOrderMappingDal.Update(entities);
        }
    }
}
