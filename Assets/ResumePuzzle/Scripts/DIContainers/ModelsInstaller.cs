using Zenject;
using UnityEngine;
using UnityEngine.Audio;
using ResumePuzzle.UI.Model;
using ResumePuzzle.Interfaces;

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
			Container.Bind<ISaveDataModel>().To<SaveSettingsModel>().AsCached().NonLazy();
            Container.Bind<LoadLevelModel>().ToSelf().AsCached().NonLazy();
			#endregion

			#region OTHER
			Container.Bind<AudioMixer>().FromInstance(audioMixer);
			#endregion

			Container.Resolve<LoadLevelModel>().LoadMainMenu();
        }
    }
}