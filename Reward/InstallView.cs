using System;
using Tools;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class InstallView : MonoBehaviour, IInitialize<DailyRewardController>
    {
        [SerializeField] private DailyRewardView _dailyRewardView;

        private DailyRewardController _dailyRewardController;

        public void Init(DailyRewardController initObject)
        {
            initObject.Init(_dailyRewardView);
        }
    }
}