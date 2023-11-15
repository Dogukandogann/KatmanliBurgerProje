using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_Service.Service.GarnitureService
{
    public interface IGarnitureService 
    {
        void Create(Garniture entity);
        void Update(Garniture entity);
        void UpdateStatus(int id);
        Garniture GetById(int id);
        IEnumerable<Garniture> GetAll();
    }
}
