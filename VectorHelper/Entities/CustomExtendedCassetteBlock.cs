using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.Utils;
using VectorHelper.Utils;

namespace VectorHelper.Entities
{
	[Tracked(true)]
	[TrackedAs(typeof(CassetteBlock), true)]
	[CustomEntity("VectorHelper/CustomExtendedCassetteBlock")]
	public class CustomExtendedCassetteBlock : ExtendedCassetteBlock
	{
		public string activeSprite, inactiveSprite;
		public bool customDisabledColor;
		private string inactiveColor;
		public CustomExtendedCassetteBlock(EntityData data, Vector2 offset, EntityID id) : this(data.Position + offset, id, data.Width, data.Height, data.Int("index", 0), data.Float("tempo", 1f), data.Attr("color"), data.Attr("inactiveColor"), data.Attr("activeSprite"), data.Attr("inactiveSprite"), data.Int("surfaceSoundIndex"))
		{
		}

		public CustomExtendedCassetteBlock(Vector2 position, EntityID id, int width, int height, int index, float tempo, string color = "ffffff", string inactiveColor = "Default", string activeSprite = "objects/cassetteblock/solid", string inactiveSprite = "objects/cassetteblock/pressed00", int surfaceSoundIndex = 35) : base(position, id, width, height, index, tempo)
		{
			cassetteData = new DynamicData(this);

			Index = index;
			if (Lists.Colors.ContainsKey(color)) cassetteData.Set("color", Lists.Colors[color]);
			else cassetteData.Set("color", Calc.HexToColor(color));

			if (inactiveColor != "Default")
			{
				customDisabledColor = true;
				this.inactiveColor = inactiveColor;
			}
			SurfaceSoundIndex = surfaceSoundIndex;
			Tempo = tempo;

			this.activeSprite = activeSprite;
			this.inactiveSprite = inactiveSprite;
		}

		public static void Load()
		{
			IL.Celeste.CassetteBlock.Awake += CassetteBlock_Awake;
		}

		public static void Unload()
		{
			IL.Celeste.CassetteBlock.Awake -= CassetteBlock_Awake;
		}

		private static void CassetteBlock_Awake(ILContext il)
		{
			ILCursor cursor = new ILCursor(il);
			
			// Find the 9th call instruction

			Console.WriteLine(cursor.TryGotoNext(MoveType.After, instr => instr.MatchCall<Color>("get_Color")));
		}
	}
}