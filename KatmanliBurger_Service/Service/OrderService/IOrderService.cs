using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_Service.Service.OrderService
{
    public interface IOrderService
    {
        void Create(Order entity);
        void Update(Order entity);
        void UpdateStatus(int id);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
    }
}
