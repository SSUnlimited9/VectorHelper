using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

namespace VectorHelper
{
	public class VectorHelperSession : EverestModuleSession
	{
		// Basically the same as "SaveData" but for session save data
		public Dictionary<string, Dictionary<string, object>> Variables { get; set; } = new Dictionary<string, Dictionary<string, object>>();
		public Dictionary<string, Dictionary<string, object[]>> Arrays { get; set; } = new Dictionary<string, Dictionary<string, object[]>>();
		public Dictionary<string, Dictionary<string, List<object>>> Lists { get; set; } = new Dictionary<string, Dictionary<string, List<object>>>();
		public Dictionary<string, Dictionary<string, Dictionary<object, object>>> Dictionaries { get; set; } = new Dictionary<string, Dictionary<string, Dictionary<object, object>>>();		
	}
}