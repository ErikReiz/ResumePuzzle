using Zenject;
using UnityEngine;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Player;

namespace ResumePuzzle.Containers
{
	public class SceneObjectsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private TopDownCharacter player;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<IPlayer>().FromInstance(player).AsSingle();
		}
	}
}
