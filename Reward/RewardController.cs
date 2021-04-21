using Profile;
using Tools;
using Ui;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class RewardController : BaseController, IExecute
    {
        private readonly SubscriptionProperty<GameState> _currentState;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/RewardWindow"};
        private InstallView _view;
        private DailyRewardController _dailyRewardController;

        public RewardController(SubscriptionProperty<GameState> currentState)
        {
            _currentState = currentState;
            _dailyRewardController = new DailyRewardController();
            AddController(_dailyRewardController);
            _view = LoadView();
            _view.Init(_dailyRewardController);
            _currentState.SubscribeOnChange(OnChangeGameState);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _currentState.UnSubscriptionOnChange(OnChangeGameState);
        }

        private InstallView LoadView()
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<InstallView>();
        }

        public void Execute(float deltaTime)
        {
            _dailyRewardController.Execute(deltaTime);
        }
        
        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _view.SetPopupButtonInteractable(true);
                    break;
                default:
                    _view.SetPopupButtonInteractable(false);
                    break;
            }
        }
    }
}