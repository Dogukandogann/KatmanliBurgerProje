﻿using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class Burger:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Piece { get; set; } = 1;

        //nav
        public virtual ICollection<BurgerGarniture> BurgerGarnitures { get; set; }
        public virtual ICollection<BurgerOrder> BurgerOrders { get; set; }
        public virtual ICollection<BurgerMenu> BurgerMenus { get; set; }
    }
}
