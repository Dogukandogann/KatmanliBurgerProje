using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
	public class EfMenuByProductMappingDal : EfBaseDal<MenuByProductMapping, BurgerDbContext>, IMenuByProductMappingDal
	{
		public void Create(IEnumerable<MenuByProductMapping> entities)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				context.MenuByProducts.AddRange(entities);
				context.SaveChanges();
			}
		}

		public void Delete(IEnumerable<MenuByProductMapping> entities)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				context.MenuByProducts.RemoveRange(entities);
				context.SaveChanges();
			}
		}

		public IEnumerable<MenuByProductMapping> GetByMenuId(int id)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				return context.MenuByProducts.Where(x => x.MenuId == id).ToList();
			}
		}

		public IEnumerable<MenuByProductMapping> GetByProductId(int id)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				return context.MenuByProducts.Where(x => x.ByProductId == id).ToList();
			}
		}

		public List<MenuByProductMapping> GetProductsForMenu()
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				var values = context.MenuByProducts.Include(x => x.ByProduct).ToList();
				return values;
			}
		}

		public void Update(IEnumerable<MenuByProductMapping> entities)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				context.MenuByProducts.UpdateRange(entities);
				context.SaveChanges();
			}
		}
	}
}
