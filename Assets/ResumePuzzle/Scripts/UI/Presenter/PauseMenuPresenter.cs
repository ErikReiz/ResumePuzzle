using Zenject;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Presenter
{
	public class PauseMenuPresenter : IMenuPresenter
	{
		#region FIELDS
		[Inject] private IMenuView menuView;
		//[Inject] private ISettingsPresenter settingsPresenter;
		#endregion

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
			await menuView.Hide();
		}

		public void OpenSettings()
		{
			Close();
			//settingsPresenter.Run();
		}

		public void QuitGame()
		{
			Close();
			menuView.HideCanvas();
		}
	}
}