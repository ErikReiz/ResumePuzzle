namespace ResumePuzzle.Interfaces
{
	public interface IMenuPresenter : IPresenter
	{
		#region METHODS
		void StartGame();
		void OpenSettings();
		void QuitGame();
		#endregion
	}
}
