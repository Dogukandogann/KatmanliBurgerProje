using KatmanliBurger_DAL.Abstracts;
using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_SERVICE.Services.ParameterServices
{
	public class ParameterManager : IParameterService
	{
		private readonly IParameterDal _parameterDal;

		public ParameterManager(IParameterDal parameterDal)
		{
			_parameterDal = parameterDal;
		}

		public void Create(ParameterDetail entity)
		{
			_parameterDal.Create(entity);
		}

		public IEnumerable<ParameterDetail> GetAll()
		{
			return _parameterDal.GetAll();
		}

		public ParameterDetail GetById(int id)
		{
			return _parameterDal.GetById(id);
		}

		public void Update(ParameterDetail entity)
		{
			_parameterDal.Update(entity);
		}

		public void UpdateStatus(int id)
		{
			var parameter = _parameterDal.GetById(id);
			parameter.Status = parameter.Status == Status.Active ? Status.Active : Status.Passive;
			parameter.UpdatedDate = DateTime.Now;
			_parameterDal.Update(parameter);
		}
	}
}
