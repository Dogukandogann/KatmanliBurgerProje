using KatmanliBurger_DATA.DomainModels;

namespace KatmanliBurger_UI.Helpers
{
	public interface IParameterSessionHelper
	{
		IEnumerable<ParameterDetail> GetParameters(string key);
		void SetParameters(string key, IEnumerable<ParameterDetail> parameters);
	}
}
