using Profile;
using Tools;
using Ui;
using UnityEngine;

namespace CarGameScripts.UI
{
    public sealed class UIController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/BackToMenu"};
        private StartStateButton _view;

        public UIController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<StartStateButton>(_viewPath, placeForUi);
            _view.AddListener(OnStateChanged);
        }
        
        private void OnStateChanged(GameState state)
        {
            _profilePlayer.CurrentState.Value = state;
            _profilePlayer.AnalyticTools.SendMessage(state.ToString());
        }
    }
}