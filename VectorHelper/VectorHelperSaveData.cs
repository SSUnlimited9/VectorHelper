using System;
using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

namespace VectorHelper
{
	public class VectorHelperSaveData : EverestModuleSaveData
	{
		// The variable dictionaries are here
		// Adding the data types to the dictionaries is done when loading a chapter in a save file that doesnt already have them
		public Dictionary<string, Dictionary<string, object>> Variables { get; set; } = new Dictionary<string, Dictionary<string, object>>();
		public Dictionary<string, Dictionary<string, object[]>> Arrays { get; set; } = new Dictionary<string, Dictionary<string, object[]>>();
		public Dictionary<string, Dictionary<string, List<object>>> Lists { get; set; } = new Dictionary<string, Dictionary<string, List<object>>>();
		public Dictionary<string, Dictionary<string, Dictionary<object, object>>> Dictionaries { get; set; } = new Dictionary<string, Dictionary<string, Dictionary<object, object>>>();
		// This will contain data for different variable configurations/properties (Array Length, etc)
		public Dictionary<string, Dictionary<string, object>> VariableProperties { get; set; } = new Dictionary<string, Dictionary<string, object>>();

		// Set variables (Basically the main part of VectorHelper Variables)
		public void SetVariable(string VariableName, string Value = "", Variable.DataType DataType = Variable.DataType.String, Variable.Type Type = Variable.Type.Variable, string ArrayLength = "1")
		{
			if (DataType == Variable.DataType.Any) DataType = Variable.DataType.String;
			if (Type == Variable.Type.Any) Type = Variable.Type.Variable;
			string dataType = DataType.ToString();
			switch(Type)
			{
				case Variable.Type.Variable:
					object value 
			}
		}

		public void SetVariable(string VariableName, string Value = "", Variable.DataType DataType = Variable.DataType.String, Variable.Type Type = Variable.Type.Variable, string ArrayLength = "1")
		{
			string dataType = DataType.ToString();
			switch (Type)
			{
				case Variable.Type.Variable:
					object value = Converter.Variables.ConvertValueByType(Value, DataType);
					if (!Variables[dataType].ContainsKey(VariableName))
					{
						Variables[dataType].Add(VariableName, value);
					}
					else
					{
						// The variable (key) already exists, Just update it!
						Variables[dataType][VariableName] = value;
					}
					Logger.Log(LogLevel.Info, "VectorHelper/Variables", $"Successfully set Variable: {VariableName} with value: {Value}");
					break;
			}
		}
	}
}