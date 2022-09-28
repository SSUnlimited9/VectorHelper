using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;
using Microsoft.Xna.Framework;
using VectorHelper.Utils;
using VectorHelper.Entities.Controllers;

namespace VectorHelper
{
	public class VectorHelperModule : EverestModule
	{
		public static VectorHelperModule Instance;

		public override Type SettingsType => typeof(VectorHelperSettings);
		public static VectorHelperSettings Settings => (VectorHelperSettings) Instance._Settings;

		public override Type SaveDataType => typeof(VectorHelperSaveData);
		public static VectorHelperSaveData SaveData => (VectorHelperSaveData) Instance._SaveData;

		public override Type SessionType => typeof(VectorHelperSession);
		public static VectorHelperSession Session => (VectorHelperSession) Instance._Session;

		public VectorHelperModule()
		{
			Instance = this;
		}

		public override void Load()
		{
			// Make sure that VectorHelper's SaveData contains DataTypes in the dictionaries everytime the player loads a chapter
			On.Celeste.LevelEnter.Go += onChapterEnter;

			// Call Entity, Trigger and such's Load methods (Most of them so they can subscribe to events they need)
			//VariableController.Load();
		}

		public override void Unload()
		{
			// Unsubscribe from events (since thats in basically every mod)
			On.Celeste.LevelEnter.Go -= onChapterEnter;

			//VariableController.Unload();
		}

		private void onChapterEnter(On.Celeste.LevelEnter.orig_Go orig, Session session, bool fromSaveData)
		{
			// Make sure DataTypes are in the dictionaries
			orig(session, fromSaveData);
			SaveDataUtils.VerifyVariablesDictionary();
		}
	}
}