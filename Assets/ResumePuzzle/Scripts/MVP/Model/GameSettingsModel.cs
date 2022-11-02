using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace ResumePuzzle.Model
{
	public class GameSettingsModel : IGameSettingsModel
	{
		#region CONST
		private readonly string soundGroup = "Sound";
		private readonly string musicGroup = "Music";
		#endregion

		#region PROPERTIES
		public ref SettingsSaveData Settings { get { return ref settingsPresset; } }
		#endregion

		#region FIELDS
		[Inject] private AudioMixer audioMixer;

		private SettingsSaveData settingsPresset;
		#endregion

		private float MixerVolumeFromSlider(float volume)
		{
			return Mathf.Log10(volume) * 20;
		}

		public void InitializeSettings(SettingsSaveData savedSettings)
		{
			settingsPresset = savedSettings;
			ApplySettings();
		}

		public void ApplySettings()
		{
			QualitySettings.SetQualityLevel(settingsPresset.QualityPresset);
			QualitySettings.resolutionScalingFixedDPIFactor = settingsPresset.ResolutionScale;
			audioMixer.SetFloat(soundGroup, MixerVolumeFromSlider(settingsPresset.SoundVolume));
			audioMixer.SetFloat(musicGroup, MixerVolumeFromSlider(settingsPresset.MusicVolume));
		}

		public void ChangeResolutionScale(float scale)
		{
			settingsPresset.ResolutionScale = scale;
		}

		public void ChangeGraphicPresset(int pressetID)
		{
			settingsPresset.QualityPresset = pressetID;
		}

		public void ChangeSoundVolume(float volume)
		{
			settingsPresset.SoundVolume = volume;
		}

		public void ChangeMusicVolume(float volume)
		{
			settingsPresset.MusicVolume = volume;
		}
	}
}