using ResumePuzzle.Interfaces;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	#region FIELDS
	#endregion

	public class HudPresenter : IHudPresenter
	{
		#region FIELDS
		[Inject] private IView hudView;
		[Inject] private IMenuPresenter pauseMenuPresenter;
		[Inject] private IPlayer player;
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

		public void Interact()
		{
			player.OnInteractInput();
		}
	}
}