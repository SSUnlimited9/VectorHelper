using System.Collections.Generic;
using Celeste.Mod;

// Functions that are mostly too long to be used in main code
namespace VectorHelper.Utils
{
	public class SaveDataUtils
	{
		/// <summary>
		/// Verify the "Variables" Dictionary in SaveData
		/// </summary>
		public static void VerifyVariablesDictionary()
		{
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("String"))
			{
				VectorHelperModule.SaveData.Variables.Add("String", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"String\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Char"))
			{
				VectorHelperModule.SaveData.Variables.Add("Char", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Char\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("SByte"))
			{
				VectorHelperModule.SaveData.Variables.Add("SByte", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"SByte\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Byte"))
			{
				VectorHelperModule.SaveData.Variables.Add("Byte", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Byte\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Short"))
			{
				VectorHelperModule.SaveData.Variables.Add("Short", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Short\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("UShort"))
			{
				VectorHelperModule.SaveData.Variables.Add("UShort", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"UShort\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Int"))
			{
				VectorHelperModule.SaveData.Variables.Add("Int", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Int\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("UInt"))
			{
				VectorHelperModule.SaveData.Variables.Add("UInt", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"UInt\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Long"))
			{
				VectorHelperModule.SaveData.Variables.Add("Long", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Long\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("ULong"))
			{
				VectorHelperModule.SaveData.Variables.Add("ULong", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"ULong\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Float"))
			{
				VectorHelperModule.SaveData.Variables.Add("Float", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Float\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Double"))
			{
				VectorHelperModule.SaveData.Variables.Add("Double", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Double\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Decimal"))
			{
				VectorHelperModule.SaveData.Variables.Add("Decimal", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Decimal\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Bool"))
			{
				VectorHelperModule.SaveData.Variables.Add("Bool", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Bool\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Object"))
			{
				VectorHelperModule.SaveData.Variables.Add("Object", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Object\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Vector2"))
			{
				VectorHelperModule.SaveData.Variables.Add("Vector2", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector2\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Vector3"))
			{
				VectorHelperModule.SaveData.Variables.Add("Vector3", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector3\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Vector4"))
			{
				VectorHelperModule.SaveData.Variables.Add("Vector4", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector4\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Color"))
			{
				VectorHelperModule.SaveData.Variables.Add("Color", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Color\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("EntityData"))
			{
				VectorHelperModule.SaveData.Variables.Add("EntityData", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"EntityData\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Variables.ContainsKey("Dynamic"))
			{
				VectorHelperModule.SaveData.Variables.Add("Dynamic", new Dictionary<string, object>());
				Logger.Log("VectorHelper", $"Dictionary \"Dynamic\" didn't exist in \"Variable\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
		}

		/// <summary>
		/// Verify the "Arrays" Dictionary in SaveData
		/// </summary>
		public static void VerifyArraysDictionary()
		{
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("String"))
			{
				VectorHelperModule.SaveData.Arrays.Add("String", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"String\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Char"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Char", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Char\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("SByte"))
			{
				VectorHelperModule.SaveData.Arrays.Add("SByte", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"SByte\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Byte"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Byte", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Byte\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Short"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Short", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Short\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("UShort"))
			{
				VectorHelperModule.SaveData.Arrays.Add("UShort", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"UShort\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Int"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Int", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Int\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("UInt"))
			{
				VectorHelperModule.SaveData.Arrays.Add("UInt", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"UInt\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Long"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Long", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Long\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("ULong"))
			{
				VectorHelperModule.SaveData.Arrays.Add("ULong", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"ULong\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Float"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Float", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Float\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Double"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Double", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Double\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Bool"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Bool", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Bool\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Object"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Object", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Object\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Vector2"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Vector2", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector2\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Vector3"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Vector3", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector3\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Vector4"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Vector4", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector4\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Color"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Color", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Color\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("EntityData"))
			{
				VectorHelperModule.SaveData.Arrays.Add("EntityData", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"EntityData\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Arrays.ContainsKey("Dynamic"))
			{
				VectorHelperModule.SaveData.Arrays.Add("Dynamic", new Dictionary<string, object[]>());
				Logger.Log("VectorHelper", $"Dictionary \"Dynamic\" didn't exist in \"Array\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
		}

		/// <summary>
		/// Verify the "Lists" Dictionary in SaveData
		/// </summary>
		public static void VerifyListsDictionary()
		{
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("String"))
			{
				VectorHelperModule.SaveData.Lists.Add("String", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"String\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Char"))
			{
				VectorHelperModule.SaveData.Lists.Add("Char", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Char\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("SByte"))
			{
				VectorHelperModule.SaveData.Lists.Add("SByte", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"SByte\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Byte"))
			{
				VectorHelperModule.SaveData.Lists.Add("Byte", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Byte\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Short"))
			{
				VectorHelperModule.SaveData.Lists.Add("Short", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Short\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("UShort"))
			{
				VectorHelperModule.SaveData.Lists.Add("UShort", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"UShort\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Int"))
			{
				VectorHelperModule.SaveData.Lists.Add("Int", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Int\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("UInt"))
			{
				VectorHelperModule.SaveData.Lists.Add("UInt", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"UInt\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Long"))
			{
				VectorHelperModule.SaveData.Lists.Add("Long", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Long\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("ULong"))
			{
				VectorHelperModule.SaveData.Lists.Add("ULong", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"ULong\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Float"))
			{
				VectorHelperModule.SaveData.Lists.Add("Float", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Float\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Double"))
			{
				VectorHelperModule.SaveData.Lists.Add("Double", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Double\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Bool"))
			{
				VectorHelperModule.SaveData.Lists.Add("Bool", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Bool\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Object"))
			{
				VectorHelperModule.SaveData.Lists.Add("Object", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Object\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Vector2"))
			{
				VectorHelperModule.SaveData.Lists.Add("Vector2", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector2\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Vector3"))
			{
				VectorHelperModule.SaveData.Lists.Add("Vector3", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector3\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Vector4"))
			{
				VectorHelperModule.SaveData.Lists.Add("Vector4", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector4\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Color"))
			{
				VectorHelperModule.SaveData.Lists.Add("Color", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Color\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("EntityData"))
			{
				VectorHelperModule.SaveData.Lists.Add("EntityData", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"EntityData\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Lists.ContainsKey("Dynamic"))
			{
				VectorHelperModule.SaveData.Lists.Add("Dynamic", new Dictionary<string, List<object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Dynamic\" didn't exist in \"List\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
		}

		/// <summary>
		/// Verify the "Dictionaries" Dictionary in SaveData
		/// </summary>
		public static void VerifyDictionariesDictionary()
		{
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("String"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("String", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"String\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Char"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Char", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Char\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("SByte"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("SByte", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"SByte\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Byte"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Byte", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Byte\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Short"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Short", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Short\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("UShort"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("UShort", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"UShort\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Int"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Int", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Int\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("UInt"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("UInt", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"UInt\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Long"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Long", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Long\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("ULong"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("ULong", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"ULong\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Float"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Float", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Float\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Double"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Double", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Double\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Bool"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Bool", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Bool\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Object"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Object", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Object\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Vector2"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Vector2", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector2\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Vector3"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Vector3", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector3\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Vector4"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Vector4", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Vector4\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Color"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Color", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Color\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("EntityData"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("EntityData", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"EntityData\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
			if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey("Dynamic"))
			{
				VectorHelperModule.SaveData.Dictionaries.Add("Dynamic", new Dictionary<string, Dictionary<object, object>>());
				Logger.Log("VectorHelper", $"Dictionary \"Dynamic\" didn't exist in \"Dictionarie\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
			}
		}
	}
}