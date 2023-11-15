using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBurgerMenuMappingDal : EfBaseDal<BurgerMenuMapping, BurgerDbContext>, IBurgerMenuMappingDal
    {
        public void Create(IEnumerable<BurgerMenuMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerMenus.AddRange(entities);
                context.SaveChanges();
            }
        }

        public void Delete(IEnumerable<BurgerMenuMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerMenus.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public IEnumerable<BurgerMenuMapping> GetByBurgerId(int id)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                return context.BurgerMenus.Where(x => x.BurgerId.Equals(id));
            }
        }

        public IEnumerable<BurgerMenuMapping> GetByMenuId(int id)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                return context.BurgerMenus.Where(x=>x.MenuId.Equals(id));
            }
        }

        public void Update(IEnumerable<BurgerMenuMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerMenus.UpdateRange(entities);
                context.SaveChanges();
            }
        }
    }
}
