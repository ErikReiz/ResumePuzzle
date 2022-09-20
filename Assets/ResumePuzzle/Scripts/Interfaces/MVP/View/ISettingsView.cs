using ResumePuzzle.Interfaces;
using System.Collections.Generic;

namespace ResumePuzzle.Interfaces
{
	public interface ISettingsView : IView
	{
		#region METHODS
		void UpdateResolutionsMenu(List<string> resolutions, int currentResolutionIndex);
		void SetSoundSlider(float volume);
		void SetMusicSlider(float volume);
		#endregion
	}
}

