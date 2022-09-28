using Zenject;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Presenter
{
	public class MainMenuPresenter : IMenuPresenter
	{
		#region FIELDS
		[Inject] private IView menuView;
		[Inject] private ISettingsPresenter settingsPresenter;
		[Inject] private IInterstitialAds interstitialAds;
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
			interstitialAds.ShowInterstitialAds();
			Close();
			UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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