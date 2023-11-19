using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_SERVICE.Services.BurgerServices
{
	public class BurgerManager : IBurgerService
	{
		private readonly IBurgerDal _burgerDal;

		public BurgerManager(IBurgerDal burgerDal)
		{
			_burgerDal = burgerDal;
		}

		public void Create(Burger entity)
		{
			_burgerDal.Create(entity);
		}

		public IEnumerable<Burger> GetAll()
		{
			return _burgerDal.GetAll();
		}

		public Burger GetById(int id)
		{
			return _burgerDal.GetById(id);
		}

		public IEnumerable<Burger> GetByIdList(List<int> ids)
		{
			return _burgerDal.GetByIdList(ids);
		}

		public void Update(Burger entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_burgerDal.Update(entity);
		}

		public void UpdateStatus(int id)
		{
			var burger = _burgerDal.GetById(id);

			burger.Status = burger.Status == Status.Active ? Status.Passive : Status.Active;

			burger.UpdatedDate = DateTime.Now;

			_burgerDal.Update(burger);
		}
	}
}
