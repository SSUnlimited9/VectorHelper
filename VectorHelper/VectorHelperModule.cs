using System;
using Celeste;
using Celeste.Mod;
using MonoMod.ModInterop;
using VectorHelper.API;
using VectorHelper.Entities;

namespace VectorHelper.Module
{
	public class VectorHelperModule : EverestModule
	{
		public static VectorHelperModule Instance { get; private set; }

		public override Type SaveDataType => typeof(VectorHelperSaveData);
		public static VectorHelperSaveData SaveData => (VectorHelperSaveData) Instance._SaveData;

		public override Type SettingsType => typeof(VectorHelperSettings);
		public static VectorHelperSettings Settings => (VectorHelperSettings) Instance._Settings;

		public VectorHelperModule()
		{
			Instance = this;
		}

		public override void Load()
		{
			Logger.SetLogLevel("VectorHelper", LogLevel.Verbose);
			typeof(VectorHelperExports).ModInterop();
			On.Celeste.LevelEnter.Go += LevelEnter_Go;
			ExtendedCassetteBlock.Load();
			CustomExtendedCassetteBlock.Load();
		}

		public override void Unload()
		{
			On.Celeste.LevelEnter.Go -= LevelEnter_Go;
			ExtendedCassetteBlock.Unload();
			CustomExtendedCassetteBlock.Unload();
		}

		private void LevelEnter_Go(On.Celeste.LevelEnter.orig_Go orig, Session session, bool fromSaveData)
		{
			orig(session, fromSaveData);
			// Verify the Extended Flag Dictionaries
		}
	}
}