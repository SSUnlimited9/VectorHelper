using System.Collections.Generic;
using Celeste.Mod;

namespace VectorHelper
{
	public class VectorHelperSettings : EverestModuleSettings
	{
		[SettingIgnore]
		public Dictionary<string, decimal> SettingsTest { get; set; } = new Dictionary<string, decimal>();
	}
}