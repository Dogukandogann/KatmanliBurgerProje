﻿using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.Concretes
{
    public class BurgerOrderMapping:BaseEntity
    {
       
        public int BurgerId { get; set; }
        public int OrderId { get; set; }

        //nav
        public virtual Burger Burger { get; set; }
        public virtual Order Order { get; set; }
    }
}
