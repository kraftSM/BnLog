using Microsoft.AspNetCore.Identity;
using BnLog.BLL.Services.IService;
using BnLog.VAL.Services.IService;

namespace BnLog.VAL.Services
	{
	public class ApplConfigurationService //: IApplConfigurationService
		{

		private bool dbLoaded  {get; set;} = false; // признак первичной загрузки DB
		private bool onDevelopmentMode { get; set; } = false; // признак режима разработки
		private bool onProductionMode { get; set; } = false; // признак режима Production

		}
	}
