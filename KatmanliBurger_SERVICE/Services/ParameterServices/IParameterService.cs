using KatmanliBurger_DATA.DomainModels;

namespace KatmanliBurger_SERVICE.Services.ParameterServices
{
	public interface IParameterService
	{
		void Create(ParameterDetail entity);
		void Update(ParameterDetail entity);
		void UpdateStatus(int id);
		ParameterDetail GetById(int id);
		IEnumerable<ParameterDetail> GetAll();
	}
}
