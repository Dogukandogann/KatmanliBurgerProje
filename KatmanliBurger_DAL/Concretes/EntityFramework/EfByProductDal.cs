using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
	public class EfByProductDal : EfBaseDal<ByProduct, BurgerDbContext>, IByProductDal
	{
		public List<ByProduct> GetProductsWithCategories()
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				var values = context.ByProducts.Include(x => x.Category).ToList();
				return values;
			}
		}
	}
}
