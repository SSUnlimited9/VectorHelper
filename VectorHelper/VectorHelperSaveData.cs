using System;
using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Library;

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
		public void SetVariable(string VariableName, Lib.DataType DataType = Lib.DataType.String, Lib.VariableType Type = Lib.VariableType.Variable, string Value = "", string ArrayLength = "")
		{
			object ActualValue = null;
			try
			{
				switch (DataType)
				{
					default:
					case Lib.DataType.String:
						ActualValue = Value;
						break;
					case Lib.DataType.Float:
						ActualValue = VectorHelperConvert.SpecialFloat(Value);
						break;
				}
			}
			catch (Exception e)
			{
				
			}
			switch (Type)
			{
				case Lib.VariableType.Variable:
					Variables[DataType.ToString()].Add(VariableName, ActualValue);
					break;
			}
		}
	}
}