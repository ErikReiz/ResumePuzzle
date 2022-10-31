using ResumePuzzle.Interfaces;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Managers
{
	public class GameManager : MonoBehaviour, IGameManager
	{
		#region FIELDS
		[Inject] private ILoadScenePresenter loadScenePresenter;
		#endregion

		public void EndGame()
		{
			loadScenePresenter.LoadNextScene();
		}
	}
}