using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_SERVICE.Services.OrderServices
{
    public class OrderManager: IOrderService
    {
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public void Create(Order entity)
		{
			_orderDal.Create(entity);
		}

		public IEnumerable<Order> GetAll()
		{
			return _orderDal.GetAll();
		}

		public Order GetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public List<Order> OrderWithDetailList(List<Order> orders)
		{
			return _orderDal.OrderWithDetailList(orders);
		}

		public Order OrderWithDetails(int orderId)
		{
			return _orderDal.OrderWithDetails(orderId);
		}

		public void Update(Order entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_orderDal.Update(entity);
		}

		public void UpdateStatus(int id)
		{
			var order = _orderDal.GetById(id);
			order.Status = order.Status == Status.Active ? Status.Active : Status.Passive;
			order.UpdatedDate = DateTime.Now;
			_orderDal.Update(order);
		}
	}
}
