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
		private string type, dataType, variableName, value, variableFor, onlyOnce, setMode, arrayLength;
		private string roomName;
		private EntityID entityID;

		public VariableController(EntityData data, Vector2 offset, EntityID id) : base(data.Position + offset)
		{
			type = data.Enum("type", VHEnums.VariableType.Variable).ToString();
			dataType = data.Enum("dataType", VHEnums.DataType.String).ToString();
			variableName = data.Attr("variableName", "myVariable");
			value = data.Attr("value", "");
			variableFor = data.Enum("variableFor", VHEnums.SaveModes.SaveData).ToString();
			onlyOnce = data.Enum("onlyOnce", VHEnums.OnlyOnceModes.False).ToString();
			setMode = data.Enum("setMode", VHEnums.TriggerModes.OnLevelStart).ToString();
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
			On.Celeste.Level.TransitionTo += onRoomChange;
		}

		public static void Unload()
		{
			On.Celeste.Level.TransitionTo -= onRoomChange;
		}
	}
}