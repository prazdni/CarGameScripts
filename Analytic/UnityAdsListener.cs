using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace CarGameScripts.Analytic
{
    public class UnityAdsListener : IUnityAdsListener
    {
        public bool AdsAreReady => _adsAreReady;
        
        private string _myPlacementId;
        private bool _adsAreReady;

        public UnityAdsListener(string myPlacementId)
        {
            _myPlacementId = myPlacementId;
        }

        public void OnUnityAdsReady(string placementId)
        {
            if (placementId != _myPlacementId)
            {
                return;
            }

            _adsAreReady = true;
        }

        public void OnUnityAdsDidError(string message)
        {
            // Log the error.
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            // Optional actions to take when the end-users triggers an ad.
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.LogWarning("Failed");
                    break;
                case ShowResult.Skipped:
                    Debug.LogWarning("Skipped");
                    break;
                case ShowResult.Finished:
                    Debug.LogWarning("Finished");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(showResult), showResult, null);
            }
        }
    }
}