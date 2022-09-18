using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Managers
{
	public class AudioManager : MonoBehaviour, ISoundManager, IMusicManager
	{
		#region PROPERTIES
		public float SoundVolume { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public float MusicVolume { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public bool SoundEnabled { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public bool MusicEnabled { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public bool IsMusicPlaying { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		#endregion

		public void PlayMusic(AudioClip audio, float volume)
		{
			throw new System.NotImplementedException();
		}

		public void PlaySound(AudioClip audio, float volume)
		{
			throw new System.NotImplementedException();
		}
	}
}