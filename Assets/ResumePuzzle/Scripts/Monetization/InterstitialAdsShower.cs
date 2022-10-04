using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

namespace ResumePuzzle.Monetization
{
	public class InterstitialAdsShower : IUnityAdsLoadListener, IUnityAdsShowListener
	{
		#region CONST
		private const string androidAdID = "Interstitial_Android";
		#endregion

		public void ShowAds()
		{
			Advertisement.Load(androidAdID, this);
			Advertisement.Show(androidAdID, this);
		}
		
		public void OnUnityAdsAdLoaded(string placementId){}

		public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) //TODO Analytics
		{
			Debug.Log($"Load failed {error} {message}");
		}

		public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
		{
			Debug.Log($"Show failed {error} {message}");
		}

		public void OnUnityAdsShowStart(string placementId){}

		public void OnUnityAdsShowClick(string placementId)
		{
			throw new System.NotImplementedException();
		}

		public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{

		}
	}
}

