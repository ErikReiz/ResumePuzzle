using UnityEngine;

namespace ResumePuzzle.Interfaces
{
	public interface ISoundManager
	{
		#region PROPERTIES
		float SoundVolume { get; set; }
		bool SoundEnabled { get; set; }
		#endregion

		#region METHODS
		void PlaySound(AudioClip audio, float volume);
		#endregion
	}
}