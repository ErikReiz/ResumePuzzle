using ResumePuzzle.Data;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class ScriptableObjectsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private ScenesData sceneData;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<ScenesData>().FromScriptableObject(sceneData).AsSingle().NonLazy();
		}
	}
}
