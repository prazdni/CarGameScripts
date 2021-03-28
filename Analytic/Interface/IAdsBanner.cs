using UnityEngine.Advertisements;

namespace CarGameScripts.Analytic.Interface
{
    public interface IAdsBanner
    {
        bool IsReady();
        void Show(BannerPosition bannerPosition);
    }
}