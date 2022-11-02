using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class SettingsMenuPresenter : ISettingsPresenter
	{
		#region FIELDS
		[Inject] private ISettingsView settingsView;
		[Inject] private IMenuPresenter menuPresenter;
		[Inject] private ISaveDataModel saveDataModel;
		[Inject] private IGameSettingsModel gameSettingsModel;
		#endregion

		private void SaveSettings()
		{
			gameSettingsModel.ApplySettings();
			saveDataModel.SaveData(gameSettingsModel.Settings);
		}

		public void Run()
		{
			settingsView.SetSettingsView(ref gameSettingsModel.Settings);
			settingsView.Show();
		}

		public void Close()
		{
			SaveSettings();
			settingsView.Hide();
		}

		public void BackToMenu()
		{
			Close();
			menuPresenter.Run();
		}

		public void ChangeResolutionScale(float scale)
		{
			gameSettingsModel.ChangeResolutionScale(scale);
		}

		public void ChangeGraphicPresset(int pressetID)
		{
			gameSettingsModel.ChangeGraphicPresset(pressetID);
		}

		public void ChangeSoundVolume(float volume)
		{
			gameSettingsModel.ChangeSoundVolume(volume);
		}

		public void ChangeMusicVolume(float volume)
		{
			gameSettingsModel.ChangeMusicVolume(volume);
		}
	}
}