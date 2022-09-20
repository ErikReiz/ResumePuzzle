namespace ResumePuzzle.Interfaces
{
	public interface IView
	{
		#region CONST
		const float offScreenCoordinates = -4000;
		#endregion

		#region METHODS
		void Show();
		void Hide();
		#endregion
	}
}
