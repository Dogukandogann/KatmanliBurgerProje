using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Piece { get; set; } = 1;

        //nav
        public virtual ICollection<BurgerMenuMapping> BurgerMenus { get; set; }
        public virtual ICollection<MenuOrderMapping> MenuOrders { get; set; }
        public virtual ICollection<MenuByProductMapping> MenuByProducts { get; set; }
    }
}
