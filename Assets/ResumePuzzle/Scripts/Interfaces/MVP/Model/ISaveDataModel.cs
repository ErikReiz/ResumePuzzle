namespace ResumePuzzle.Interfaces
{
	public interface ISaveDataModel
	{
		#region METHODS
		void SaveData<T>(ref T data) where T : struct;
		T LoadData<T>() where T : struct;
		#endregion
	}
}