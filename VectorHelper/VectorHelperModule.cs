using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;

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
			/* Naming it onChapterEnter for reasons (I looked a the log when testing stuff) */
			On.Celeste.LevelEnter.Go += onChapterEnter;
		}

		public override void Unload()
		{
			On.Celeste.LevelEnter.Go -= onChapterEnter;
		}

		private void onChapterEnter(On.Celeste.LevelEnter.orig_Go orig, Session session, bool fromSaveData)
		{
			orig(session, fromSaveData);
			ShortFunctions.SaveData.VerifyVariablesDictionary();
			ShortFunctions.SaveData.VerifyArraysDictionary();
			ShortFunctions.SaveData.VerifyListsDictionary();
			ShortFunctions.SaveData.VerifyDictionariesDictionary();
		}
	}
}