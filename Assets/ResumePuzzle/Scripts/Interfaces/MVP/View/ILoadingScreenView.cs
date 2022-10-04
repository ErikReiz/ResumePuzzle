namespace ResumePuzzle.Interfaces
{
	public interface ILoadingScreenView : IView
	{
		#region METHODS
		void UpdateLoadingBar(float loadingPercent);
		#endregion
	}
}
