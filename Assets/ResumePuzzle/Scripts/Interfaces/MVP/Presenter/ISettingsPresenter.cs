namespace ResumePuzzle.Interfaces
{
	public interface ISettingsPresenter : IPresenter
	{
		#region METHODS
		void LoadSettings();

		void BackToMenu();
		void ChangeResolutionScale(float scale);
		void ChangeGraphicPresset(int pressetID);
		void ChangeSoundVolume(float volume);
		void ChangeMusicVolume(float volume);
		#endregion
	}
}

