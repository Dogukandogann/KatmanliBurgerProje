using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_WebUI.DTOs.BurgerViewDtos
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
