using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Model;
using Zenject;

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
