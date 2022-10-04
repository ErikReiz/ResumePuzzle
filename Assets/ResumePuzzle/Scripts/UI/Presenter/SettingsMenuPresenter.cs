using Zenject;
using UnityEngine;
using UnityEngine.Audio;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using System.Collections.Generic;

namespace ResumePuzzle.UI.Presenter
{
	public class SettingsMenuPresenter : ISettingsPresenter
	{
		#region STRUCT
		struct ResolutionTaskOutput
		{
			public List<string> resolutionsString;
			public int currentResolutionIndex;
		}
		#endregion

		#region CONST
		private const string soundGroup = "Sound";
		private const string musicGroup = "Music";
		#endregion

		#region FIELDS
		[Inject] private ISettingsView settingsView;
		[Inject] private IMenuPresenter menuPresenter;
		[Inject] private ISaveDataModel saveSettingsModel;
		[Inject] private AudioMixer audioMixer;

		private SettingsSaveData settingsPresset;
		#endregion

		private void LoadSettings(SettingsSaveData? presset)
		{
			if (presset != null)
			{
				settingsPresset = presset.Value;

				QualitySettings.currentLevel = (QualityLevel)settingsPresset.QualityPresset;
				QualitySettings.resolutionScalingFixedDPIFactor = settingsPresset.ResolutionScale;
				audioMixer.SetFloat(soundGroup, settingsPresset.SoundVolume);
				audioMixer.SetFloat(musicGroup, settingsPresset.MusicVolume);

				settingsView.SetSettingsView(settingsPresset);
			}
			else
			{
				settingsPresset = new();
			}
		}

		private void SaveSettings()
		{
			settingsPresset.ResolutionScale = QualitySettings.resolutionScalingFixedDPIFactor;
			settingsPresset.QualityPresset = (int)QualitySettings.currentLevel;

			settingsPresset.SoundVolume = GetVolumeOfGroup(soundGroup);
			settingsPresset.MusicVolume = GetVolumeOfGroup(musicGroup);

			saveSettingsModel.SaveData(ref settingsPresset);
		}

		private float GetVolumeOfGroup(string audioGroup)
		{
			audioMixer.GetFloat(audioGroup, out float volume);

			return volume;
		}

		public void Run()
		{
			settingsView.Show();
		}

		public void Close()
		{
			SaveSettings();
			settingsView.Hide();
		}
		
		public void LoadSettings()
		{
			LoadSettings(saveSettingsModel.LoadData<SettingsSaveData>());
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
			QualitySettings.currentLevel = (QualityLevel)pressetID;
			QualitySettings.resolutionScalingFixedDPIFactor = dpi;
		}

		public void ChangeSoundVolume(float volume)
		{
			audioMixer.SetFloat(soundGroup, volume);
		}

		public void ChangeMusicVolume(float volume)
		{
			audioMixer.SetFloat(musicGroup, volume);
		}
	}
}