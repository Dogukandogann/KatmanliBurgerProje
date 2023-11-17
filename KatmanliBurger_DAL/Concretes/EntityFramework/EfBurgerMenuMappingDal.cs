using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;

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

		public List<BurgerMenuMapping> GetBurgerNamesForMenu()
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				var values = context.BurgerMenus.Include(x => x.Burger).ToList();
				return values;
			}
		}

		public IEnumerable<BurgerMenuMapping> GetByBurgerId(int id)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				return context.BurgerMenus.Where(x => x.BurgerId == id).ToList();
			}
		}

		public IEnumerable<BurgerMenuMapping> GetByMenuId(int id)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				return context.BurgerMenus.Where(x => x.MenuId == id).ToList();
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
