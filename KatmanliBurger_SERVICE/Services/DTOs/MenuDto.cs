using KatmanliBurger_DATA.Concretes;
namespace KatmanliBurger_SERVICE.Services.DTOs
{
	public class MenuDto
	{
		public Menu Menu { get; set; }
		public List<Burger> Burgers { get; set; }
		public List<Burger> AllBurgers { get; set; }
		public List<BurgerGarnitureMapping> BurgerGarnitureMappings { get; set; }
		public List<ByProduct> Byproducts { get; set; }
		public List<ByProduct> AllByproducts { get; set; }
		public List<MenuByProductMapping> MenuByProductMappings { get; set; }
		public List<Garniture> Garnitures { get; set; }
		public List<Garniture> AllGarnitures { get; set; }
        public List<CustomSelectItem> Size { get; set; }
    }

	public class CustomSelectItem
	{
		public string Value { get; set; }
		public string Text { get; set; }
	}

}
