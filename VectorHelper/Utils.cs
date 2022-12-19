using System;
using System.Collections.Generic;
using Celeste.Mod;
using Microsoft.Xna.Framework;
using VectorHelper.Module;

namespace VectorHelper.Utils
{
	public static class VUtils
	{
		public static class Convert
		{
			public static object ValueByDataType(object value, Variable.DataType dt)
			{
				switch (dt)
				{
					case Variable.DataType.Char:
						char @char = (char)' ';
						try
						{
							@char = char.Parse(value.ToString());
						} catch 
						{ try { @char = char.Parse(value.ToString().Substring(0, 1)); } catch { } }
						return @char;
					case Variable.DataType.SByte:
						sbyte @sbyte = (sbyte)0;
						try
						{
							@sbyte = sbyte.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 5; i++)
							{ try { @sbyte = sbyte.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @sbyte;
					case Variable.DataType.Byte:
						byte @byte = (byte)0;
						try
						{
							@byte = byte.Parse(value.ToString());
						} catch
						{
							// This only searches the first 3 characters of the string.
							// So if the string is something like "NAND24", then it will return 0.
							for (int i = 1; i < 4; i++)
							{ try { @byte = byte.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @byte;
					case Variable.DataType.Short:
						short @short = (short)0;
						try
						{
							@short = short.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 7; i++)
							{ try { @short = short.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @short;
					case Variable.DataType.UShort:
						ushort @ushort = (ushort)0;
						try
						{
							@ushort = ushort.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 6; i++)
							{ try { @ushort = ushort.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @ushort;
					case Variable.DataType.Int:
						int @int = (int)0;
						try
						{
							@int = int.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 11; i++)
							{ try { @int = int.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @int;
					case Variable.DataType.UInt:
						uint @uint = (uint)0;
						try
						{
							@uint = uint.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 10; i++)
							{ try { @uint = uint.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @uint;
					case Variable.DataType.Long:
						long @long = (long)0;
						try
						{
							@long = long.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 21; i++)
							{ try { @long = long.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @long;
					case Variable.DataType.ULong:
						ulong @ulong = (ulong)0;
						try
						{
							@ulong = ulong.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 20; i++)
							{ try { @ulong = ulong.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @ulong;
					case Variable.DataType.Float:
						// Use decimal to avoid floating point garbage.
						decimal @float = (decimal)0;
						try
						{
							@float = decimal.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 31; i++)
							{ try { @float = decimal.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						@float = Math.Round(@float, 9);
						return @float;
					case Variable.DataType.Double:
						// Use decimal to avoid floating point garbage.
						decimal @double = (decimal)0;
						try
						{
							@double = decimal.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 31; i++)
							{ try { @double = decimal.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						@double = Math.Round(@double, 17);
						return @double;
					case Variable.DataType.Decimal:
						// Use decimal to avoid floating point garbage.
						decimal @decimal = (decimal)0;
						try
						{
							@decimal = decimal.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 31; i++)
							{ try { @decimal = decimal.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @decimal;
					case Variable.DataType.Bool:
						bool @bool = false;
						try
						{
							@bool = bool.Parse(value.ToString());
						} catch
						{
							for (int i = 1; i < 6; i++)
							{ try { @bool = bool.Parse(value.ToString().Substring(0, i)); } catch { continue; } }
						}
						return @bool;
					case Variable.DataType.Vector2:
						Vector2 vector2 = new Vector2(0, 0);
						string[] vector2String = value.ToString().Split(new char[] {':'}, count: 2);
						decimal x2 = 0; decimal y2 = 0;
						try { x2 = (decimal)(VUtils.Convert.ValueByDataType(vector2String[0], Variable.DataType.Decimal)); } catch { }
						try { y2 = (decimal)(VUtils.Convert.ValueByDataType(vector2String[1], Variable.DataType.Decimal)); } catch { }
						vector2 = new Vector2((float)x2, (float)y2);
						return vector2;
					case Variable.DataType.Vector3:
						Vector3 vector3 = new Vector3(0, 0, 0);
						string[] vector3String = value.ToString().Split(new char[] {':'}, count: 3);
						decimal x3 = 0; decimal y3 = 0; decimal z3 = 0;
						try { x3 = (decimal)(VUtils.Convert.ValueByDataType(vector3String[0], Variable.DataType.Decimal)); } catch { }
						try { y3 = (decimal)(VUtils.Convert.ValueByDataType(vector3String[1], Variable.DataType.Decimal)); } catch { }
						try { z3 = (decimal)(VUtils.Convert.ValueByDataType(vector3String[2], Variable.DataType.Decimal)); } catch { }
						vector3 = new Vector3((float)x3, (float)y3, (float)z3);
						return vector3;
					case Variable.DataType.Vector4:
						Vector4 vector4 = new Vector4(0, 0, 0, 0);
						string[] vector4String = value.ToString().Split(new char[] {':'}, count: 4);
						decimal x4 = 0; decimal y4 = 0; decimal z4 = 0; decimal w4 = 0;
						try { x4 = (decimal)(VUtils.Convert.ValueByDataType(vector4String[0], Variable.DataType.Decimal)); } catch { }
						try { y4 = (decimal)(VUtils.Convert.ValueByDataType(vector4String[1], Variable.DataType.Decimal)); } catch { }
						try { z4 = (decimal)(VUtils.Convert.ValueByDataType(vector4String[2], Variable.DataType.Decimal)); } catch { }
						try { w4 = (decimal)(VUtils.Convert.ValueByDataType(vector4String[3], Variable.DataType.Decimal)); } catch { }
						vector4 = new Vector4((float)x4, (float)y4, (float)z4, (float)w4);
						return vector4;
					case Variable.DataType.Color:
						Color color = new Color(0, 0, 0, 0);
						string[] colorString = value.ToString().Split(new char[] {':'}, count: 4);
						int r = 0; int g = 0; int b = 0; int a = 0;
						try { r = (int)(VUtils.Convert.ValueByDataType(colorString[0], Variable.DataType.Int)); } catch { }
						try { g = (int)(VUtils.Convert.ValueByDataType(colorString[1], Variable.DataType.Int)); } catch { }
						try { b = (int)(VUtils.Convert.ValueByDataType(colorString[2], Variable.DataType.Int)); } catch { }
						try { a = (int)(VUtils.Convert.ValueByDataType(colorString[3], Variable.DataType.Int)); } catch { }
						color = new Color(r, g, b, a);
						return color;
					case Variable.DataType.EntityData:
						// Return nothing since EntityData is handled differently.
						return null;
					default:
						// This applies to String, Object and Dynamic (and Any)
						return value;
				}
			}
		}

		public static void VerifyExFlagDictionaries()
		{
			Variable.DataType[] types1 = (Variable.DataType[])(Enum.GetValues(typeof(Variable.DataType)));
			List<Variable.DataType> types = new List<Variable.DataType>();

			foreach (Variable.DataType type in types1)
			{
				if (type != Variable.DataType.Any)
				{
					types.Add(type);
				}
			}
			
			foreach (Variable.DataType type in types)
			{
				if (!VectorHelperModule.SaveData.Variables.ContainsKey(type))
				{
					Logger.Log(LogLevel.Debug, "VectorHelper/ExFlags", $"SaveData Dictionary \"{type}\" doesn't exist in \"Variables\", Creating it...");
					VectorHelperModule.SaveData.Variables.Add(type, new Dictionary<string, object>());
				}

				if (!VectorHelperModule.SaveData.Arrays.ContainsKey(type))
				{
					Logger.Log(LogLevel.Debug, "VectorHelper/ExFlags", $"SaveData Dictionary \"{type}\" doesn't exist in \"Arrays\", Creating it...");
					VectorHelperModule.SaveData.Arrays.Add(type, new Dictionary<string, object[]>());
				}

				if (!VectorHelperModule.SaveData.Lists.ContainsKey(type))
				{
					Logger.Log(LogLevel.Debug, "VectorHelper/ExFlags", $"SaveData Dictionary \"{type}\" doesn't exist in \"Lists\", Creating it...");
					VectorHelperModule.SaveData.Lists.Add(type, new Dictionary<string, List<object>>());
				}

				if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey(type))
				{
					Logger.Log(LogLevel.Debug, "VectorHelper/ExFlags", $"SaveData Dictionary \"{type}\" doesn't exist in \"Dictionaries\" Creating it...");
					VectorHelperModule.SaveData.Dictionaries.Add(type, new Dictionary<string, Dictionary<object, object>>());
				}

				// try
				// {
				// 	if (!Vec)
				// } catch {}
			}
		}
	}

	public static class Lists
	{
		public static Dictionary<string, Color> Colors = new Dictionary<string, Color>()
		{
			{ "AliceBlue", Color.AliceBlue },
			{ "AntiqueWhite", Color.AntiqueWhite },
			{ "Aqua", Color.Aqua },
			{ "Aquamarine", Color.Aquamarine },
			{ "Azure", Color.Azure },
			{ "Beige", Color.Beige },
			{ "Bisque", Color.Bisque },
			{ "Black", Color.Black },
			{ "BlanchedAlmond", Color.BlanchedAlmond },
			{ "Blue", Color.Blue },
			{ "BlueViolet", Color.BlueViolet },
			{ "Brown", Color.Brown },
			{ "BurlyWood", Color.BurlyWood },
			{ "CadetBlue", Color.CadetBlue },
			{ "Chartreuse", Color.Chartreuse },
			{ "Chocolate", Color.Chocolate },
			{ "Coral", Color.Coral },
			{ "CornflowerBlue", Color.CornflowerBlue },
			{ "Cornsilk", Color.Cornsilk },
			{ "Crimson", Color.Crimson },
			{ "Cyan", Color.Cyan },
			{ "DarkBlue", Color.DarkBlue },
			{ "DarkCyan", Color.DarkCyan },
			{ "DarkGoldenrod", Color.DarkGoldenrod },
			{ "DarkGray", Color.DarkGray },
			{ "DarkGreen", Color.DarkGreen },
			{ "DarkKhaki", Color.DarkKhaki },
			{ "DarkMagenta", Color.DarkMagenta },
			{ "DarkOliveGreen", Color.DarkOliveGreen },
			{ "DarkOrange", Color.DarkOrange },
			{ "DarkOrchid", Color.DarkOrchid },
			{ "DarkRed", Color.DarkRed },
			{ "DarkSalmon", Color.DarkSalmon },
			{ "DarkSeaGreen", Color.DarkSeaGreen },
			{ "DarkSlateBlue", Color.DarkSlateBlue },
			{ "DarkSlateGray", Color.DarkSlateGray },
			{ "DarkTurquoise", Color.DarkTurquoise },
			{ "DarkViolet", Color.DarkViolet },
			{ "DeepPink", Color.DeepPink },
			{ "DeepSkyBlue", Color.DeepSkyBlue },
			{ "DimGray", Color.DimGray },
			{ "DodgerBlue", Color.DodgerBlue },
			{ "Firebrick", Color.Firebrick },
			{ "FloralWhite", Color.FloralWhite },
			{ "ForestGreen", Color.ForestGreen },
			{ "Fuchsia", Color.Fuchsia },
			{ "Gainsboro", Color.Gainsboro },
			{ "GhostWhite", Color.GhostWhite },
			{ "Gold", Color.Gold },
			{ "Goldenrod", Color.Goldenrod },
			{ "Gray", Color.Gray },
			{ "Green", Color.Green },
			{ "GreenYellow", Color.GreenYellow },
			{ "Honeydew", Color.Honeydew },
			{ "HotPink", Color.HotPink },
			{ "IndianRed", Color.IndianRed },
			{ "Indigo", Color.Indigo },
			{ "Ivory", Color.Ivory },
			{ "Khaki", Color.Khaki },
			{ "Lavender", Color.Lavender },
			{ "LavenderBlush", Color.LavenderBlush },
			{ "LawnGreen", Color.LawnGreen },
			{ "LemonChiffon", Color.LemonChiffon },
			{ "LightBlue", Color.LightBlue },
			{ "LightCoral", Color.LightCoral },
			{ "LightCyan", Color.LightCyan },
			{ "LightGoldenrodYellow", Color.LightGoldenrodYellow },
			{ "LightGray", Color.LightGray },
			{ "LightGreen", Color.LightGreen },
			{ "LightPink", Color.LightPink },
			{ "LightSalmon", Color.LightSalmon },
			{ "LightSeaGreen", Color.LightSeaGreen },
			{ "LightSkyBlue", Color.LightSkyBlue },
			{ "LightSlateGray", Color.LightSlateGray },
			{ "LightSteelBlue", Color.LightSteelBlue },
			{ "LightYellow", Color.LightYellow },
			{ "Lime", Color.Lime },
			{ "LimeGreen", Color.LimeGreen },
			{ "Linen", Color.Linen },
			{ "Magenta", Color.Magenta },
			{ "Maroon", Color.Maroon },
			{ "MediumAquamarine", Color.MediumAquamarine },
			{ "MediumBlue", Color.MediumBlue },
			{ "MediumOrchid", Color.MediumOrchid },
			{ "MediumPurple", Color.MediumPurple },
			{ "MediumSeaGreen", Color.MediumSeaGreen },
			{ "MediumSlateBlue", Color.MediumSlateBlue },
			{ "MediumSpringGreen", Color.MediumSpringGreen },
			{ "MediumTurquoise", Color.MediumTurquoise },
			{ "MediumVioletRed", Color.MediumVioletRed },
			{ "MidnightBlue", Color.MidnightBlue },
			{ "MintCream", Color.MintCream },
			{ "MistyRose", Color.MistyRose },
			{ "Moccasin", Color.Moccasin },
			{ "NavajoWhite", Color.NavajoWhite },
			{ "Navy", Color.Navy },
			{ "OldLace", Color.OldLace },
			{ "Olive", Color.Olive },
			{ "OliveDrab", Color.OliveDrab },
			{ "Orange", Color.Orange },
			{ "OrangeRed", Color.OrangeRed },
			{ "Orchid", Color.Orchid },
			{ "PaleGoldenrod", Color.PaleGoldenrod },
			{ "PaleGreen", Color.PaleGreen },
			{ "PaleTurquoise", Color.PaleTurquoise },
			{ "PaleVioletRed", Color.PaleVioletRed },
			{ "PapayaWhip", Color.PapayaWhip },
			{ "PeachPuff", Color.PeachPuff },
			{ "Peru", Color.Peru },
			{ "Pink", Color.Pink },
			{ "Plum", Color.Plum },
			{ "PowderBlue", Color.PowderBlue },
			{ "Purple", Color.Purple },
			{ "Red", Color.Red },
			{ "RosyBrown", Color.RosyBrown },
			{ "RoyalBlue", Color.RoyalBlue },
			{ "SaddleBrown", Color.SaddleBrown },
			{ "Salmon", Color.Salmon },
			{ "SandyBrown", Color.SandyBrown },
			{ "SeaGreen", Color.SeaGreen },
			{ "SeaShell", Color.SeaShell },
			{ "Sienna", Color.Sienna },
			{ "Silver", Color.Silver },
			{ "SkyBlue", Color.SkyBlue },
			{ "SlateBlue", Color.SlateBlue },
			{ "SlateGray", Color.SlateGray },
			{ "Snow", Color.Snow },
			{ "SpringGreen", Color.SpringGreen },
			{ "SteelBlue", Color.SteelBlue },
			{ "Tan", Color.Tan },
			{ "Teal", Color.Teal },
			{ "Thistle", Color.Thistle },
			{ "Tomato", Color.Tomato },
			{ "Transparent", Color.Transparent },
			{ "Turquoise", Color.Turquoise },
			{ "Violet", Color.Violet },
			{ "Wheat", Color.Wheat },
			{ "White", Color.White },
			{ "WhiteSmoke", Color.WhiteSmoke },
			{ "Yellow", Color.Yellow },
			{ "YellowGreen", Color.YellowGreen }
		};
	}
}