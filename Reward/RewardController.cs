using Tools;
using Ui;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class RewardController : BaseController, IExecute
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/RewardWindow"};
        private InstallView _view;
        private DailyRewardController _dailyRewardController;

        public RewardController()
        {
            _dailyRewardController = new DailyRewardController();
            AddController(_dailyRewardController);
            _view = LoadView();
            _view.Init(_dailyRewardController);
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
    }
}