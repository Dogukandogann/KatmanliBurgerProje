using KatmanliBurger_DAL.Abstract;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.Concretes;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
    public class EfByProductDal : EfBaseDal<ByProduct, BurgerDbContext>, IByProductDal
    {
    }
}
