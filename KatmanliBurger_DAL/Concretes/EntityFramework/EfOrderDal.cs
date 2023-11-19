using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
	public class EfOrderDal : EfBaseDal<Order, BurgerDbContext>, IOrderDal
	{
		public Order OrderWithDetails(int orderId)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				var orderWithDetails = context.Orders.Include(o => o.BurgerOrders).ThenInclude(bo => bo.Burger).Include(o => o.MenuOrders).ThenInclude(mo => mo.Menu).Include(o => o.OrderByProducts).ThenInclude(obp => obp.ByProduct).Include(u=>u.User).FirstOrDefault(o => o.Id == orderId);

				return orderWithDetails;
			}
		}

		public List<Order> OrderWithDetailList(List<Order> orders)
		{
			using (BurgerDbContext context = new BurgerDbContext())
			{
				var orderWithDetails = context.Orders.Include(o => o.BurgerOrders).ThenInclude(bo => bo.Burger).Include(o => o.MenuOrders).ThenInclude(mo => mo.Menu).Include(o => o.OrderByProducts).ThenInclude(obp => obp.ByProduct).ToList();
				return orderWithDetails;
			}
		}
		
	}
}
