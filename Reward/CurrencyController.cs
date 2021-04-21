using Tools;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class CurrencyController : BaseController
    {
        private CurrencySingletonView _currencySingletonView;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/CurrencyWindow"};

        public CurrencyController()
        {
            _currencySingletonView = LoadView();
        }
        
        private CurrencySingletonView LoadView()
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<CurrencySingletonView>();
        }
    }
}