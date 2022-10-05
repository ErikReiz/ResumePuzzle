using Zenject;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ResumePuzzle.UI.Model
{
    public class LoadLevelModel
    {
		#region FIELDS
		[Inject] private ISaveDataModel saveDataModel;
		[Inject] private ScenesData scenesData;

		private AsyncOperationHandle<SceneInstance> previousScene;
		#endregion

		private AsyncOperationHandle LoadScene(ref AsyncOperationHandle<SceneInstance> currentScene)
		{
			currentScene.Completed += t => UnityEngine.Debug.Log(previousScene.DebugName);
			currentScene.Completed += UnloadPreviousScene;

			return currentScene;
		}

		private void UnloadPreviousScene(AsyncOperationHandle<SceneInstance> scene)
		{
			if (previousScene.IsValid())
				Addressables.UnloadSceneAsync(previousScene).Completed += t => UnityEngine.Debug.Log("dfsd");

			previousScene = scene;
		}

		public AsyncOperationHandle LoadLastScene()
		{
			LevelSaveData saveData = saveDataModel.LoadData<LevelSaveData>();

			if (saveData.LevelID == null)
				return LoadNextScene();

			var temp = Addressables.LoadSceneAsync(saveData.LevelID);
			return LoadScene(ref temp);
		}

		public AsyncOperationHandle LoadNextScene()
		{
			try
			{
				AssetReference nextScene = scenesData.GetNextScene(previousScene.Result);
				if (nextScene == null)
					return default;

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