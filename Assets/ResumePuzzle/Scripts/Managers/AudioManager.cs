using Zenject;
using UnityEngine;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

namespace ResumePuzzle.Managers
{
	public class AudioManager : MonoBehaviour, ISoundManager, IMusicManager
	{
		#region FIELDS
		[Inject] private MusicData musicData;
		#endregion

		private void OnEnable()
		{
			SceneManager.sceneLoaded += GetMusicByScene;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= GetMusicByScene;
		}

		private async void GetMusicByScene(Scene scene, LoadSceneMode loadMode)
		{
			AudioClip musicClip = musicData.GetMusicByScene(scene);
			PlayMusic(musicClip);
		}

		public void PlayMusic(AudioClip audio)
		{
			Debug.Log(audio.name);
		}

		public void PlaySound(AudioClip audio)
		{
			throw new System.NotImplementedException();
		}
	}
}