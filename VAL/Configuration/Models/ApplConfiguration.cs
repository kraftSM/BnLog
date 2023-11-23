namespace BnLog.VAL.Configuration.Models
	{
	public class ApplConfiguration // ApplConfig
		{
		public string Name { get; set; } = "BnLog 000";
		public string Version { get; set; } = "Ver 0.0.0 from 2023-11-01";
		public bool dbIsPreladed { get; set; } = true; // признак загрузки начальных полей в DB (для разработки)
		public bool onDevelopmentMode { get; set; } = true; // =true признак режима разработки/ = false Production
		public bool onDesignMode { get; set; } = false; // признак субрежима Design

		}
	}
