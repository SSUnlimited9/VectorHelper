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
		public ExtendedCassetteController(EntityData data, Vector2 offset, EntityID id) : this(data.Position + offset, id, data.Int("overrideMode"), data.Int("startIndex"), data.Bool("skipEmptyIndexes"), data.Attr("customOrder"))
		{
		}
		public ExtendedCassetteController(Vector2 position, EntityID id, int overrideMode, int startIndex, bool skipEmptyIndexes, string customOrder) : base()
		{
		}
	}
}