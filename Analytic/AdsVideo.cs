using CarGameScripts.Analytic.Interface;
using UnityEngine.Advertisements;

namespace CarGameScripts.Analytic
{
    public class AdsVideo : IAdsVideo
    {
        public bool IsReady() => Advertisement.IsReady(_placementId);

        private readonly string _placementId;

        public AdsVideo(string placementId)
        {
            _placementId = placementId;
        }
        
        public void Show()
        {
            Advertisement.Show(_placementId);
        }
    }
}