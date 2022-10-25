using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Model
{
	public class LocalAddresableLoaderModel : IAddresableLoaderModel
	{
		#region FIELDS
		private GameObject loadedObject;
		#endregion

		public async Task<T> LoadAsset<T>(object assetID)
		{
			Task<GameObject> task = Addressables.InstantiateAsync(assetID).Task;
			loadedObject = await task;

			T returnComponent = loadedObject.GetComponent<T>();
			return returnComponent;
		}

		public void UnloadAsset()
		{
			if (!loadedObject)
				return;

			loadedObject.SetActive(false);

			Addressables.ReleaseInstance(loadedObject);
			loadedObject = null;
		}
	}
}

