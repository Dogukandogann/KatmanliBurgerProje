using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        //nav
        public virtual ICollection<ByProduct> ByProducts { get; set; }
    }
}
