using System;
using System.Linq;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Celeste.Mod.Meta;
using Microsoft.Xna.Framework;
using FMOD.Studio;
using Monocle;

namespace VectorHelper.Entities
{
	[Tracked]
	[CustomEntity("VectorHelper/ExtendedCassetteController")]
	public class ExtendedCassetteController : Entity
	{
		private int overrideMode, startIndex, maxIndex;
		private bool skipEmptyIndexes;
		private float tempoMult;
		private List<int> order;

		private bool isLevelMusic;
		private int leadBeats, beatsPerTick, ticksPerSwap, beatIndexMax, beatIndexOffset;
		private EventInstance snapshot;

		public ExtendedCassetteController(EntityData data, Vector2 offset, EntityID id) : this(data.Position + offset, id, data.Int("overrideMode"), data.Int("startIndex"), data.Bool("skipEmptyIndexes"), data.Attr("customOrder"))
		{
		}
		public ExtendedCassetteController(Vector2 position, EntityID id, int overrideMode, int startIndex, bool skipEmptyIndexes, string customOrder) : base()
		{
			this.overrideMode = overrideMode;
			this.skipEmptyIndexes = skipEmptyIndexes;

			this.startIndex = startIndex;

			// order = new List<int>() { startIndex };
			// Add custom order to order split by ,
			// foreach (string s in customOrder.Split(','))
			// {
			// 	if (int.TryParse(s, out int i))
			// 	{
			// 		order.Add(i);
			// 	}
			// }
		}

		public override void Added(Scene scene)
		{
			base.Added(scene);
			if (Scene.Tracker.GetEntities<ExtendedCassetteController>().Count > 1)
			{
				Logger.Log(LogLevel.Warn, "VectorHelper/ExtendedCassetteController", "Multiple ExtendedCassetteControllers found, removing them");
				foreach (ExtendedCassetteController controller in Scene.Tracker.GetEntities<ExtendedCassetteController>())
				{
					// I've seen what happens when there is more than one CassetteBlockManager in a scene, and it's not pretty
					if (controller == this) Logger.Log(LogLevel.Info, "VectorHelper/ExtendedCassetteController", "Found original ExtendedCassetteController, skipping");
					else controller.RemoveSelf();
				}
			}

			foreach (CassetteBlockManager manager in Scene.Tracker.GetEntities<CassetteBlockManager>())
			{
				// Dont need the other managers (We have our own ways)
			}
		}

		public override void Awake(Scene scene)
		{
			base.Awake(scene);
			if (Scene.Tracker.GetEntities<CassetteBlock>().Count < 1)
			{
				Logger.Log(LogLevel.Info, "VectorHelper/ExtendedCassetteController", "No Cassette Blocks found, Removing self");
				RemoveSelf();
			}
		}
	}
}