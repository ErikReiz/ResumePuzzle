using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.Presenter;
using ResumePuzzle.UI.View;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class SettingsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private SettingsView settingsView;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<ISettingsView>().FromInstance(settingsView).AsSingle();
			Container.Bind<ISettingsPresenter>().To<SettingsMenuPresenter>().AsSingle();
		}
	}
}
