using ResumePuzzle.Data;

namespace ResumePuzzle.Interfaces
{
	public interface ISettingsView : IView
	{
		#region METHODS
		void SetSettingsView(ref SettingsSaveData settingsPresset);
		#endregion
	}
}