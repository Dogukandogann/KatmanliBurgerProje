namespace KatmanliBurger_DATA.Concretes
{
    public class MenuByProduct
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int ByProductId { get; set; }

        //nav
        public virtual Menu Menu { get; set; }
        public virtual ByProduct ByProduct { get; set; }
    }
}
