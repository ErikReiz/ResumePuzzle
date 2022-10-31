using ResumePuzzle.Interfaces;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Managers
{
	public class StartupManager : MonoBehaviour
	{
		#region FIELDS
		[Inject] private ILoadLevelModel loadLevelModel;
		#endregion

		private void Awake()
		{
			Application.targetFrameRate = 60;
			loadLevelModel.LoadMainMenu();
		}
	}
}