namespace ResumePuzzle.Interfaces
{
	public interface ISettingsPresenter : IPresenter
	{
		#region METHODS
		void BackToMenu();

		void ChangeResolution(int resolutionID);
		void ChangeGraphicPresset(int pressetID);

		void ChangeSoundVolume(float volume);
		void ChangeMusicVolume(float volume);
		#endregion
	}
}

