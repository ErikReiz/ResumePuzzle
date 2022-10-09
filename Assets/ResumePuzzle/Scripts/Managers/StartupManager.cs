using Zenject;
using UnityEngine;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Managers
{
    public class StartupManager : MonoBehaviour
    {
		#region FIELDS
		[Inject] private ILoadLevelModel loadLevelModel;
		#endregion

		private void Awake()
		{
			loadLevelModel.LoadMainMenu();
		}
	}
}