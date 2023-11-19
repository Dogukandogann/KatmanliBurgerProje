﻿using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfCustomerMessageDal : EfBaseDal<CustomerMessage, BurgerDbContext>, ICustomerMessageDal
    {
    }
}
