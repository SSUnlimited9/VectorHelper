using System;
using Celeste;
using Celeste.Mod;
using MonoMod.ModInterop;
using Microsoft.Xna.Framework;
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
			On.Celeste.Player.ctor += Player_ctor;
			On.Celeste.LevelEnter.Go += LevelEnter_Go;
			ExtendedCassetteBlock.Load();
			CustomExtendedCassetteBlock.Load();
		}

		public override void Unload()
		{
			On.Celeste.Player.ctor -= Player_ctor;
			On.Celeste.LevelEnter.Go -= LevelEnter_Go;
			ExtendedCassetteBlock.Unload();
			CustomExtendedCassetteBlock.Unload();
		}

		private void Player_ctor(On.Celeste.Player.orig_ctor orig, Player self, Vector2 position, PlayerSpriteMode spriteMode)
		{
			orig(self, position, spriteMode);
			// Verify the Extended Flag Dictionaries
			VectorHelper.Utils.VUtils.VerifyExFlagDictionaries();
		}

		private void LevelEnter_Go(On.Celeste.LevelEnter.orig_Go orig, Session session, bool fromSaveData)
		{
			orig(session, fromSaveData);
			// Verify the Extended Flag Dictionaries
			// VectorHelper.Utils.VUtils.VerifyExFlagDictionaries();
		}
	}
}