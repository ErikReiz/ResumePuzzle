using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
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

		private float GetVolumeOfGroup(string audioGroup)
		{
			audioMixer.GetFloat(audioGroup, out float volume);

			return volume;
		}

		private float MixerVolumeFromSlider(float volume)
		{
			return Mathf.Log10(volume) * 20;
		}

		public void ApplySettings(SettingsSaveData loadedSettings)
		{
			settingsPresset = loadedSettings;
			ApplySettings();
		}

		public void ApplySettings()
		{
			QualitySettings.SetQualityLevel(settingsPresset.QualityPresset);
			QualitySettings.resolutionScalingFixedDPIFactor = settingsPresset.ResolutionScale;
			audioMixer.SetFloat(soundGroup, settingsPresset.SoundVolume);
			audioMixer.SetFloat(musicGroup, settingsPresset.MusicVolume);

			settingsPresset.IsValid = true;
		}

		public ref SettingsSaveData SetSettings()
		{
			settingsPresset.ResolutionScale = QualitySettings.resolutionScalingFixedDPIFactor;
			settingsPresset.QualityPresset = QualitySettings.GetQualityLevel();

			settingsPresset.SoundVolume = GetVolumeOfGroup(soundGroup);
			settingsPresset.MusicVolume = GetVolumeOfGroup(musicGroup);

			return ref settingsPresset;
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
			audioMixer.SetFloat(soundGroup, MixerVolumeFromSlider(volume));
		}

		public void ChangeMusicVolume(float volume)
		{
			audioMixer.SetFloat(musicGroup, MixerVolumeFromSlider(volume));
		}

		public bool AreSettingsValid()
		{
			return settingsPresset.IsValid;
		}

	}
}