using UnityEngine;
using ResumePuzzle.Interfaces;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class MainMenuPresenter : IPresenter
	{
		#region FIELDS
		private IMenuView menuView;
		[Inject(Id = "SMP")]
		private IPresenter settingsPresenter;
		#endregion
		
		public MainMenuPresenter(IMenuView menuView)
		{
			this.menuView = menuView;

			Run();
		}
		
		private void OpenSettings()
		{
			Close();
			settingsPresenter.Run();
		}

		public void Run()
		{
			menuView.Show();

			menuView.OnPlayButtonClicked = () => menuView.Hide();
			menuView.OnSettingsButtonClicked = OpenSettings;
			menuView.OnQuitButtonClicked = () => Application.Quit();
		}
		
		public void Close()
		{
			menuView.Hide();
		}
	}
}