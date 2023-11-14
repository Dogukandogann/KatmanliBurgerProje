using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Garniture:BaseEntity
    {
        public string Name { get; set; }

        //nav

        public virtual ICollection<BurgerGarnitureMapping> BurgerGarnitures { get; set; }
    }
}
