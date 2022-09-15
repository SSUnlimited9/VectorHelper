using Microsoft.Xna.Framework;
using Monocle;

namespace VectorHelper
{
	public class VectorHelperCommands
	{
		[Command("set_variable", "Set variable help text")]
		public static void SetVariable()
		{
			object test = "Setting variable";
			Engine.Commands.Log(test.ToString(), Color.Lime);
			Engine.Commands.Log(test.ToString(), Color.Orange);	
		}
	}
}