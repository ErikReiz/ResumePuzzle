using Zenject;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ResumePuzzle.Model
{
    public class LoadLevelModel : ILoadLevelModel
    {
		#region FIELDS
		[Inject] private ISaveDataModel saveDataModel;
		[Inject] private ScenesData scenesData;

		private SceneInstance previousScene;
		#endregion

		private AsyncOperationHandle LoadScene(ref AsyncOperationHandle<SceneInstance> currentScene)
		{
			currentScene.Completed += res => previousScene = res.Result;
			return currentScene;
		}

		public AsyncOperationHandle LoadLastScene()
		{
			try
			{
				LevelSaveData saveData = saveDataModel.LoadData<LevelSaveData>();
				var temp = Addressables.LoadSceneAsync(saveData.LevelName);

				return LoadScene(ref temp);
			}
			catch
			{
				return LoadNextScene();
			}
		}

		public AsyncOperationHandle LoadNextScene()
		{
			try
			{
				AssetReference nextScene = scenesData.GetNextScene(previousScene);

				var temp = Addressables.LoadSceneAsync(nextScene);
				return LoadScene(ref temp);
			}
			catch
			{
				return LoadMainMenu();
			}
		}

		public AsyncOperationHandle LoadMainMenu()
		{
			var temp = Addressables.LoadSceneAsync(scenesData.MainMenu);
			return LoadScene(ref temp);
		}
	}
}