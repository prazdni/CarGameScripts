using CarGameScripts.Analytic.Interface;
using UnityEngine.Advertisements;

namespace CarGameScripts.Analytic
{
    internal class AdsBanner : IAdsBanner
    {
        public bool IsReady() => Advertisement.IsReady(_placementId);

        private readonly string _placementId;

        public AdsBanner(string placementId)
        {
            _placementId = placementId;
        }
        
        public void Show(BannerPosition bannerPosition)
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Show(_placementId);
        }
    }
}