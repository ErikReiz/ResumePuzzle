using ResumePuzzle.Interfaces;
using ResumePuzzle.Data;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.Managers
{
	public class StartupManager : MonoBehaviour
	{
		#region FIELDS
		[Inject] private ILoadLevelModel loadLevelModel;
		[Inject] private ISaveDataModel saveModel;
		[Inject] private IGameSettingsModel gameSettingsModel;
		#endregion

		private void Awake()
		{
			Application.targetFrameRate = 60;

			gameSettingsModel.ApplySettings(saveModel.LoadData<SettingsSaveData>());
			loadLevelModel.LoadMainMenu();
		}
	}
}