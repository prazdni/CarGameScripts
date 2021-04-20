using Game.Trail;
using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(OnStateChanged);

            var cursorTrailController = ConfigureCursorTrail();
        }
        
        private BaseController ConfigureCursorTrail()
        {
            var cursorTrailController = new TrailController();
            AddController(cursorTrailController);
            return cursorTrailController;
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void OnStateChanged(GameState state)
        {
            _profilePlayer.CurrentState.Value = state;
            _profilePlayer.AnalyticTools.SendMessage(state.ToString());
        }
    }
}

