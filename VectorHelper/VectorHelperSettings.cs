using Celeste.Mod;

namespace VectorHelper
{
	public class VectorHelperSettings : EverestModuleSettings
	{
		[SettingName("MODSETTINGS_VECTORHELPER_CASSETTEBLOCK_RISEFIX"), SettingSubText("MODSETTINGS_VECTORHELPER_CASSETTEBLOCK_RISEFIX_DESCRIPTION")]
		public bool CassetteRiseFix { get; set;}
	}
}