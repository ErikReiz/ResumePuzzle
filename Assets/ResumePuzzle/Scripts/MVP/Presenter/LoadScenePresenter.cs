using Zenject;
using ResumePuzzle.Interfaces;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ResumePuzzle.UI.Presenter
{
	public class LoadScenePresenter : ILoadScenePresenter
	{
		#region FIELDS
		[Inject] private ILoadingScreenView loadingScreenView;
		[Inject] private IInterstitialAds ads;
		[Inject] private ILoadLevelModel loadLevelModel;

		private AsyncOperationHandle loadingOperation;
		public float LoadingPercents { get { return loadingOperation.PercentComplete; } }
		#endregion

		private void WhenLoading()
		{
			loadingOperation.Completed += t => ads.ShowInterstitialAds();
		}

		public async void LoadLastScene()
		{
			await loadingScreenView.Show();

			loadingOperation = loadLevelModel.LoadLastScene();
			WhenLoading();
		}

		public async void LoadNextScene()
		{
			await loadingScreenView.Show();

			loadingOperation = loadLevelModel.LoadNextScene();
			WhenLoading();
		}

		public async void LoadMainMenu()
		{
			await loadingScreenView.Show();
			loadingOperation = loadLevelModel.LoadMainMenu();
			WhenLoading();
		}
	}

}
