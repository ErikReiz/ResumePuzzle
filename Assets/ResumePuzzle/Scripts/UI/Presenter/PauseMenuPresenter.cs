using System;
using Zenject;
using UnityEngine.SceneManagement;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Presenter
{
	public class PauseMenuPresenter : IMenuPresenter
	{
		#region FIELDS
		[Inject] private IMenuView menuView;
		[Inject] private ISettingsPresenter settingsPresenter;
		[Inject] private IHudPresenter hudPresenter;
		[Inject] private ILoadScenePresenter loadScenePresenter;
		[Inject] private ISaveDataModel saveDataModel;
		#endregion

		private async void CloseAsync(Action afterCloseFunc)
		{
			await menuView.Hide();
			menuView.HideCanvas();

			afterCloseFunc();
		}

		private LevelSaveData SetSceneState()
		{
			LevelSaveData levelSaveData = new();
			levelSaveData.LevelName = SceneManager.GetActiveScene().name;

			return levelSaveData;
		}

		public void Run()
		{
			menuView.ShowCanvas();
			menuView.Show();
		}
		
		public void Close()
		{
			menuView.Hide();
		}

		public async void StartGame()
		{
			CloseAsync(hudPresenter.Run);
		}

		public void OpenSettings()
		{
			Close();

			settingsPresenter.Run();
		}

		public async void QuitGame()
		{
			saveDataModel.SaveData<LevelSaveData>(SetSceneState());
			CloseAsync(loadScenePresenter.LoadMainMenu);
		}
	}
}