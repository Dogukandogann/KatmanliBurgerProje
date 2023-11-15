using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Concretes.EntityFramework;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_Service.Service.OrderService
{
    public class OrderManager : IOrderService
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
           return  _orderDal.GetById(id);
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
