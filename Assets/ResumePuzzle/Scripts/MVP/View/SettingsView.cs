using DG.Tweening;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ResumePuzzle.UI.View
{
	public class SettingsView : MonoBehaviour, ISettingsView
	{
		#region SERIALIZABLE FIELDS
		[Header("Settings")]
		[SerializeField] private Button backButton;
		[SerializeField] private Slider resolutionSlider;
		[SerializeField] private TMP_Dropdown qualityDropdown;
		[SerializeField] private Slider soundSlider;
		[SerializeField] private Slider musicSlider;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region FIELDS
		[Inject] private ISettingsPresenter settingsPresenter;
		#endregion

		private void OnEnable()
		{
			backButton.onClick.AddListener(settingsPresenter.BackToMenu);
			resolutionSlider.onValueChanged.AddListener(settingsPresenter.ChangeResolutionScale);
			qualityDropdown.onValueChanged.AddListener(settingsPresenter.ChangeGraphicPresset);

			soundSlider.onValueChanged.AddListener(settingsPresenter.ChangeSoundVolume);
			musicSlider.onValueChanged.AddListener(settingsPresenter.ChangeMusicVolume);
		}

		private void OnDisable()
		{
			backButton.onClick.RemoveListener(settingsPresenter.BackToMenu);
			resolutionSlider.onValueChanged.RemoveListener(settingsPresenter.ChangeResolutionScale);
			qualityDropdown.onValueChanged.RemoveListener(settingsPresenter.ChangeGraphicPresset);

			soundSlider.onValueChanged.RemoveListener(settingsPresenter.ChangeSoundVolume);
			musicSlider.onValueChanged.RemoveListener(settingsPresenter.ChangeMusicVolume);
		}

		private float SliderVolemeFromMixer(float volume)
		{
			return Mathf.Pow(10, volume / 20);
		}

		public Task Show()
		{
			return transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			return transform.DOLocalMoveX(-IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
		}

		public void SetSettingsView(ref SettingsSaveData settingsPresset)
		{
			resolutionSlider.value = settingsPresset.ResolutionScale;
			qualityDropdown.value = settingsPresset.QualityPresset;
			soundSlider.value = SliderVolemeFromMixer(settingsPresset.SoundVolume);
			musicSlider.value = SliderVolemeFromMixer(settingsPresset.MusicVolume);

			qualityDropdown.RefreshShownValue();
		}
	}
}