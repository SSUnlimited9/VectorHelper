using System.Collections.Generic;
using System.Linq;
using Celeste;
using Celeste.Mod;
using Monocle;

namespace VectorHelper.Module
{
	public class VectorHelperCommands
	{
		[Command("set_variable", "set a var in dictionary")]
		public static void CMDSETVARIABLE(string Name)
		{
			VectorHelperModule.SaveData.SetVariable(Name);
		}	


		[Command("count_entities", "get the total number of entities in the level")]
		public static void CMDCOUNTENTITIES()
		{
			Level level = Engine.Scene as Level;
			uint totalEntities = (uint)level.Entities.ToList<Entity>().Count;
			uint entities = 0;
			uint triggers = 0;
			foreach (Entity entity in level)
			{
				if (entity is Trigger)
				{
					triggers++;
				} else
				{
					entities++;
				}
			}

			Engine.Commands.Log(totalEntities + " Entities are in the level");
			Engine.Commands.Log(triggers +" are Triggers");
			Engine.Commands.Log(entities +" are Entities");
			Logger.Log(LogLevel.Info, "VectorHelper/Commands", $"There are {totalEntities} Entities in the level with {triggers} being Triggers and {entities} being non-Trigger Entities");
		}
	}
}
