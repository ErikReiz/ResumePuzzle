using ResumePuzzle.Data;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class ScriptableObjectsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private ScenesData sceneData;
		[SerializeField] private MusicData musicData;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<ScenesData>().FromScriptableObject(sceneData).AsSingle().NonLazy();
			Container.Bind<MusicData>().FromScriptableObject(musicData).AsSingle().NonLazy();
		}
	}
}
