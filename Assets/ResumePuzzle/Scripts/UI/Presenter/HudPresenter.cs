using Zenject;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.Presenter
{
	#region FIELDS
	#endregion

	public class HudPresenter : IHudPresenter
	{
		#region FIELDS
		[Inject] private IView hudView;
		[Inject] private IMenuPresenter pauseMenuPresenter;
        #endregion

        public void Run()
		{
			hudView.Show();
		}

		public void Close()
		{
			hudView.Hide();
		}

		public void PauseGame()
		{
			hudView.Hide();
			pauseMenuPresenter.Run();
		}
	}
}