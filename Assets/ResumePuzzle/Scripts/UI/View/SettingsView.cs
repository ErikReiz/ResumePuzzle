using TMPro;
using Zenject;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using ResumePuzzle.Interfaces;
using System.Collections.Generic;

namespace ResumePuzzle.UI.View
{
	public class SettingsView : MonoBehaviour, ISettingsView
	{
		#region SERIALIZABLE FIELDS
		[Header("Settings")]
		[SerializeField] private Button backButton;
		[SerializeField] private TMP_Dropdown resolutionDropdown;
		[SerializeField] private TMP_Dropdown graphicsDropdown;
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
			SetCurrentGraphicsTier();

			backButton.onClick.AddListener(settingsPresenter.BackToMenu);

			resolutionDropdown.onValueChanged.AddListener(settingsPresenter.ChangeResolution);
			graphicsDropdown.onValueChanged.AddListener(settingsPresenter.ChangeGraphicPresset);

			soundSlider.onValueChanged.AddListener(settingsPresenter.ChangeSoundVolume);
			musicSlider.onValueChanged.AddListener(settingsPresenter.ChangeMusicVolume);
		}

		private void OnDisable()
		{
			backButton.onClick.AddListener(settingsPresenter.BackToMenu);
		}

		private void SetCurrentGraphicsTier()
		{
			graphicsDropdown.value = (int)Graphics.activeTier;
			graphicsDropdown.RefreshShownValue();
		}

		public async void Show()
		{
			await transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}
	
		public async void Hide()
		{
			await transform.DOLocalMoveX(-IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
		}

		public void UpdateResolutionsMenu(List<string> resolutions, int currentResolutionIndex)
		{
			resolutionDropdown.ClearOptions();

			resolutionDropdown.AddOptions(resolutions);
			resolutionDropdown.value = currentResolutionIndex;

			resolutionDropdown.RefreshShownValue();
		}

		public void SetSoundSlider(float volume)
		{
			soundSlider.value = volume;
		}

		public void SetMusicSlider(float volume)
		{
			musicSlider.value = volume;
		}
	}
}