using ResumePuzzle.Interfaces;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class MainMenuPresenter : IMenuPresenter
	{
		#region FIELDS
		[Inject] private IView menuView;
		[Inject] private ISettingsPresenter settingsPresenter;
		#endregion

		public void Run()
		{
			menuView.Show();
		}
		
		public void Close()
		{
			menuView.Hide();
		}

		public void StartGame()
		{
			Close();
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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