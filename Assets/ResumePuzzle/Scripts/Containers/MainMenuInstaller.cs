using UnityEngine;
using Zenject;
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
	    #endregion

	    public override void InstallBindings()
        {
            Container.Bind<IMenuView>().FromInstance(menuView).AsSingle();
            Container.Bind<ISettingsView>().FromInstance(settingsView).AsSingle();  
        
            Container.Bind<IPresenter>().To<MainMenuPresenter>()
                .AsSingle().WithConcreteId("MMP").NonLazy();

            Container.Bind<IPresenter>().To<SettingsMenuPresenter>().FromNew()
                .AsSingle().WithConcreteId("SMP");
        }
    }
}
