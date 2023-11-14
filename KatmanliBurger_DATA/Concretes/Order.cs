using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Order:BaseEntity
    {
        public string UserId { get; set; }

        //nav
        public virtual AppUser User { get; set; }
        public virtual ICollection<BurgerOrderMapping> BurgerOrders { get; set; }
        public virtual ICollection<MenuOrderMapping> MenuOrders { get; set; }
        public virtual ICollection<OrderByProductMapping> OrderByProducts { get; set; }
    }
}