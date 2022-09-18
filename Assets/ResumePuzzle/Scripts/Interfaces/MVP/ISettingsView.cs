using UnityEngine.Events;

namespace ResumePuzzle.Interfaces
{
	public interface ISettingsView : IView
	{
		#region PROPERTIES
		UnityAction<string> OnResolutionChanged { set; }

		UnityAction<int> OnSettingsPressetChanged { set; }
		UnityAction<float> OnSoundVolumeChanged { set; }
		UnityAction<float> OnMusicVolumeChanged { set; }

		UnityAction OnBackButtonClicked { set; }
		#endregion
	}
}
