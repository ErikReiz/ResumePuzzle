using Zenject;
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
		#endregion

		public void Run()
		{
			UnityEngine.Debug.Log("showed");
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
			UnityEngine.Debug.Log("closed");
			menuView.HideCanvas();
			hudPresenter.Run();
		}

		public void OpenSettings()
		{
			Close();
			settingsPresenter.Run();
		}

		public void QuitGame()
		{
			//TODO экран загрузки в главное меню
			Close();
			menuView.HideCanvas();
		}
	}
}