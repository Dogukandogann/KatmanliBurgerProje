using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class BurgerMenuMapping : BaseEntity
    {
        public int BurgerId { get; set; }
        public int MenuId { get; set; }

        //nav
        public virtual Burger Burger { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
