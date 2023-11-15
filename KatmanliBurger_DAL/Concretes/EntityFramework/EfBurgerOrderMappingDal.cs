using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBurgerOrderMappingDal : EfBaseDal<BurgerOrderMapping, BurgerDbContext>, IBurgerOrderMappingDal
    {
        public void Create(IEnumerable<BurgerOrderMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerOrders.AddRange(entities); 
                context.SaveChanges();
            }
        }

        public void Delete(IEnumerable<BurgerOrderMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerOrders.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public IEnumerable<BurgerOrderMapping> GetByBurgerId(int id)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                return context.BurgerOrders.Where(x => x.Id.Equals(id));
            }
        }

        public IEnumerable<BurgerOrderMapping> GetByOrderId(int id)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                return context.BurgerOrders.Where(x => x.OrderId.Equals(id));
            }
        }

        public void Update(IEnumerable<BurgerOrderMapping> entities)
        {
            using (BurgerDbContext context = new BurgerDbContext())
            {
                context.BurgerOrders.UpdateRange(entities);
                context.SaveChanges();
            }
        }
    }
}
