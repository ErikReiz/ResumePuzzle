using Zenject;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using ResumePuzzle.Interfaces;
using System.Text;
using System.Threading.Tasks;
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
		[Inject] private AudioMixer audioMixer;

		private Resolution[] resolutions;
		#endregion

		public SettingsMenuPresenter()
		{
			Task.Run(GetAvailableResolutions)
				.ContinueWith(resolutionTaskOutput =>
				{
					ResolutionTaskOutput taskOutput = resolutionTaskOutput.Result;
					settingsView.UpdateResolutionsMenu(taskOutput.resolutionsString, taskOutput.currentResolutionIndex);
				});
		}

		private Task<ResolutionTaskOutput> GetAvailableResolutions()
		{
			if(resolutions != null) { return null; }

			resolutions = Screen.resolutions;
			ResolutionTaskOutput resolutionTaskOutput = new();

			StringBuilder builder = new();
			
			foreach(Resolution resolution in resolutions)
			{
				builder.Clear();

				builder.Append(resolution.width);
				builder.Append("X");
				builder.Append(resolution.height);

				resolutionTaskOutput.resolutionsString.Add(builder.ToString());
			}

			return Task.FromResult<ResolutionTaskOutput>(resolutionTaskOutput);
		}

		private float GetVolumeOfGroup(string audioGroup)
		{
			audioMixer.GetFloat(audioGroup, out float volume);
			volume /= 20;
			volume = Mathf.Pow(10, volume);

			return volume;
		}

		private void SetSliders()
		{
			float soundSlider = GetVolumeOfGroup(soundGroup);
			float musicSlider = GetVolumeOfGroup(musicGroup);

			settingsView.SetSoundSlider(soundSlider);
			settingsView.SetMusicSlider(musicSlider);
		}

		public void Run()
		{

			settingsView.Show();
			SetSliders();
		}

		public void Close()
		{
			settingsView.Hide();
		}

		public void BackToMenu()
		{
			Close();
			menuPresenter.Run();
			PlayerPrefs.Save();
		}

		public void ChangeResolution(int resolutionID)
		{
			Resolution resolution = resolutions[resolutionID];
			Screen.SetResolution(resolution.width, resolution.height, true);
		}

		public void ChangeGraphicPresset(int pressetID)
		{
			Graphics.activeTier = (GraphicsTier)pressetID;
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