using ResumePuzzle.Interfaces;
using ResumePuzzle.Data;
using UnityEngine;
using Zenject;
using ResumePuzzle.Model;

namespace ResumePuzzle.Managers
{
	public class StartupManager : MonoBehaviour
	{
		#region FIELDS
		[Inject] private ILoadLevelModel loadLevelModel;
		[Inject] private ISaveDataModel saveModel;
		[Inject] private IGameSettingsModel gameSettingsModel;
		#endregion

		private void Start()
		{
			Application.targetFrameRate = 60;

			gameSettingsModel.InitializeSettings(saveModel.LoadData<SettingsSaveData>());
			loadLevelModel.LoadMainMenu();
		}
	}
}