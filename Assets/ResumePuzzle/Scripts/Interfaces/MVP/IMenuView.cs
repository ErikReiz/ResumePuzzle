using UnityEngine.Events;

namespace ResumePuzzle.Interfaces
{
	public interface IMenuView : IView
	{
		#region PROPERTIES
		UnityAction OnPlayButtonClicked { set; }
		UnityAction OnSettingsButtonClicked { set; }
		UnityAction OnQuitButtonClicked { set; }
		#endregion
	}
}
