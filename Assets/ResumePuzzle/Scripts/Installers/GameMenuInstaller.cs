using Zenject;
using UnityEngine;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Presenter;
using ResumePuzzle.Factory;

namespace ResumePuzzle.Containers
{
	public class GameMenuInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[Header("Canvas")]
		[SerializeField] private Canvas hudCanvas;
		[SerializeField] private Canvas pauseCanvas;

		[Header("View")]
		[SerializeField] private MenuView menuView;
		[SerializeField] private HudView hudView;
		#endregion

		public override void InstallBindings()
		{
			#region PRESENTER
			Container.Bind<IMenuPresenter>().To<PauseMenuPresenter>().AsSingle();
			Container.Bind<IHudPresenter>().To<HudPresenter>().AsSingle();
			#endregion

			#region VIEW
			Container.Bind<IMenuView>().FromInstance(menuView).AsSingle();
			Container.Bind<IView>().FromInstance(hudView).AsSingle();

			Container.Bind<Canvas>().FromInstance(hudCanvas)
				.AsSingle().WhenInjectedInto(typeof(HudView));
			Container.Bind<Canvas>().FromInstance(pauseCanvas)
				.AsSingle().WhenInjectedInto(typeof(MenuView));
			#endregion
		}
	}
}