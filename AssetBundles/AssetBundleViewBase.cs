﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CarGameScripts.AssetBundles
{
    public class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=11x8CoJe9BBC5wSK-ayolTDB6w2pswqGA";
        private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1HEI_u7yWyzbGPPXd55lqsO9Cgdfl6SXb";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;
        [SerializeField] private DataAudioBundle[] _dataAudioBundles;

        private AssetBundle _spriteAssetBundle;
        private AssetBundle _audioAssetBundle;

        protected IEnumerator DownloadAndSetAssetBundle()
        {
            yield return GetSpritesAssetBundle();
            yield return GetAudioAssetBundle();

            if (_spriteAssetBundle == null || _audioAssetBundle == null)
            {
                Debug.LogError($"AssetBundle {_audioAssetBundle} failed to load");
                yield break;
            }

            SetDownloadAssets();

            yield return null;
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

            yield return request.SendWebRequest();

            while (!request.isDone)
            {
                yield return null;
            }

            StateRequest(request, ref _spriteAssetBundle);
        }
        
        private IEnumerator GetAudioAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);
            yield return request.SendWebRequest();
            while (!request.isDone)
                yield return null;
            StateRequest(request, ref _audioAssetBundle);
            yield return null;
        }

        private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log($"Complete: {assetBundle.name}");
            }
            else
            {
                Debug.Log(request.error);
            }
        }

        private void SetDownloadAssets()
        {
            foreach (var dataSpriteBundle in _dataSpriteBundles)
            {
                dataSpriteBundle.Image.sprite = 
                    _spriteAssetBundle.LoadAsset<Sprite>(dataSpriteBundle.NameAssetBundle);
            }

            for (var i = 0; i < _dataAudioBundles.Length; i++)
            {
                var dataAudioBundle = _dataAudioBundles[i];
                dataAudioBundle.AudioSource.clip =
                    _audioAssetBundle.LoadAsset<AudioClip>(dataAudioBundle.NameAssetBundle);
                
                dataAudioBundle.AudioSource.Play();
            }
        }
    }
}