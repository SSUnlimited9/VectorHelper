using VectorHelper;
using VectorHelper.Utils;

namespace VectorHelper.Utils
{
	public class VHFuncs
	{
		public class SaveData{
			/// <summary>
			/// Assign's a variable (and value) to VectorHelper's Variable Dictionary SaveData)
			/// <paramref name="VariableName"/>: The variable name,
			/// <paramref name="DataType"/>: The type of data the variable will store (From <see cref="VectorHelper.Utils.VHEnums.DataType"/>),
			/// <paramref name="Type"/>: The form of variable? (Either Variable, Array, List, or Dictionary) (From <see cref="VectorHelper.Utils.VHEnums.VariableType"/>),
			/// <paramref name="Value"/>: The value of the variable (This is a string, and will be converted to the correct data type),
			/// <paramref name="ArrayLength"/>: The length of the array (Only used if <paramref name="Type"/> is Array (<see cref="VectorHelper.Utils.VHEnums.VariableType.Array"/>))
			/// </summary>
			// Easier access to the SetVariable function :) )_
			public static void SetVariable(string VariableName, VHEnums.DataType DataType = VHEnums.DataType.String, VHEnums.VariableType Type = VHEnums.VariableType.Variable, string Value = "", string ArrayLength = "1")
			{
				VectorHelperModule.SaveData.SetVariable(VariableName, DataType, Type, Value, ArrayLength);
			}
		}
	}
}