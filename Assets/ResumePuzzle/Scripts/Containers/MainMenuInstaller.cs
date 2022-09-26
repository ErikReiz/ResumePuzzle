using Zenject;
using UnityEngine;
using UnityEngine.Audio;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.View;
using ResumePuzzle.UI.Model;
using ResumePuzzle.UI.Presenter;

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
            Container.Bind<ISaveSettingsModel>().To<SaveSettingsModel>().AsCached().NonLazy(); 

            Container.Bind<IView>().FromInstance(menuView)
                .AsCached().WhenInjectedInto<MainMenuPresenter>();
            Container.Bind<ISettingsView>().FromInstance(settingsView).AsCached();

            Container.Bind<IMenuPresenter>().To<MainMenuPresenter>().AsCached().NonLazy();
            Container.Bind<ISettingsPresenter>().To<SettingsMenuPresenter>().AsCached().NonLazy();

            Container.Bind<AudioMixer>().FromInstance(audioMixer);

            RunFuncOnBinded();
        }

        private void RunFuncOnBinded()
		{
            Container.Resolve<IMenuPresenter>().Run();
            Container.Resolve<ISettingsPresenter>().LoadSettings();
        }
    }
}
