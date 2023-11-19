using KatmanliBurger_DATA.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DATA.Concretes
{
    public class CustomerMessage:BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerPhone{ get; set; }
        public string CustomerEmail { get; set; }
        public string Message { get; set; }
    }
}
