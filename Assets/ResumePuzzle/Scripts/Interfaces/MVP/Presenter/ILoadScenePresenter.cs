namespace ResumePuzzle.Interfaces
{
    public interface ILoadScenePresenter
    {
		#region PROPERTIES
		float LoadingPercents { get; }
		#endregion

		#region METHODS
		void LoadLastScene();
		void LoadNextScene();
		void LoadMainMenu();
		#endregion
	}
}
