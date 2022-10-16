using UnityEngine;
using Zenject;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Presenter;
using ResumePuzzle.Factory;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Containers
{
    public class LoadingInstaller : MonoInstaller
    {
        [SerializeField] private GameObject dfdf;
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().FromInstance(dfdf).Lazy();
            Container.Bind<ILoadScenePresenter>().To<LoadingScreenPresenter>().AsSingle().Lazy();
            Container.Bind<LoadingScreenFactory>().AsSingle().Lazy();
        }
    }
}