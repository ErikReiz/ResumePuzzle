using Zenject;
using UnityEngine;
using UnityEngine.Advertisements;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Monetization;

namespace ResumePuzzle.Managers
{
	public class AdsManager : IUnityAdsInitializationListener, IInterstitialAds
	{
		#region CONST
		private const string androidGameID = "4945117";
		#endregion

		#region FIELDS
		[Inject] private InterstitialAdsShower interstitialShower;
		#endregion

		public AdsManager()
		{
			Advertisement.Initialize(androidGameID, true, this);
		}

		public void ShowInterstitialAds()
		{
			interstitialShower.ShowAds();
		}	
		
		#region INITIALIZATION
		public void OnInitializationComplete()
		{
			Debug.Log("Initialization Completed");
		}

		public void OnInitializationFailed(UnityAdsInitializationError error, string message)
		{
			
		}

		#endregion


	}
}

