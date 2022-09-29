using Celeste;
using Microsoft.Xna.Framework;
using Monocle;
using VectorHelper.Utils;

namespace VectorHelper
{
	public class VectorHelperCommands
	{
		[Command("vh_sv", "undefined")]
		public static void VectorHelperSetVariableTest(string variableName, string value, string dataType = "String", string type = "Variable")
		{
			Variable.DataType dataTypeEnum = (Variable.DataType)System.Enum.Parse(typeof(Variable.DataType), dataType);
			Variable.Type typeEnum = (Variable.Type)System.Enum.Parse(typeof(Variable.Type), type);
			VectorHelperModule.SaveData.SetVariable(variableName, value, dataTypeEnum, typeEnum);
		}

		[Command("vh_demo", "Demo (vh)")]
		public static void VectorHelperTest(float num)
		{
			Engine.Commands.Log((num * 2));
		}

		[Command("vh_give_goldens", "Give multiple golden strawberries (Vector Helper)")]
		public static void GiveMultipleGoldens(int amount)
		{
			Level level = Engine.Scene as Level;
			Player player = level.Tracker.GetEntity<Player>();
			if (level != null && player != null)
			{
				for (int i = 0; i < amount; i++)
				{
					EntityData entityData = new EntityData();
					entityData.Position = player.Position + new Vector2(0f, -16f);
					entityData.ID = Calc.Random.Next();
					entityData.Name = "goldenBerry";
					EntityID id = new EntityID(level.Session.Level, entityData.ID);
					Strawberry strawberry = new Strawberry(entityData, Vector2.Zero, id);
					level.Add(strawberry);
				}
			}
		}

		[Command("count_total_followers", "Returns the amount of followers the player has (Vector Helper)")]
		public static void CountTotalFollowers()
		{
			Level level = Engine.Scene as Level;
			Player player = level.Tracker.GetEntity<Player>();
			Engine.Commands.Log(player.Leader.Followers.Count, Color.Yellow);
		}
	}
		/*
		// Simple command to test and maybe use the SetVariable function
		[Command("set_variable", "Set variable help text")]
		public static void CMDSetVariable(string Name, string DataType = "String", string Type = "Variable", string Value = "", string ArrayLength = "1")
		{
			VHFuncs.SaveData.SetVariable(Name, DataType, Type, Value, ArrayLength);
		}

		// Get a variable value and log it
		[Command("get_variable", "Get variable help text")]
		public static void CMDGetVariable(string Name, string DataType = "String", string Type = "Variable", string ArrayIndex = "0")
		{
			object mainValue = VHFuncs.SaveData.GetVariable(Name, DataType, Type, ArrayIndex);
			Engine.Commands.Log(mainValue, Color.Lime);
		}
	}*/
}