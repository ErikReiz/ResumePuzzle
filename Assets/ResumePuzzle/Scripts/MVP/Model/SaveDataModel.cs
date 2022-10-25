using Zenject;
using UnityEngine;
using System.Collections.Generic;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Model
{
	public class SaveDataModel : ISaveDataModel
	{
		#region CONST
		private readonly Dictionary<System.Type, string> dataByTag = new()
		{
			[typeof(SettingsSaveData)] = "settings",
			[typeof(LevelSaveData)] = "level"
		};

		private readonly Dictionary<System.Type, object> dataTags = new();
		#endregion

		#region FIELDS
		[Inject] private ISerializationHelper serializationHelper;
		#endregion

		private string GetPlayerPrefsKey<T>()
		{
			if (!dataByTag.TryGetValue(typeof(T), out string key))
				return null;

			return key;
		}

		public void SaveData<T>(T data) where T : struct
		{
			string serializedString = serializationHelper.Serialize<T>(data);
			PlayerPrefs.SetString(GetPlayerPrefsKey<T>(), serializedString);
			PlayerPrefs.Save();
		}

		public T LoadData<T>() where T : struct
		{
			string key = GetPlayerPrefsKey<T>();

			if (PlayerPrefs.HasKey(key))
			{
				return serializationHelper.Deserealize<T>(PlayerPrefs.GetString(key));
			}
			else
			{
				return default(T);
			}

		}
	}
}

