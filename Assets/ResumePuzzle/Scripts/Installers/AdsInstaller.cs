using ResumePuzzle.Interfaces;
using ResumePuzzle.Managers;
using ResumePuzzle.Monetization;
using Zenject;

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
