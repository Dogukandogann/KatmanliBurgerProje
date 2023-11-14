﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.Concretes
{
    public class OrderByProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ByProductId { get; set; }

        //nav
        public virtual Order Order { get; set; }
        public virtual ByProduct ByProduct { get; set; }
    }
}
