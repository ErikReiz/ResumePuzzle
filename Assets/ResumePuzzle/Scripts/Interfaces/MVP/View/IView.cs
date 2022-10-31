using System.Threading.Tasks;

namespace ResumePuzzle.Interfaces
{
	public interface IView
	{
		#region CONST
		const float offScreenCoordinates = -1000;
		#endregion

		#region METHODS
		Task Show();
		Task Hide();
		#endregion
	}
}
