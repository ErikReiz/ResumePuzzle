using Zenject;
using System.Threading.Tasks;
using ResumePuzzle.Data;
using ResumePuzzle.Interfaces;
using UnityEngine.AddressableAssets;

namespace ResumePuzzle.UI.Model
{
    public class LoadLevelMode
    {
		#region FIELDS
		[Inject] ISaveDataModel saveSettingsModel;
		#endregion

		public void LoadScene()
		{
			LevelSaveData saveData = saveSettingsModel.LoadSettings<LevelSaveData>();

			Task task = Addressables.LoadSceneAsync(saveData.LevelID).Task;
		}
	}
}