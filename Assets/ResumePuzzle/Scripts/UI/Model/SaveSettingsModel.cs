using System.Collections.Generic;
using UnityEngine;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Model
{
	public class SaveSettingsModel : ISaveDataModel
	{
		#region CONST
		private readonly Dictionary<System.Type, string> dataByTag = new()
		{
			[typeof(SettingsSaveData)] = "settings",
			[typeof(LevelSaveData)] = "level"
		};
		#endregion

		private string GetPlayerPrefsKey<T>()
		{
			if (!dataByTag.TryGetValue(typeof(T), out string key))
				return null;

			return key;
		}

		public void SaveData<T>(ref T data) where T : struct
		{
			string serializedString = XMLHelper.Serialize<T>(data);
			PlayerPrefs.SetString(GetPlayerPrefsKey<T>(), serializedString);
			PlayerPrefs.Save();
		}

		public T LoadData<T>() where T : struct
		{
			string key = GetPlayerPrefsKey<T>();

			if (PlayerPrefs.HasKey(key))
			{
				return XMLHelper.Deserealize<T>(PlayerPrefs.GetString(key));
			}
			else
			{
				return default(T);
			}

		}
	}
}

