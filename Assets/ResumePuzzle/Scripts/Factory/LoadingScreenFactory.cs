using Zenject;
using ResumePuzzle.Interfaces;
using UnityEngine;
using System.Threading.Tasks;

namespace ResumePuzzle.Factory
{
	public class LoadingScreenFactory
	{
		#region FIELDS
		[Inject] private IAddresableLoaderModel loader;
		#endregion

		public Task<ILoadingScreenView> Create()
		{
			return loader.LoadAsset<ILoadingScreenView>("LoadingScreen");
		}

		public void Unload()
		{
			loader.UnloadAsset();
		}
	}
}