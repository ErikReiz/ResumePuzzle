using Zenject;
using ResumePuzzle.Data;
using ResumePuzzle.Model;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Containers
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISerializationHelper>().To<XMLHelper>()
                .AsSingle().WhenInjectedInto(typeof(SaveDataModel)).NonLazy();
        }
    }
}
