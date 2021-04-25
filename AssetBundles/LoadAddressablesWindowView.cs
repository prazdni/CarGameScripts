using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace CarGameScripts.AssetBundles
{
    public class LoadAddressablesWindowView : AssetBundleViewBase
    {
        [SerializeField] private AssetReference _loadPrefab;
        [SerializeField] private RectTransform _mountSpawnTransform;
        [SerializeField] private Button _spawnAssetsButton;
        
        private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = 
            new List<AsyncOperationHandle<GameObject>>();

        private void Start()
        {
            _spawnAssetsButton.onClick.AddListener(CreateAddressablesPrefab);
        }

        private void OnDestroy()
        {
            foreach (var addressablePrefab in _addressablePrefabs)
            {
                Addressables.ReleaseInstance(addressablePrefab);
            }
            
            _addressablePrefabs.Clear();
        }

        private void CreateAddressablesPrefab()
        {
            var addressablePrefab = 
                Addressables.InstantiateAsync(_loadPrefab, _mountSpawnTransform);
            _addressablePrefabs.Add(addressablePrefab);
        }
    }
}