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

		public override Type SaveDataType => typeof(VectorHelperSaveData);
		public static VectorHelperSaveData SaveData => (VectorHelperSaveData) Instance._SaveData;

		public VectorHelperModule()
		{
			Instance = this;
		}

		public override void Load()
		{
			Logger.SetLogLevel("VectorHelper/", LogLevel.Info);
			/* Naming it onChapterEnter for reasons (I looked a the log when testing stuff) */
			On.Celeste.LevelEnter.Go += onChapterEnter;

			/* Get entities and such to Subscribe to events */
			VariableController.Load();
		}

		public override void Unload()
		{
			On.Celeste.LevelEnter.Go -= onChapterEnter;

			VariableController.Unload();
		}

		private void onChapterEnter(On.Celeste.LevelEnter.orig_Go orig, Session session, bool fromSaveData)
		{
			/*
				Make sure SaveData has the data types in the dictionaries
				Everytime the player enters a Map/Chapter/AltSide
			*/
			orig(session, fromSaveData);
			SaveDataUtils.VerifyVariablesDictionary();
			SaveDataUtils.VerifyArraysDictionary();
			SaveDataUtils.VerifyListsDictionary();
			SaveDataUtils.VerifyDictionariesDictionary();
		}
	}
}