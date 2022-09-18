using UnityEngine;

namespace ResumePuzzle.Interfaces
{
	public interface IMusicManager
	{
		#region PROPERTIES
		float MusicVolume { get; set; }
		bool MusicEnabled { get; set; }
		bool IsMusicPlaying { get; set; }
		#endregion

		#region METHODS
		void PlayMusic(AudioClip audio, float volume);
		#endregion
	}
}
