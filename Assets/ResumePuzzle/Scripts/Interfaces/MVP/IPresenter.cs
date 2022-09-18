namespace ResumePuzzle.Interfaces
{
	public interface IPresenter
	{
		#region METHODS
		void Run();
		void Close();
		#endregion
	}

	public interface ISettingsPresenter : IPresenter
	{}
}

