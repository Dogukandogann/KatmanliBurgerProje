using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_SERVICE.Services.BurgerServices
{
    public interface IBurgerService
    {
        void Create(Burger entity);
        void Update(Burger entity);
        void UpdateStatus(int id);
        Burger GetById(int id);
        IEnumerable<Burger> GetAll();
        
    }
}
