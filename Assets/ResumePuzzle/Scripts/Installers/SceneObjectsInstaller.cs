using ResumePuzzle.Interfaces;
using ResumePuzzle.Managers;
using ResumePuzzle.Player;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Containers
{
	public class SceneObjectsInstaller : MonoInstaller
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private TopDownCharacter player;
		[SerializeField] private GameManager gameManager;
		#endregion

		public override void InstallBindings()
		{
			Container.Bind<IPlayer>().FromInstance(player).AsSingle();
			Container.Bind<IGameManager>().FromInstance(gameManager).AsSingle();
		}
	}
}