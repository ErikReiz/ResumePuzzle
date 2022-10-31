using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class SettingsMenuPresenter : ISettingsPresenter
	{
		#region CONST
		private readonly string soundGroup = "Sound";
		private readonly string musicGroup = "Music";
		#endregion

		#region STATIC FILEDS
		static private SettingsSaveData settingsPresset;
		#endregion

		#region FIELDS
		[Inject] private ISettingsView settingsView;
		[Inject] private IMenuPresenter menuPresenter;
		[Inject] private ISaveDataModel saveSettingsModel;
		[Inject] private AudioMixer audioMixer;
		#endregion

		private void LoadSettings()
		{
			if (!settingsPresset.IsValid)
				settingsPresset = saveSettingsModel.LoadData<SettingsSaveData>();

			QualitySettings.SetQualityLevel(settingsPresset.QualityPresset);
			QualitySettings.resolutionScalingFixedDPIFactor = settingsPresset.ResolutionScale;
			audioMixer.SetFloat(soundGroup, settingsPresset.SoundVolume);
			audioMixer.SetFloat(musicGroup, settingsPresset.MusicVolume);

			settingsPresset.IsValid = true;
			settingsView.SetSettingsView(settingsPresset);
		}

		private void SaveSettings()
		{
			settingsPresset.ResolutionScale = QualitySettings.resolutionScalingFixedDPIFactor;
			settingsPresset.QualityPresset = QualitySettings.GetQualityLevel();

			settingsPresset.SoundVolume = GetVolumeOfGroup(soundGroup);
			settingsPresset.MusicVolume = GetVolumeOfGroup(musicGroup);

			saveSettingsModel.SaveData(settingsPresset);
		}

		private float GetVolumeOfGroup(string audioGroup)
		{
			audioMixer.GetFloat(audioGroup, out float volume);

			return volume;
		}

		public void Run()
		{
			LoadSettings();
			settingsView.Show();
		}

		public void Close()
		{
			SaveSettings();
			settingsView.Hide();
		}

		public void BackToMenu()
		{
			Close();
			menuPresenter.Run();
		}

		public void ChangeResolutionScale(float scale)
		{
			QualitySettings.resolutionScalingFixedDPIFactor = scale;
		}

		public void ChangeGraphicPresset(int pressetID)
		{
			float dpi = QualitySettings.resolutionScalingFixedDPIFactor;
			QualitySettings.SetQualityLevel(pressetID);
			QualitySettings.resolutionScalingFixedDPIFactor = dpi;
		}

		public void ChangeSoundVolume(float volume)
		{
			audioMixer.SetFloat(soundGroup, Mathf.Log10(volume) * 20);
		}

		public void ChangeMusicVolume(float volume)
		{
			audioMixer.SetFloat(musicGroup, Mathf.Log10(volume) * 20);
		}
	}
}