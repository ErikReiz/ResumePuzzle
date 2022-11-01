using ResumePuzzle.Data;

namespace ResumePuzzle.Interfaces
{
	public interface IGameSettingsModel
	{
		#region PROPERTIES
		ref SettingsSaveData Settings { get; }
		#endregion

		#region METHODS
		void ApplySettings();
		void ApplySettings(SettingsSaveData loadedSettings);
		ref SettingsSaveData SetSettings();


		void ChangeResolutionScale(float scale);
		public void ChangeGraphicPresset(int pressetID);
		void ChangeSoundVolume(float volume);
		void ChangeMusicVolume(float volume);

		bool AreSettingsValid();
		#endregion
	}
}
