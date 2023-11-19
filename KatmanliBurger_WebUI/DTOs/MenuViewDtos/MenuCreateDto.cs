using KatmanliBurger_DATA.Concretes;
using System.Linq.Expressions;

namespace KatmanliBurger_UI.DTOs.MenuViewDtos
{
	public class MenuCreateDto
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Piece { get; set; } = 1;
        public List<Burger> Burgers { get; set; }
        public Burger Burger { get; set; }
        public ByProduct Byproduct { get; set; }
       
        public ICollection<ByProduct> Tatlilar { get; set; }
        public ICollection<ByProduct> Icecekler { get; set; }
        public ICollection<ByProduct> CıtırLezzetler { get; set; }

    }
}
