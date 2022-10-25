using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ResumePuzzle.Data
{
    [CreateAssetMenu(fileName = "Music Data")]
    public class MusicData : ScriptableObject
    {
		#region STRUCT
		[System.Serializable]
        private struct MusicAndLevel
		{
			public SceneAsset SceneRef;
			public AudioClip Clip;
		}
		#endregion

		#region SERIALIZABLE FIELDS
		[SerializeField] private List<MusicAndLevel> musicByLevels;
		#endregion

		#region FIELDS
		Dictionary<Scene, AudioClip> musicByLevelDictionary;
		#endregion

		private void Awake()
		{
			musicByLevelDictionary = new();

			Task.Run(() =>
			{
				Debug.Log(musicByLevels.Count);
				foreach (var temp in musicByLevels)
				{
					Scene scene = SceneManager.GetSceneByName(temp.SceneRef.name);
					Debug.Log(scene.name);
					musicByLevelDictionary.Add(scene, temp.Clip);
				}
				Debug.Log(musicByLevelDictionary.Count);
			});

		}

		public AudioClip GetMusicByScene(Scene scene)
		{
			musicByLevelDictionary.TryGetValue(scene, out AudioClip audio);
			return audio;
		}
	}
}