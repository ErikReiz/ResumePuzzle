using UnityEngine;
using Zenject;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Presenter;

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