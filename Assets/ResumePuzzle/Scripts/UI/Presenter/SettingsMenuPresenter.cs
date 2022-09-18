using ResumePuzzle.Interfaces;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class SettingsMenuPresenter : IPresenter
	{
		#region FIELDS
		private ISettingsView settingsView;
		[Inject(Id = "MMP")]
		private IPresenter menuPresenter;
		#endregion
		
		public SettingsMenuPresenter(ISettingsView settingsView)
		{
			this.settingsView = settingsView;
		}
		
		public void Run()
		{
			settingsView.Show();

			settingsView.OnBackButtonClicked = Close;
		}

		public void Close()
		{
			settingsView.Hide();
			menuPresenter.Run();
		}
	}
}