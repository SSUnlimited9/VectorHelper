using System;
using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

namespace VectorHelper
{
	public class VectorHelperSaveData : EverestModuleSaveData
	{
		/* DataType: Name, Value */
		public Dictionary<string, Dictionary<string, object>> Variables { get; set; } = new Dictionary<string, Dictionary<string, object>>();
		
		/* DataType: Name, Value(s) */
		public Dictionary<string, Dictionary<string, object[]>> Arrays { get; set; } = new Dictionary<string, Dictionary<string, object[]>>();
		
		/* DataType: Name, Value(s) */
		public Dictionary<string, Dictionary<string, List<object>>> Lists { get; set; } = new Dictionary<string, Dictionary<string, List<object>>>();
		
		/* DataType: Name, Key(s), Value(s) */
		public Dictionary<string, Dictionary<string, Dictionary<object, object>>> Dictionaries { get; set; } = new Dictionary<string, Dictionary<string, Dictionary<object, object>>>();

		/// <summary>
		/// Assign's a variable (and value) to VectorHelper's Variable Dictionary SaveData)
		/// Name, Data Type, Type, Value, Array Length (if applicable)
		/// </summary>
		public void SetVariable(string VariableName, string DataType = "String", string Type = "Variable", string Value = "", string ArrayLength = "")
		{
		}
	}
}