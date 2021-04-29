using System;
using System.Collections.Generic;
using Tools;
using Ui;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public abstract class BaseController : IDisposable
{
    protected event Action<AsyncOperationHandle<GameObject>> ONViewLoaded;
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;

    protected BaseController()
    {
        ONViewLoaded += OnViewLoaded;
    }
    
    public void Dispose()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
            if (_baseControllers != null)
            {
                foreach (BaseController baseController in _baseControllers)
                {
                    baseController?.Dispose();
                }
                
                _baseControllers.Clear();
            }

            if (_gameObjects != null)
            {
                foreach (GameObject cachedGameObject in _gameObjects)
                {
                    Object.Destroy(cachedGameObject);
                }
                
                _gameObjects.Clear();
            }
            
            OnDispose();
        }
    }

    protected void AddController(BaseController baseController)
    {
        _baseControllers ??= new List<BaseController>();
        _baseControllers.Add(baseController);
    }

    protected void AddGameObjects(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }

    protected T LoadView<T>(ResourcePath resourcePath, Transform placeForUi)
    {
        GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(resourcePath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<T>();
    }
    
    protected void LoadAddressableView(ResourcePath resourcePath)
    {
        Addressables.LoadAssetAsync<GameObject>(resourcePath.PathResource).Completed += 
            handle => ONViewLoaded.Invoke(handle);
    }
    
    protected virtual void OnViewLoaded(AsyncOperationHandle<GameObject> handle)
    {
    }

    protected virtual void OnDispose()
    {
        
    }
}
