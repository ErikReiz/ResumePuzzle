using ResumePuzzle.Data;

namespace ResumePuzzle.Interfaces
{
	public interface IGameSettingsModel
	{
		#region PROPERTIES
		ref SettingsSaveData Settings { get; }
		#endregion

		#region METHODS
		void InitializeSettings(SettingsSaveData savedSettings);
		void ApplySettings();

		void ChangeResolutionScale(float scale);
		void ChangeGraphicPresset(int pressetID);
		void ChangeSoundVolume(float volume);
		void ChangeMusicVolume(float volume);
		#endregion
	}
}
