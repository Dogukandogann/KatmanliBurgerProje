using KatmanliBurger_DATA.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.DomainModels
{
    public class BasketLine
    {
        public ByProduct ByProduct { get; set; }
        public Menu Menu { get; set; }
        public Burger Burger { get; set; }
        public int ByProductQuantity { get; set; }
        public int MenuQuantity { get; set; }
        public int BurgerQuantity { get; set; }
    }
}
