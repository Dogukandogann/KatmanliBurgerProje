using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.DomainModels
{
    public class Basket
    {
        public Basket()
        {
            BasketLines=new HashSet<BasketLine>();
        }
        public ICollection<BasketLine> BasketLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
