using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

namespace VectorHelper.Module
{
	public class VectorHelperSaveData : EverestModuleSaveData
	{
		public Dictionary<object, Dictionary<string, object>> Variables = new Dictionary<object, Dictionary<string, object>>();
		public Dictionary<object, Dictionary<string, object[]>> Arrays = new Dictionary<object, Dictionary<string, object[]>>();
		public Dictionary<object, Dictionary<string, List<object>>> Lists = new Dictionary<object, Dictionary<string, List<object>>>();
		public Dictionary<object, Dictionary<string, Dictionary<object, object>>> Dictionaries = new Dictionary<object, Dictionary<string, Dictionary<object, object>>>();

		public Dictionary<string, VariableProperties> VariableProperties = new Dictionary<string, VariableProperties>();

		public void SetVariable(string VariableName, object Value = null, Variable.DataType DataType = Variable.DataType.String, Variable.Type Type = Variable.Type.Variable)
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
						Logger.Log(LogLevel.Info, "VectorHelper/Variables", $"Reset \"{DataType.ToString()}\"");
					} else
					{
						Variables[DataType].Add(VariableName, value);
					}
					break;
				case Variable.Type.Array: break;
				case Variable.Type.List: break;
				case Variable.Type.Dictionary: break;
			}

			if (hadKey)
			{
				
			}
		}
	}
}