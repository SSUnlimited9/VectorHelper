using System;
using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

namespace VectorHelper.Module
{
	public class VectorHelperSaveData : EverestModuleSaveData
	{
		public Dictionary<Variable.DataType, Dictionary<string, object>> Variables = new Dictionary<Variable.DataType, Dictionary<string, object>>();
		public Dictionary<Variable.DataType, Dictionary<string, object[]>> Arrays = new Dictionary<Variable.DataType, Dictionary<string, object[]>>();
		public Dictionary<Variable.DataType, Dictionary<string, List<object>>> Lists = new Dictionary<Variable.DataType, Dictionary<string, List<object>>>();
		public Dictionary<Variable.DataType, Dictionary<string, Dictionary<object, object>>> Dictionaries = new Dictionary<Variable.DataType, Dictionary<string, Dictionary<object, object>>>();

		public Dictionary<string, VariableProperties> VariableProperties = new Dictionary<string, VariableProperties>();

		public void SetVariable(string VariableName, string Value = null, Variable.DataType DataType = Variable.DataType.String, Variable.Type Type = Variable.Type.Variable, int ArrayLength = 1)
		{
			if (DataType == Variable.DataType.Any) DataType = Variable.DataType.String;
			bool hadKey = false;

			switch (Type)
			{
				default:
					object value = VUtils.Convert.ValueByDataType(Value, DataType);
					if (Variables[DataType].ContainsKey(VariableName))
					{
						hadKey = true;
						Variables[DataType][VariableName] = value;
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Reset \"{VariableName}\" in \"Variables\"");
					} else
					{
						Variables[DataType].Add(VariableName, value);
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Added \"{VariableName}\" in \"Variables\"");
					}
					break;
				case Variable.Type.Array:
					string[] array = new string[ArrayLength];
					foreach(string s in Value.Split(','))
					{
						try { array[Array.IndexOf(array, s)] = s; }
						catch { break; } // The array is full leave the loop.
					}
					object[] valueArray = new object[ArrayLength];
					valueArray = Array.ConvertAll<string, object>(array, s => VUtils.Convert.ValueByDataType(s, DataType));
					if (Arrays[DataType].ContainsKey(VariableName))
					{
						hadKey = true;
						Arrays[DataType][VariableName] = valueArray;
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Reset \"{VariableName}\" in \"Arrays\"");
					} else
					{
						Arrays[DataType].Add(VariableName, valueArray);
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Added \"{VariableName}\" in \"Arrays\"");
					}
					break;
				case Variable.Type.List:
					List<object> valueList = new List<object>();
					foreach (string s in Value.Split(','))
					{
						valueList.Add(VUtils.Convert.ValueByDataType(s, DataType));
					}
					if (Lists[DataType].ContainsKey(VariableName))
					{
						hadKey = true;
						Lists[DataType][VariableName] = valueList;
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Reset \"{VariableName}\" in \"Lists\"");
					} else
					{
						Lists[DataType].Add(VariableName, valueList);
						Logger.Log(LogLevel.Info, "VectorHelper/ExFlags", $"Added \"{VariableName}\" in \"Lists\"");
					}
					break;
				case Variable.Type.Dictionary: break;
			}

			if (hadKey)
			{
				
			}
		}
	}
}