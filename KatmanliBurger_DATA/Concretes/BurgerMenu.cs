using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.Concretes
{
    public class BurgerMenu
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public int MenuId { get; set; }

        //nav
        public virtual Burger Burger { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
