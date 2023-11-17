using KatmanliBurger_DAL.Abstracts.Base;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Abstracts
{
    public interface IOrderDal:IBaseDal<Order>
    {
		Order OrderWithDetails(int orderId);
		List<Order> OrderWithDetailList(List<Order> orders);

	}
}
