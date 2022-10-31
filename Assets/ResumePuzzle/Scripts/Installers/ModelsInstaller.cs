using ResumePuzzle.Factory;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Model;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class ModelsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private AudioMixer audioMixer;
		#endregion

		public override void InstallBindings()
		{
			#region MODELDS
			Container.Bind<ISaveDataModel>().To<SaveDataModel>().AsSingle().NonLazy();
			Container.Bind<ILoadLevelModel>().To<LoadLevelModel>().AsSingle().NonLazy();
			Container.Bind<IAddresableLoaderModel>().To<LocalAddresableLoaderModel>()
				.AsSingle().WhenInjectedInto(typeof(LoadingScreenFactory)).NonLazy();
			#endregion

			#region OTHER
			Container.Bind<AudioMixer>().FromInstance(audioMixer);
			#endregion
		}
	}
}