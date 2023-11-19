using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DAL.Contexts;
using KatmanliBurger_DATA.DomainModels;

namespace KatmanliBurger_DAL.Concretes.EntityFramework
{
	public class EfParameterDal :EfBaseDal<ParameterDetail, BurgerDbContext>, IParameterDal
	{
	}
}
