using Profile;
using Tools;
using Ui;
using UnityEngine;

namespace CarGameScripts.UI
{
    public class UIController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/BackToMenu"};
        private StartStateButton _view;

        public UIController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.AddListener(OnStateChanged);
        }
        
        private void OnStateChanged(GameState state)
        {
            _profilePlayer.CurrentState.Value = state;
            _profilePlayer.AnalyticTools.SendMessage(state.ToString());
        }
        
        private StartStateButton LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<StartStateButton>();
        }
    }
}