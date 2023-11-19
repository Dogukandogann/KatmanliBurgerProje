using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Order:BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public string? Description { get; set; }

        //nav
        public virtual AppUser User { get; set; }
        public virtual ICollection<BurgerOrderMapping>? BurgerOrders { get; set; }
        public virtual ICollection<MenuOrderMapping>? MenuOrders { get; set; }
        public virtual ICollection<OrderByProductMapping>? OrderByProducts { get; set; }
    }
}