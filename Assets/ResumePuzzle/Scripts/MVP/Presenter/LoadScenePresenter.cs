using ResumePuzzle.Factory;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace ResumePuzzle.UI.Presenter
{
	public class LoadScenePresenter : ILoadScenePresenter
	{
		#region FIELDS
		[Inject] private LoadingScreenFactory loadingScreenFactory;
		[Inject] private IInterstitialAds adsManager;
		[Inject] private ILoadLevelModel loadLevelModel;

		private AsyncOperationHandle loadingOperation;
		public float LoadingPercents { get { return loadingOperation.PercentComplete; } }
		#endregion

		private async Task BeforeLoading()
		{
			ILoadingScreenView loadingScreenView = await loadingScreenFactory.Create();
			await loadingScreenView.Show();
		}

		private void WhileLoading()
		{
			loadingOperation.Completed += t => adsManager.ShowInterstitialAds();
		}

		public async void LoadLastScene()
		{
			await BeforeLoading();
			loadingOperation = loadLevelModel.LoadLastScene();
			WhileLoading();
		}

		public async void LoadNextScene()
		{
			await BeforeLoading();
			loadingOperation = loadLevelModel.LoadNextScene();
			WhileLoading();
		}

		public async void LoadMainMenu()
		{
			await BeforeLoading();
			loadingOperation = loadLevelModel.LoadMainMenu();
			WhileLoading();
		}
	}

}
