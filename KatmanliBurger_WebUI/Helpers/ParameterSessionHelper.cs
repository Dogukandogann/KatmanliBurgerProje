using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_SERVICE.Services.ParameterServices;
using KatmanliBurger_UI.Extensions;
using Microsoft.AspNetCore.Http;

namespace KatmanliBurger_UI.Helpers
{
	public class ParameterSessionHelper : IParameterSessionHelper
	{
		IHttpContextAccessor _httpContextAccessor;
		IParameterService _parameterService;

		public ParameterSessionHelper(IHttpContextAccessor httpContextAccessor, IParameterService parameterService)
		{
			_httpContextAccessor = httpContextAccessor;
			_parameterService = parameterService;
		}
		public IEnumerable<ParameterDetail> GetParameters(string key)
		{
			var parameters = _httpContextAccessor.HttpContext.Session.GetObject<IEnumerable<ParameterDetail>>(key);
			if (parameters == null || !parameters.Any())
			{
				
				parameters = _parameterService.GetAll();
				SetParameters(key, parameters); // Session'a ekle
			}

			return parameters;
		}

		public void SetParameters(string key, IEnumerable<ParameterDetail> parameters)
		{
			_httpContextAccessor.HttpContext.Session.SetObject(key, parameters);
		}
	}
}
