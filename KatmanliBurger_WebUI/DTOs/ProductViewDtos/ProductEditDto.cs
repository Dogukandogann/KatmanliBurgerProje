using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_UI.DTOs.ProductViewDtos
{
    public class ProductEditDto
    {
        public ByProduct ByProduct { get; set; }
        public List<Category> Categories { get; set; }
        public List<Size> Size { get; set; }
    }
}
