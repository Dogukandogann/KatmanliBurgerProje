using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_Service.Service.MenuService
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public void Create(Menu entity)
        {
            _menuDal.Create(entity);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuDal.GetAll();
        }

        public Menu GetById(int id)
        {
            return _menuDal.GetById(id);
        }
        public void Update(Menu entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _menuDal.Update(entity);
        }
        public void UpdateStatus(int id)
        {
            var menu = _menuDal.GetById(id);
            menu.Status = menu.Status == Status.Active ? Status.Passive : Status.Active;
            menu.UpdatedDate = DateTime.Now;
            _menuDal.Update(menu);
        }
    }
}
