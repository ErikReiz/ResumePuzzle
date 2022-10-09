namespace ResumePuzzle.Interfaces
{
	public interface ISaveDataModel
	{
		#region METHODS
		void SaveData<T>(T data) where T : struct;
		T LoadData<T>() where T : struct;
		#endregion
	}
}