using ResumePuzzle.Data;

namespace ResumePuzzle.Interfaces
{
	public interface ISaveSettingsModel
	{
		#region METHODS
		void SaveGame(SettingsPresset settingsPresset);
		SettingsPresset? LoadSettings();
		#endregion
	}
}
