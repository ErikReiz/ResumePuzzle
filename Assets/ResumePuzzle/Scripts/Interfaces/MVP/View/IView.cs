namespace ResumePuzzle.Interfaces
{
	public interface IView
	{
		#region CONST
		const float offScreenCoordinates = -2000;
		#endregion

		#region METHODS
		void Show();
		void Hide();
		#endregion
	}
}
