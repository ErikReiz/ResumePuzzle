using ResumePuzzle.Data;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class ScenesDataInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private ScenesData data;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<ScenesData>().FromScriptableObject(data).AsSingle().NonLazy();
		}
	}
}
