using Profile;
using Tools;
using UnityEngine;

namespace AI
{
    public class StartFightController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/StartFightWindow"};
        private StartFightView _startFightView;

        public StartFightController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _startFightView = LoadView(placeForUi);
            _startFightView.StartFightButton.onClick.AddListener(StartFight);
        }
        
        private StartFightView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi);
            AddGameObjects(objectView);
            return objectView.GetComponent<StartFightView>();
        }

        protected override void OnDispose()
        {
            _startFightView.StartFightButton.onClick.RemoveAllListeners();
            base.OnDispose();
        }

        private void StartFight()
        {
            _profilePlayer.CurrentState.Value = GameState.Fight;
        }
    }
}