using UnityEngine.ResourceManagement.AsyncOperations;

namespace ResumePuzzle.Interfaces
{
	public interface ILoadLevelModel
	{
		#region METHODS
		public AsyncOperationHandle LoadLastScene();
		public AsyncOperationHandle LoadNextScene();
		public AsyncOperationHandle LoadMainMenu();
		#endregion
	}
}