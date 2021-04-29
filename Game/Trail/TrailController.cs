using Game.InputLogic;
using Game.Wheels;
using Profile;
using Tools;
using UnityEngine;

namespace Game.Trail
{
    internal class TrailController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Trail"};
        private TrailView _view;
        private SubscriptionProperty<float> _diff;

        public TrailController()
        {
            //ONViewLoaded += OnViewLoaded();
            //_view = LoadAddressableView(_viewPath);
            _view = LoadView<TrailView>(_viewPath, null);
        }

        private void OnViewLoaded()
        {
            _view.Init();
        }
        
        private TrailView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponentInChildren<TrailView>();
        }
    }
}