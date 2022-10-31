using ResumePuzzle.World.Item;

namespace ResumePuzzle.Interfaces
{
	public interface IInventory
	{
		#region METHODS
		void Take(KeyItem key);

		bool ContainsKey(int keyCode);
		#endregion
	}
}