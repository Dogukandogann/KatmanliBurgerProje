using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Order:BaseEntity
    {
        public string UserId { get; set; }

        //nav
        public virtual AppUser User { get; set; }
        public virtual ICollection<BurgerOrder> BurgerOrders { get; set; }
        public virtual ICollection<MenuOrder> MenuOrders { get; set; }
        public virtual ICollection<OrderByProduct> OrderByProducts { get; set; }
    }
}