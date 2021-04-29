using Game.Trail;
using Profile;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ui
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Assets/Resources_moved/Prefabs/mainMenu.prefab"};
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            LoadAddressableView(_viewPath);
            
            var cursorTrailController = ConfigureCursorTrail();
        }

        private BaseController ConfigureCursorTrail()
        {
            var cursorTrailController = new TrailController();
            AddController(cursorTrailController);
            return cursorTrailController;
        }

        protected override void OnViewLoaded(AsyncOperationHandle<GameObject> handle)
        {
            base.OnViewLoaded(handle);
            
            _view = Object.Instantiate(handle.Result, _placeForUi).GetComponent<MainMenuView>();
            AddGameObjects(_view.gameObject);
            _view.Init(OnStateChanged);
        }

        private void OnStateChanged(GameState state)
        {
            _profilePlayer.CurrentState.Value = state;
            _profilePlayer.AnalyticTools.SendMessage(state.ToString());
        }

        protected override void OnDispose()
        {
            Addressables.ReleaseInstance(_view.gameObject);
            
            base.OnDispose();
        }
    }
}

