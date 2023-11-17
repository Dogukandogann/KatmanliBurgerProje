using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_WebUI.DTOs.MenuViewDtos
{
    public class MenuUpdateDtos
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Piece { get; set; } = 1;

        public List<MenuByProductMapping> Products { get; set; }
        public List<BurgerMenuMapping> Burgers { get; set; }
        public List<Burger> AllBurgers { get; set; }
    }
}
