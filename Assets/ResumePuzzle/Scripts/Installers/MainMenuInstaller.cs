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

        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private Canvas loadingScreenCanvas;
        #endregion

        public override void InstallBindings()
        {
			#region VIEW
			Container.Bind<IMenuView>().FromInstance(menuView)
                .AsSingle().WhenInjectedInto<MainMenuPresenter>();
            Container.Bind<ILoadingScreenView>()
                .FromInstance(loadingScreenView).AsSingle();

            Container.Bind<Canvas>().FromInstance(mainCanvas)
                .AsSingle().WhenInjectedInto(typeof(MenuView));
            Container.Bind<Canvas>().FromInstance(loadingScreenCanvas)
                .AsSingle().WhenInjectedInto(typeof(LoadingScreenView));
            #endregion

            #region PRESENTER
            Container.Bind<IMenuPresenter>().To<MainMenuPresenter>().AsSingle().NonLazy();
			#endregion

            RunFuncAfterBindings();
        }

        private void RunFuncAfterBindings()
		{
            Container.Resolve<IMenuPresenter>().Run();
        }
    }
}
