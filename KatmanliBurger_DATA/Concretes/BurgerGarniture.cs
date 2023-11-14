namespace KatmanliBurger_DATA.Concretes
{
    public class BurgerGarniture
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public int GarnitureId { get; set; }

        //nav

        public virtual Burger Burger { get; set; }
        public virtual Garniture Garniture { get; set; }
    }
}
