using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_SERVICE.Services.ByProductServices
{
    public interface IByProductService
    {
		void Create(ByProduct entity);
		void Update(ByProduct entity);
		void UpdateStatus(int id);
		ByProduct GetById(int id);
		IEnumerable<ByProduct> GetAll();
		List<ByProduct> GetProductsWithCategories();
	}
}
