using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBurgerGarnitureMappingDal : EfBaseDal<BurgerGarnitureMapping, BurgerDbContext>, IBurgerGarnitureMappingDal
    {
        public void Create(IEnumerable<BurgerGarnitureMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerGarnitures.AddRange(entities);
                context.SaveChanges();
            }
        }

        public  void Delete(IEnumerable<BurgerGarnitureMapping> entities)
        {
            
            
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerGarnitures.RemoveRange(entities);
                context.SaveChanges();
            }

        }

        public IEnumerable<BurgerGarnitureMapping> GetByBurgerId(int id)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                return context.BurgerGarnitures.Where(x => x.BurgerId.Equals(id)).ToList();
            }
        }

        public void Update(IEnumerable<BurgerGarnitureMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerGarnitures.UpdateRange(entities);
                context.SaveChanges();
            }

        }
    }
}
