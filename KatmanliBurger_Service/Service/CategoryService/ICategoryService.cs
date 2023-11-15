using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_Service.Service.CategoryService
{
    public interface ICategoryService
    {
        void Create(Category entity);
        void Update(Category entity);
        void UpdateStatus(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
    }
}
