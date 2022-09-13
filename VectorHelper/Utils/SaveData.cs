using System;
using System.Collections.Generic;
using Celeste.Mod;
using VectorHelper.Utils;

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
			string[] types = new string[Enum.GetNames(typeof(VHEnums.DataType)).Length];
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = Enum.GetNames(typeof(VHEnums.DataType))[i];
			}
			foreach (string type in types)
			{
				if (!VectorHelperModule.SaveData.Variables.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Variables.Add(type, new Dictionary<string, object>());
					Logger.Log("VectorHelper/Variables", $"Dictionary \"{type}\" didn't exist in \"Variables\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
				}
			}
		}

		/// <summary>
		/// Verify the "Arrays" Dictionary in SaveData
		/// </summary>
		public static void VerifyArraysDictionary()
		{
			string[] types = new string[Enum.GetNames(typeof(VHEnums.DataType)).Length];
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = Enum.GetNames(typeof(VHEnums.DataType))[i];
			}
			foreach (string type in types)
			{
				if (!VectorHelperModule.SaveData.Arrays.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Arrays.Add(type, new Dictionary<string, object[]>());
					Logger.Log("VectorHelper/Arrays", $"Dictionary \"{type}\" didn't exist in \"Arrays\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
				}
			}
		}

		/// <summary>
		/// Verify the "Lists" Dictionary in SaveData
		/// </summary>
		public static void VerifyListsDictionary()
		{
			string[] types = new string[Enum.GetNames(typeof(VHEnums.DataType)).Length];
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = Enum.GetNames(typeof(VHEnums.DataType))[i];
			}
			foreach (string type in types)
			{
				if (!VectorHelperModule.SaveData.Lists.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Lists.Add(type, new Dictionary<string, List<object>>());
					Logger.Log("VectorHelper/Lists", $"Dictionary \"{type}\" didn't exist in \"Lists\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
				}
			}
		}

		/// <summary>
		/// Verify the "Dictionaries" Dictionary in SaveData
		/// </summary>
		public static void VerifyDictionariesDictionary()
		{
			string[] types = new string[Enum.GetNames(typeof(VHEnums.DataType)).Length];
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = Enum.GetNames(typeof(VHEnums.DataType))[i];
			}
			foreach (string type in types)
			{
				if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Dictionaries.Add(type, new Dictionary<string, Dictionary<object, object>>());
					Logger.Log("VectorHelper/Dictionaries", $"Dictionary \"{type}\" didn't exist in \"Dictionaries\" so it was added (SaveFile: {Celeste.SaveData.Instance.FileSlot}, {Celeste.SaveData.Instance.Name})");
				}
			}
		}
	}
}