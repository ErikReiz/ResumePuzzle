using Zenject;
using UnityEngine;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Presenter;

namespace ResumePuzzle.Containers
{
	public class GameMenuInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[Header("Canvas")]
		[SerializeField] private Canvas hudCanvas;
		[SerializeField] private Canvas pauseCanvas;
		[SerializeField] private Canvas loadingScreenCanvas;

		[Header("View")]
		[SerializeField] private MenuView menuView;
		[SerializeField] private HudView hudView;
		[SerializeField] private LoadingScreenView loadingScreenView;
		#endregion

		public override void InstallBindings()
		{
			#region PRESENTER
			Container.Bind<IMenuPresenter>().To<PauseMenuPresenter>().AsSingle().NonLazy();
			Container.Bind<IHudPresenter>().To<HudPresenter>().AsSingle().NonLazy();
			Container.Bind<ILoadScenePresenter>().To<LoadScenePresenter>().AsSingle().NonLazy();
			#endregion

			#region VIEW
			Container.Bind<IMenuView>().FromInstance(menuView).AsSingle();
			Container.Bind<IView>().FromInstance(hudView).AsSingle();
			Container.Bind<ILoadingScreenView>()
				.FromInstance(loadingScreenView).AsSingle();

			Container.Bind<Canvas>().FromInstance(hudCanvas)
				.AsSingle().WhenInjectedInto(typeof(HudView));
			Container.Bind<Canvas>().FromInstance(pauseCanvas)
				.AsSingle().WhenInjectedInto(typeof(MenuView));
			Container.Bind<Canvas>().FromInstance(loadingScreenCanvas)
				.AsSingle().WhenInjectedInto(typeof(LoadingScreenView));
			#endregion
		}
	}
}
