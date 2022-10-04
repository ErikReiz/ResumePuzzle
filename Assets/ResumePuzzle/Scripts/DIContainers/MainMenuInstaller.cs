using Zenject;
using UnityEngine;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Presenter;

namespace ResumePuzzle.Containers
{
    public class MainMenuInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private MenuView menuView;
		[SerializeField] private LoadingScreenView loadingScreenView;

        [SerializeField] private Canvas canvas;
        #endregion

	    public override void InstallBindings()
        {
            Application.targetFrameRate = 60; //TODO убрать

			#region VIEW
			Container.Bind<IView>().FromInstance(menuView)
                .AsSingle().WhenInjectedInto<MainMenuPresenter>();
            Container.Bind<ILoadingScreenView>().FromInstance(loadingScreenView).AsSingle();

            Container.Bind<Canvas>().FromInstance(canvas).AsSingle();
			#endregion

			#region PRESENTER
			Container.Bind<IMenuPresenter>().To<MainMenuPresenter>().AsSingle().NonLazy();
            Container.Bind<ILoadScenePresenter>().To<LoadScenePresenter>().AsSingle().NonLazy();
			#endregion

            RunFuncAfterBindings();
        }

        private void RunFuncAfterBindings()
		{
            Container.Resolve<IMenuPresenter>().Run();
            Container.Resolve<ISettingsPresenter>().LoadSettings();
        }
    }
}
