using Game.Trail;
using Profile;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Ui
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Assets/Resources_moved/Prefabs/mainMenu.prefab"};
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            LoadView(placeForUi);

            var cursorTrailController = ConfigureCursorTrail();
        }
        
        private BaseController ConfigureCursorTrail()
        {
            var cursorTrailController = new TrailController();
            AddController(cursorTrailController);
            return cursorTrailController;
        }

        private void LoadView(Transform placeForUi)
        {
            Addressables.LoadAssetAsync<GameObject>(_viewPath.PathResource).Completed +=
                handle =>
                {
                    _view = Object.Instantiate(handle.Result, placeForUi).GetComponent<MainMenuView>();
                    AddGameObjects(_view.gameObject);
                    _view.Init(OnStateChanged);
                };
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

