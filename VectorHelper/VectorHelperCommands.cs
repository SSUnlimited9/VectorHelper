using Microsoft.Xna.Framework;
using Monocle;

namespace VectorHelper
{
	public class VectorHelperCommands
	{
		// Simple command to test and maybe use the SetVariable function
		[Command("set_variable", "Set variable help text")]
		public static void SetVariable()
		{
			object test = "Setting variable";
			Engine.Commands.Log(test.ToString(), Color.Lime);
			Engine.Commands.Log(test.ToString(), Color.Orange);	
		}
	}
}