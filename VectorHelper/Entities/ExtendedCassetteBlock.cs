using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;

namespace VectorHelper.Entities
{
	[Tracked(true)]
	[TrackedAs(typeof(CassetteBlock), true)]
	[CustomEntity("VectorHelper/ExtendedCassetteBlock")]
	public class ExtendedCassetteBlock : CassetteBlock
	{
		public DynamicData cassetteData;
		public EntityData data;
		public EntityID id;
		private static bool cassetteBlockAdded = false;
		public ExtendedCassetteBlock(EntityData data, Vector2 offset, EntityID id) : this(data.Position + offset, id, data.Width, data.Height, data.Int("index", 0), data.Float("tempo", 1f))
		{
			this.data = data;
			this.id = id;
		}
		public ExtendedCassetteBlock(Vector2 position, EntityID id, int width, int height, int index, float tempo) : base(position, id, width, height, index, tempo)
		{
			cassetteData = new DynamicData(this);

			Index = index;
			Tempo = tempo;

			Color color;
			switch (index)
			{
				default: /* Blue */ color = Calc.HexToColor("49aaf0"); break;
				case 1: /* Rose */ color = Calc.HexToColor("f049be"); break;
				case 2: /* Bright Sun */ color = Calc.HexToColor("fcdc3a"); break;
				case 3: /* Malachite */ color = Calc.HexToColor("38e04e"); break;
				case 4: /* Navy Blue */ color = Calc.HexToColor("000080"); break;
				case 5: /* Scarlet */ color = Calc.HexToColor("ff2200"); break;
				case 6: /* Tangerine */ color = Calc.HexToColor("f28500"); break;
				case 7: /* Phthalo */ color = Calc.HexToColor("123524"); break;
				case 8: /* Indigo */ color = Calc.HexToColor("4c0082"); break;
				case 9: /* Maroon */ color = Calc.HexToColor("800000"); break;
				case 10: /* Burnt Orange */ color = Calc.HexToColor("cc5500"); break;
				case 11: /* Shamrock Green */ color = Calc.HexToColor("009664"); break;
				case 12: /* White */ color = Calc.HexToColor("ffffff"); break;
				case 13: /* Light Black */ color = Calc.HexToColor("1b1b1b"); break;
				case 14: /* Light Cyan */ color = Calc.HexToColor("00fff7"); break;
				case 15: /* Brown */ color = Calc.HexToColor("4d360b"); break;
			}

			cassetteData.Set("color", color);
			cassetteData.Add("isExtended", true);
		}

		private static IDetour hook_Level_orig_LoadLevel;
		public static void Load()
		{
			On.Celeste.CassetteBlock.SetImage += CassetteBlock_SetImage;
			On.Celeste.CassetteBlock.ShiftSize += CassetteBlock_ShiftSize;
			Everest.Events.Level.OnLoadEntity += OnLoadEntity;
		}
		public static void Unload()
		{
			On.Celeste.CassetteBlock.SetImage -= CassetteBlock_SetImage;
			On.Celeste.CassetteBlock.ShiftSize -= CassetteBlock_ShiftSize;
			Everest.Events.Level.OnLoadEntity -= OnLoadEntity;
		}

		private static void CassetteBlock_SetImage(On.Celeste.CassetteBlock.orig_SetImage orig, CassetteBlock self, float x, float y, int tx, int ty)
		{
			DynamicData data = new DynamicData(self);

			string activeSprite = "";
			string inactiveSprite = "";
			if (self is ExtendedCassetteBlock && self is not CustomExtendedCassetteBlock)
			{
				ExtendedCassetteBlock block = (ExtendedCassetteBlock)self;
				int i = block.Index % 15;
				activeSprite = "objects/cassetteblock/solid";
				inactiveSprite =  i < 4 ? "objects/cassetteblock/pressed0" + i : i < 10 ? "VectorHelper/cassetteBlock/extended0" + i :
				i < 15 ? "VectorHelper/cassetteBlock/extended" + i : "VectorHelper/cassetteBlock/empty";
			}

			if (self is CustomExtendedCassetteBlock)
			{
				activeSprite = data.Get<string>("activeSprite");
				inactiveSprite = data.Get<string>("inactiveSprite");
			}

			if (activeSprite != "" && inactiveSprite != "")
			{
				data.Get<List<Image>>("pressed").Add(data.Invoke<Image>("CreateImage", x, y, tx, ty, GFX.Game[inactiveSprite]));
				data.Get<List<Image>>("solid").Add(data.Invoke<Image>("CreateImage", x, y, tx, ty, GFX.Game[activeSprite]));
				return;
			}

			orig(self, x, y, tx, ty);
		}

		private static void CassetteBlock_ShiftSize(On.Celeste.CassetteBlock.orig_ShiftSize orig, CassetteBlock self, int amount)
		{
			DynamicData data = DynamicData.For(self);
			foreach (CassetteBlock block in data.Get<List<CassetteBlock>>("group"))
			{
				if (!VectorHelper.Module.VectorHelperModule.Settings.CassetteRiseFix) break;

				// Makes any cassetteblock and those extending cassetteblock shift down (properly) if the player is inside it
				// Communal Helper Custom Cassette Blocks also do this but with a bit extra stuff
				if (block.Activated && block.CollideCheck<Player>())
				{
					amount *= -1;
				}
			}
			orig(self, amount);
		}

		private static bool OnLoadEntity(Level level, LevelData levelData, Vector2 offset, EntityData entityData)
		{
			level.CassetteBlockBeats = Math.Max(entityData.Int("index", 0) + 1, level.CassetteBlockBeats);
			level.CassetteBlockTempo = Math.Max(entityData.Float("tempo", 0f), level.CassetteBlockTempo);
			return false;
		}
	}
}