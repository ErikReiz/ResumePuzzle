using Zenject;
using ResumePuzzle.Managers;
using ResumePuzzle.Interfaces;
using ResumePuzzle.Monetization;

namespace ResumePuzzle.Containers
{
	public class AdsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IInterstitialAds>().To<AdsManager>().AsSingle().NonLazy();

			Container.Bind<InterstitialAdsShower>().AsSingle();
		}
	}
}
