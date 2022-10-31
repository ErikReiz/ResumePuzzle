using ResumePuzzle.Factory;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.Presenter;
using UnityEngine;
using Zenject;

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