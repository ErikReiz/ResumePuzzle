using UnityEngine;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Model
{
	public class SaveSettingsModel : ISaveSettingsModel
	{
		#region CONST
		const string settingsSaveKey = "settings";
		#endregion

		public void SaveGame(SettingsPresset settingsPresset)
		{
			string serializedString = XMLHelper.Serialize<SettingsPresset>(settingsPresset);
			PlayerPrefs.SetString(settingsSaveKey, serializedString);
			PlayerPrefs.Save();
		}

		public SettingsPresset? LoadSettings()
		{
			if (PlayerPrefs.HasKey(settingsSaveKey))
				return XMLHelper.Deserealize<SettingsPresset>(PlayerPrefs.GetString(settingsSaveKey));
			else
				return null;
		}
	}
}
