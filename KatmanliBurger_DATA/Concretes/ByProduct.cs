using KatmanliBurger_DATA.Abstracts;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_DATA.Concretes
{
    public class ByProduct:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Piece { get; set; } = 1;
        public Size Size { get; set; } = Size.Medium;
        public int CategoryId { get; set; }

        //nav
        public virtual ICollection<MenuByProductMapping> MenuByProducts { get; set; }
        public virtual ICollection<OrderByProductMapping> OrderByProducts { get; set; }
        public virtual Category Category { get; set; }
    }
}
