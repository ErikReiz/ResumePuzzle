using Zenject;
using ResumePuzzle.Data;
using ResumePuzzle.Factory;
using ResumePuzzle.Interfaces;
using ResumePuzzle.UI.Model;

namespace ResumePuzzle.Containers
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISerializationHelper>().To<XMLHelper>()
                .AsSingle().WhenInjectedInto(typeof(SaveDataModel)).NonLazy();

            Container.Bind<IAddresableLoaderModel>().To<LocalAddresableLoaderModel>()
                .AsSingle().WhenInjectedInto(typeof(LoadingScreenFactory)).NonLazy();
        }
    }
}
