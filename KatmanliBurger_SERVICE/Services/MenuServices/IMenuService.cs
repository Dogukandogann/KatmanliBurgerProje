using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_SERVICE.Services.MenuServices
{
    public interface IMenuService
    {
		void Create(Menu entity);
		void Update(Menu entity);
		void UpdateStatus(int id);
		Menu GetById(int id);
		IEnumerable<Menu> GetAll();
	}
}
