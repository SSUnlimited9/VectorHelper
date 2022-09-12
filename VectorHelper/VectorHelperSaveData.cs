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
		public void SetVariable(string VariableName, VHEnums.DataType DataType = VHEnums.DataType.String, VHEnums.VariableType Type = VHEnums.VariableType.Variable, string Value = "", string ArrayLength = "")
		{
			object ActualValue = null;
			try
			{
				switch (DataType)
				{
					default:
					case VHEnums.DataType.String:
						ActualValue = Value;
						break;
					case VHEnums.DataType.Float:
						ActualValue = Converter.SpecialFloat(Value);
						break;
				}
			}
			catch (Exception e)
			{
				
			}
			switch (Type)
			{
				case VHEnums.VariableType.Variable:
					Variables[DataType.ToString()].Add(VariableName, ActualValue);
					break;
			}
		}
	}
}