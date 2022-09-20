using Zenject;
using UnityEngine;
using UnityEngine.Audio;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.Presenter;
using ResumePuzzle.UI.View;

namespace ResumePuzzle.Containers
{
    public class MainMenuInstaller : MonoInstaller
    {
        #region SERIALIZABLE FIELDS
        [SerializeField] private MenuView menuView;
	    [SerializeField] private SettingsView settingsView;
        [SerializeField] private AudioMixer audioMixer;    
        #endregion

	    public override void InstallBindings()
        {   
            Container.Bind<IView>().FromInstance(menuView)
                .AsCached().WhenInjectedInto<MainMenuPresenter>();

            Container.Bind<ISettingsView>().FromInstance(settingsView).AsCached();

            Container.Bind<IMenuPresenter>().To<MainMenuPresenter>().AsCached().NonLazy();
            Container.Bind<ISettingsPresenter>().To<SettingsMenuPresenter>().AsCached().NonLazy();

            Container.Bind<AudioMixer>().FromInstance(audioMixer);

            Container.Resolve<IMenuPresenter>().Run();
        }
    }
}
