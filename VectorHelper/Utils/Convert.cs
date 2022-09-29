using System;
using Microsoft.Xna.Framework;

namespace VectorHelper.Utils
{
	public class Converter
	{
		public class Variables
		{
			public static object ConvertValueByType(string value, Variable.DataType dataType)
			{
				switch (dataType)
				{
					case Variable.DataType.Char:
						try {
							return Convert.ToChar(value);
						} catch {
							return ' ';
						}
					case Variable.DataType.SByte:
						try {
							return Convert.ToSByte(value);
						} catch {
							return (sbyte)0;
						};
					case Variable.DataType.Byte:
						try {
							return Convert.ToByte(value);
						} catch {
							return (byte)0;
						};
					case Variable.DataType.Short:
						try {
							return Convert.ToInt16(value);
						} catch {
							return (short)0;
						};
					case Variable.DataType.UShort:
						try {
							return Convert.ToUInt16(value);
						} catch {
							return (ushort)0;
						};
					case Variable.DataType.Int:
						try {
							return Convert.ToInt32(value);
						} catch {
							return (int)0;
						};
					case Variable.DataType.UInt:
						try {
							return Convert.ToUInt32(value);
						} catch {
							return (uint)0;
						};
					case Variable.DataType.Long:
						try {
							return Convert.ToInt64(value);
						} catch {
							return (long)0L;
						};
					case Variable.DataType.ULong:
						try {
							return Convert.ToUInt64(value);
						} catch {
							return (ulong)0L;
						};
					case Variable.DataType.Float:
						try {
							return Convert.ToSingle(value);
						} catch {
							return 0f;
						};
					case Variable.DataType.Double:
						try {
							return Convert.ToDouble(value);
						} catch {
							return 0d;
						};
					case Variable.DataType.Decimal:
						try {
							return Convert.ToDecimal(value);
						} catch {
							return 0m;
						};
					case Variable.DataType.Bool:
						try {
							return Convert.ToBoolean(value);
						} catch {
							return false;
						};
					case Variable.DataType.Vector2:
						try {
							float[] vector2 = Array.ConvertAll(value.Split(':'), float.Parse);
							return new Vector2(vector2[0], vector2[1]);
						} catch {
							return Vector2.Zero;
						};
					case Variable.DataType.Vector3:
						try {
							float[] vector3 = Array.ConvertAll(value.Split(':'), float.Parse);
							return new Vector3(vector3[0], vector3[1], vector3[2]);
						} catch {
							return Vector3.Zero;
						};
					case Variable.DataType.Vector4:
						try {
							float[] vector4 = Array.ConvertAll(value.Split(':'), float.Parse);
							return new Vector4(vector4[0], vector4[1], vector4[2], vector4[3]);
						} catch {
							return Vector4.Zero;
						};
					case Variable.DataType.Color:
						try {
							byte[] color = Array.ConvertAll(value.Split(':'), byte.Parse);
							if (color.Length == 3)
							{
								return new Color(color[0], color[1], color[2]);
							}
							return new Color(color[0], color[1], color[2], color[3]);
						} catch {
							return Color.White;
						};
					case Variable.DataType.EntityData:
						// Return null since "EntityData" is a special type case thing
						return null;
					// This applies to String, Object and Dynamic
					default:
						return value;
				}
			}

			public static Variable.DataType ConvertDataTypeEnum(string DataType)
			{
				Variable.DataType dataType;
				if (Enum.TryParse(DataType.Trim().ToLower(), out dataType))
				{
					return dataType;
				}
				else
				{
					return Variable.DataType.String;
				}
			}

			public static Variable.Type ConvertTypeEnum(string Type)
			{
				Variable.Type type;
				if (Enum.TryParse(Type.Trim().ToLower(), out type))
				{
					return type;
				}
				else
				{
					return Variable.Type.Variable;
				}
			}
		}
	}
}