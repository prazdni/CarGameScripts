using CarGameScripts.Analytic.Interface;
using UnityEngine.Advertisements;

namespace CarGameScripts.Analytic
{
    public class AdsRewardedVideo : IAdsRewardedVideo
    {
        public bool IsReady() => Advertisement.IsReady(_placementId);

        private readonly string _placementId;

        public AdsRewardedVideo(string placementId)
        {
            _placementId = placementId;
        }
        
        public void Show()
        {
            ShowOptions options = new ShowOptions();
            Advertisement.Show(_placementId, options);
        }
    }
}