using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.Concretes
{
    public class MenuOrder
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int OrderId { get; set; }

        //nav
        public virtual Menu Menu { get; set; }
        public virtual Order Order { get; set; }
    }
}
