using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfBurgerDal : EfBaseDal<Burger, BurgerDbContext>, IBurgerDal
    {
    }
}
