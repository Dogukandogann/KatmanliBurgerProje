using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;
using System.Security.Claims;

namespace KatmanliBurger_Service.Service.CategoryService
{
    public class CategoryManager : ICategoryService
    {


        private readonly ICategoryDal _categoryDal;



        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }



        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }



        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public void Update(Category entity)
        {
            entity.UpdatedDate= DateTime.Now;
            _categoryDal.Update(entity);
        }
        public void UpdateStatus(int id)
        {
            var category = _categoryDal.GetById(id);
            category.Status = category.Status == Status.Active ? Status.Passive : Status.Active;
            category.UpdatedDate = DateTime.Now;
            _categoryDal.Update(category);
        }
    }
}
