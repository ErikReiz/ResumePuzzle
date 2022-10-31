using ResumePuzzle.Interfaces;
using UnityEngine;

namespace ResumePuzzle.Managers
{
	public class AudioManager : MonoBehaviour, ISoundManager, IMusicManager
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private AudioSource musicSource;
		[SerializeField] private AudioSource sfxSource;
		#endregion

		private void Start()
		{
			PlayMusic();
		}

		public void PlayMusic()
		{
			musicSource.Play();
		}

		public void PlaySound(AudioClip audio)
		{
			sfxSource.PlayOneShot(audio);
		}
	}
}