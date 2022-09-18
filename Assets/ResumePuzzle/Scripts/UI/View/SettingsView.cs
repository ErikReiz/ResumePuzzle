using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.UI.View
{
	public class SettingsView : MonoBehaviour, ISettingsView
	{
		#region SERIALIZABLE FIELDS
		[Header("Buttons")]
		[SerializeField] private TMP_Dropdown resolutionDropdown;
		[SerializeField] private TMP_Dropdown graphicsDropdown;
		[SerializeField] private Slider soundSlider;
		[SerializeField] private Slider musicSlider;
		[SerializeField] private Button backButton;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region PROPERTIES
		public UnityAction<string> OnResolutionChanged { set => throw new System.NotImplementedException(); }
		public UnityAction<int> OnSettingsPressetChanged { set { } }

		public UnityAction<float> OnSoundVolumeChanged { set => throw new System.NotImplementedException(); }
		public UnityAction<float> OnMusicVolumeChanged { set => throw new System.NotImplementedException(); }

		public UnityAction OnBackButtonClicked { set { backButton.onClick.AddListener(value); } }
		#endregion

		public async void Show()
		{
			gameObject.SetActive(true);
			await transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}
	
		public async void Hide()
		{
			await transform.DOLocalMoveX(-IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
			gameObject.SetActive(false);
		}
	}
}