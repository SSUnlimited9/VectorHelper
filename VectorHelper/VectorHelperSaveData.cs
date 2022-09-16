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

		/// <summary>
		/// Assign's a variable (and value) to VectorHelper's Variable Dictionary SaveData)
		/// <paramref name="VariableName"/>: The variable name,
		/// <paramref name="DataType"/>: The type of data the variable will store (From <see cref="VectorHelper.Utils.VHEnums.DataType"/>),
		/// <paramref name="Type"/>: The form of variable? (Either Variable, Array, List, or Dictionary) (From <see cref="VectorHelper.Utils.VHEnums.VariableType"/>),
		/// <paramref name="Value"/>: The value of the variable (This is a string, and will be converted to the correct data type),
		/// <paramref name="ArrayLength"/>: The length of the array (Only used if <paramref name="Type"/> is Array (<see cref="VectorHelper.Utils.VHEnums.VariableType.Array"/>))
		/// </summary>
		public void SetVariable(string VariableName, VHEnums.DataType DataType = VHEnums.DataType.String, VHEnums.VariableType Type = VHEnums.VariableType.Variable, string Value = "", string ArrayLength = "")
		{
			switch (Type)
			{
				case VHEnums.VariableType.Variable:
					
					break;
			}
		}
	}
}