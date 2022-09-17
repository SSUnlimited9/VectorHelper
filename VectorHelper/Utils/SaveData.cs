using System;
using System.Collections.Generic;
using Celeste;
using Celeste.Mod;

namespace VectorHelper.Utils
{
	public class SaveDataUtils
	{
		/// <summary>
		/// Verify that VectorHelper SaveData and SessionData have the data types for each dictionary
		/// </summary>
		public static void VerifyVariablesDictionary()
		{
			string[] types = new string[Enum.GetNames(typeof(VHEnums.DataType)).Length - 1];
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = Enum.GetNames(typeof(VHEnums.DataType))[i];
			}

			// Make sure that the dictionaries contain the data types
			foreach (string type in types)
			{
				if (!VectorHelperModule.SaveData.Variables.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Variables.Add(type, new Dictionary<string, object>());
					Logger.Log("VectorHelper/Variables", $"SaveData Dictionary \"{type}\" didn't exist in \"Variables\" so it was added (SaveFile: {SaveData.Instance.FileSlot}, {SaveData.Instance.Name})");
				}
				if (!VectorHelperModule.SaveData.Arrays.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Arrays.Add(type, new Dictionary<string, object[]>());
					Logger.Log("VectorHelper/Variables", $"SaveData Dictionary \"{type}\" didn't exist in \"Arrays\" so it was added (SaveFile: {SaveData.Instance.FileSlot}, {SaveData.Instance.Name})");
				}
				if (!VectorHelperModule.SaveData.Lists.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Lists.Add(type, new Dictionary<string, List<object>>());
					Logger.Log("VectorHelper/Variables", $"SaveData Dictionary \"{type}\" didn't exist in \"Lists\" so it was added (SaveFile: {SaveData.Instance.FileSlot}, {SaveData.Instance.Name})");
				}
				if (!VectorHelperModule.SaveData.Dictionaries.ContainsKey(type))
				{
					VectorHelperModule.SaveData.Dictionaries.Add(type, new Dictionary<string, Dictionary<string, object>>());
					Logger.Log("VectorHelper/Variables", $"SaveData Dictionary \"{type}\" didn't exist in \"Dictionaries\" so it was added (SaveFile: {SaveData.Instance.FileSlot}, {SaveData.Instance.Name})");
				}
			}

			// Add the data types to session dictionaries
			foreach (string type in types)
			{
				VectorHelperModule.Session.Variables.Add(type, new Dictionary<string, object>());
				VectorHelperModule.Session.Arrays.Add(type, new Dictionary<string, object[]>());
				VectorHelperModule.Session.Lists.Add(type, new Dictionary<string, List<object>>());
				VectorHelperModule.Session.Dictionaries.Add(type, new Dictionary<string, Dictionary<string, object>>());
			}
		}
	}
}