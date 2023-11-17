using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_SERVICE.Services.GarnitureServices
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
