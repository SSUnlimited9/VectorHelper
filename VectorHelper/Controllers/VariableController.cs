using System.Collections;
using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using VectorHelper;
using VectorHelper.Utils;

namespace VectorHelper.Entities.Controllers
{
	[CustomEntity("VectorHelper/VariableController")]
	public class VariableController : Entity
	{
		private VHEnums.VariableType type;
		private VHEnums.DataType dataType;
		private VHEnums.SaveModes variableFor;
		private VHEnums.OnlyOnceModes onlyOnce;
		private VHEnums.TriggerModes setMode;
		private string variableName, value, arrayLength;
		private string roomName;
		private EntityID entityID;

		public VariableController(EntityData data, Vector2 offset, EntityID id) : base(data.Position + offset)
		{
			type = data.Enum("type", VHEnums.VariableType.Variable);
			dataType = data.Enum("dataType", VHEnums.DataType.String);
			variableName = data.Attr("variableName", "myVariable");
			value = data.Attr("value", "");
			variableFor = data.Enum("variableFor", VHEnums.SaveModes.SaveData);
			onlyOnce = data.Enum("onlyOnce", VHEnums.OnlyOnceModes.False);
			setMode = data.Enum("setMode", VHEnums.TriggerModes.OnLevelStart);
			arrayLength = data.Attr("arrayLength", "1");
		}

		public override void Added(Scene scene)
		{
			base.Added(scene);
		}

		public override void Awake(Scene scene)
		{
			base.Awake(scene);
		}

		private static void onRoomChange(On.Celeste.Level.orig_TransitionTo orig, Level level, LevelData next, Vector2 direction)
		{
			orig(level, next, direction);
		}

		public static void Load()
		{
			// Subscribe to the room/scene/level change event
			On.Celeste.Level.TransitionTo += onRoomChange;
		}

		public static void Unload()
		{
			On.Celeste.Level.TransitionTo -= onRoomChange;
		}
	}
}