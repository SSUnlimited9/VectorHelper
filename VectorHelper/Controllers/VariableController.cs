using Celeste;
using Celeste.Mod;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;
using VectorHelper.Utils;

namespace VectorHelper.Controllers
{
	[CustomEntity("VectorHelper/VariableController")]
	public class VariableController : Entity
	{
		private string VariableType, DataType, VariableName, Value, VariableFor, OneTime, ArrayLength;
		private int cvId;

		public VariableController(EntityData data, Vector2 offset) : base(data.Position + offset)
		{
			cvId = data.ID;
			VariableType = data.Enum("type", VHEnums.VariableType.Variable).ToString();
		}

		public override void Added(Scene scene)
		{
			base.Added(scene);
			Level level = SceneAs<Level>();
			if (OneTime == "Session")
			{
				// if (level.Session.GetFlag("vh_variablecontroller_" + cvId))
			}
		}
	}
}