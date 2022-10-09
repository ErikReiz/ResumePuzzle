using Zenject;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Presenter
{
	public class MainMenuPresenter : IMenuPresenter
	{
		#region FIELDS
		[Inject] private IMenuView menuView;
		[Inject] private ISettingsPresenter settingsPresenter;
		[Inject] private ILoadScenePresenter loadScenePresenter;
		#endregion

		public void Run()
		{
			menuView.Show();
		}
		
		public void Close()
		{
			menuView.Hide();
		}

		public async void StartGame()
		{
			await menuView.Hide();
			menuView.HideCanvas();

			loadScenePresenter.LoadLastScene();
		}

		public void OpenSettings()
		{
			Close();
			settingsPresenter.Run();
		}

		public void QuitGame()
		{
			UnityEngine.Application.Quit();
		}
	}
}