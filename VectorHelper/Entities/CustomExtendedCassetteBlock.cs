using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using MonoMod.Utils;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

namespace VectorHelper.Entities
{
	[Tracked(true)]
	[TrackedAs(typeof(CassetteBlock), true)]
	[CustomEntity("VectorHelper/CustomExtendedCassetteBlock")]
	public class CustomExtendedCassetteBlock : ExtendedCassetteBlock
	{
		public string activeSprite, inactiveSprite;
		public CustomExtendedCassetteBlock(EntityData data, Vector2 offset, EntityID id) : this(data.Position + offset, id, data.Width, data.Height, data.Int("index", 0), data.Float("tempo", 1f), data.Attr("color"), data.Attr("activeSprite"), data.Attr("inactiveSprite"), data.Int("surfaceSoundIndex"))
		{
			this.data = data;
			this.id = id;
		}

		public CustomExtendedCassetteBlock(Vector2 position, EntityID id, int width, int height, int index, float tempo, string color = "ffffff", string activeSprite = "objects/cassetteblock/solid", string inactiveSprite = "objects/cassetteblock/pressed00", int surfaceSoundIndex = 35) : base(position, id, width, height, index, tempo)
		{
			cassetteData = new DynamicData(this);

			Index = index;
			cassetteData.Set("color", Calc.HexToColor(color));
			SurfaceSoundIndex = surfaceSoundIndex;
			Tempo = tempo;

			this.activeSprite = activeSprite;
			this.inactiveSprite = inactiveSprite;
		}
	}
}