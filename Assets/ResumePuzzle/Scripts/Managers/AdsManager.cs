using Zenject;
using UnityEngine;
using UnityEngine.Advertisements;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Monetization;
using UnityEngine.Events;

namespace ResumePuzzle.Managers
{
	public class AdsManager : IUnityAdsInitializationListener, IInterstitialAds
	{
		#region CONST
		private const string editorID = "4945117";
		private const string androidGameID = "4945118";
		private string ID;
		#endregion

		#region FIELDS
		[Inject] private InterstitialAdsShower interstitialShower;
		#endregion

		public AdsManager()
		{
			if (Application.isEditor)
				ID = editorID;
			else
				ID = androidGameID;

			Advertisement.Initialize(ID, true, this);
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

