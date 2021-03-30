using System;
using System.Collections;
using CarGameScripts.Analytic.Interface;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace CarGameScripts.Analytic
{
    public class UnityAds : MonoBehaviour
    {
        private const string GOOGLE_PLAY_ID = "4067093";
        private const string APP_STORE_ID = "4067092";

        private const string PLACEMENT_ID_BANNER = "banner";
        private const string PLACEMENT_ID_REWARDED_VIDEO = "rewardedVideo";
        private const string PLACEMENT_ID_VIDEO = "video";

        [SerializeField] private Button _bannerButton;
        [SerializeField] private Button _videoButton;
        [SerializeField] private Button _rewardedVideoButton;
        [SerializeField] private BannerPosition _bannerPosition;

        private IAdsBanner _adsBanner;
        private IAdsVideo _adsVideo;
        private IAdsRewardedVideo _adsRewardedVideo;
        private IUnityAdsListener _unityAdsListener;

        private void Awake()
        {
            string gameId = GOOGLE_PLAY_ID;
            
#if UNITY_ANDROID
            gameId = GOOGLE_PLAY_ID;
#elif UNITY_IOS
        gameId = APP_STORE_ID;
#endif

            _adsBanner = new AdsBanner(PLACEMENT_ID_BANNER);
            _adsVideo = new AdsVideo(PLACEMENT_ID_VIDEO);
            _adsRewardedVideo = new AdsRewardedVideo(PLACEMENT_ID_REWARDED_VIDEO);
            _unityAdsListener = new UnityAdsListener(PLACEMENT_ID_REWARDED_VIDEO);
            
            Advertisement.Initialize(gameId);
        }

        private void OnEnable()
        {
            Advertisement.AddListener(_unityAdsListener);
            _bannerButton.onClick.AddListener(ShowAdsBanner);
            _videoButton.onClick.AddListener(ShowAdsVideo);
            _rewardedVideoButton.onClick.AddListener(ShowRewardedVideo);
        }

        private void OnDisable()
        {
            Advertisement.RemoveListener(_unityAdsListener);
        }

        private void ShowAdsBanner()
        {
            StartCoroutine(ShowAdsBannerReady());
        }

        private IEnumerator ShowAdsBannerReady()
        {
            while (!_adsBanner.IsReady())
            {
                yield return new WaitForSeconds(1.0f);
            }
            
            _adsBanner.Show(_bannerPosition);
        }

        private void ShowAdsVideo()
        {
            if (_adsVideo.IsReady())
            {
                _adsVideo.Show();
            }
        }

        private void ShowRewardedVideo()
        {
            if (_adsRewardedVideo.IsReady())
            {
                _adsRewardedVideo.Show();
            }
        }
    }
}