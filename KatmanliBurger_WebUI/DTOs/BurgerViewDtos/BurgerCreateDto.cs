using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace KatmanliBurger_UI.DTOs.BurgerViewDtos
{
	public class BurgerCreateDto
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public string? Image { get; set; }
        public IEnumerable<Garniture> Garnitures { get; set; }
    }
}
