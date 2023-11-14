using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class BurgerGarnitureMapping :BaseEntity
    {
        public int BurgerId { get; set; }
        public int GarnitureId { get; set; }

        //nav

        public virtual Burger Burger { get; set; }
        public virtual Garniture Garniture { get; set; }
    }
}
