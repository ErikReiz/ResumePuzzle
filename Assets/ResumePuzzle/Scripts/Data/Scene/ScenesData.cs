using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace ResumePuzzle.Data
{
	[CreateAssetMenu(fileName = "Scene Data")]
	public class ScenesData : ScriptableObject
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private AssetReference mainMenu;
	
		[Tooltip("Put scenes in the right order in which they will be loaded")]
		[SerializeField] private AssetReference[] scenes;
		#endregion

		#region PROPERTIES
		public AssetReference MainMenu { get { return mainMenu; } }
		#endregion

		public AssetReference GetNextScene(SceneInstance scene)
		{
			string guid = AssetDatabase.GUIDFromAssetPath(scene.Scene.path).ToString();

			if (mainMenu.AssetGUID == guid)
			{
				return ContainsIndex(0) ? scenes[0] : null;
			}
			else
			{
				for(int i = 0; i < scenes.Length; i++)
				{
					if(scenes[i].AssetGUID == guid)
						return ContainsIndex(i + 1) ? scenes[i] : null;
				}

				return null;
			}
		}

		private bool ContainsIndex(int index)
		{
			if(scenes.Length <= index)
				return false;
			else
				return true;
		}
	}
}

