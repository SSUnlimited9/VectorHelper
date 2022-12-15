using System;
using System.Collections.Generic;
using Celeste.Mod;
using Microsoft.Xna.Framework;
using VectorHelper.Module;

namespace VectorHelper.Utils
{
	public class VUtils
	{
		public class Convert
		{
			public static object ValueByDataType(object value, Variable.DataType dt)
			{
				switch (dt)
				{
					case Variable.DataType.Char:
						char @char = ' ';
						try
						{
							@char = char.Parse(value.ToString());
						} catch 
						{ try { @char = char.Parse(value.ToString().Substring(0, 1)); } catch { } }
						return @char;
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
			List<string> types = new List<string>(Enum.GetNames(typeof(Variable.DataType)));
			types.Remove("Any");

			foreach (string type in types)
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