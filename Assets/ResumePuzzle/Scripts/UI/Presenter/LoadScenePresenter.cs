using Zenject;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ResumePuzzle.UI.Presenter
{
	public class LoadScenePresenter : ILoadScenePresenter
	{
		#region FIELDS
		[Inject] private ILoadingScreenView loadingScreenView;
		[Inject] private IInterstitialAds ads;
		[Inject] private ILoadLevelModel loadLevelModel;
		#endregion

		private async Task WhenLoading(AsyncOperationHandle operationHandle)
		{
			await UpdateLoadingBar(operationHandle);
			ads.ShowInterstitialAds();
		}

		private async Task UpdateLoadingBar(AsyncOperationHandle operationHandle)
		{
			await Task.Run(() =>
			{
				while (!operationHandle.IsDone)
				{
					loadingScreenView.UpdateLoadingBar(operationHandle.PercentComplete / 0.9f);
					Task.Delay(50);
				}
			});
		}

		public async void LoadLastScene()
		{
			await loadingScreenView.Show();

			AsyncOperationHandle operationHandle = loadLevelModel.LoadLastScene();
			await WhenLoading(operationHandle);
		}

		public async void LoadNextScene()
		{
			await loadingScreenView.Show();

			AsyncOperationHandle operationHandle = loadLevelModel.LoadNextScene();
			await WhenLoading(operationHandle);
		}

		public async void LoadMainMenu()
		{
			await loadingScreenView.Show();

			AsyncOperationHandle operationHandle = loadLevelModel.LoadMainMenu();
			await WhenLoading(operationHandle);
		}
	}

}
