using System;
using System.Collections.Generic;
using Amazon.Util;
using Tools;
using UnityEngine;

namespace CarGameScripts.Reward
{
    public class DailyRewardController : BaseController, IInitialize<DailyRewardView>, IExecute
    {
        private DailyRewardView _dailyRewardView;
        private List<ContainerSlotRewardView> _slots;

        private bool _isGetReward;
        private float _time;

        public void Init(DailyRewardView initObject)
        {
            _dailyRewardView = initObject;
            
            InitSlots();

            RefreshUI();
            SubscribeButtons();
        }

        private void InitSlots()
        {
            _slots = new List<ContainerSlotRewardView>();

            for (int i = 0; i < _dailyRewardView.Rewards.Count; i++)
            {
                var instanceSlot = GameObject.Instantiate(_dailyRewardView.ContainerSlotRewardView,
                    _dailyRewardView.MountRootSlotsReward, false);

                _slots.Add(instanceSlot);
            }
        }

        private void RefreshRewardsState()
        {
            _isGetReward = true;

            if (_dailyRewardView.TimeGetReward.HasValue)
            {
                var timeSpan = DateTime.Parse(AWSSDKUtils.FormattedCurrentTimestampGMT).ToUnixTimestamp() 
                               - _dailyRewardView.TimeGetReward.Value;
                
                if (timeSpan > _dailyRewardView.TimeDeadline)
                {
                    _dailyRewardView.TimeGetReward = null;
                    _dailyRewardView.CurrentSlotInActive = 0;
                }
                else
                {
                    if (timeSpan < _dailyRewardView.TimeCooldown)
                    {
                        _isGetReward = false;
                    }
                }
            }

            RefreshUI();
        }

        private void RefreshUI()
        {
            _dailyRewardView.GetRewardButton.interactable = _isGetReward;

            if (_isGetReward)
            {
                _dailyRewardView.TimerNewReward.text = "The reward is received today";
            }
            else
            {
                if (_dailyRewardView.TimeGetReward != null)
                {
                    var nextClaimTime = _dailyRewardView.TimeGetReward.Value + _dailyRewardView.TimeCooldown;
                    
                    var currentClaimCooldown = nextClaimTime.FromUnixTimestamp() - 
                                               DateTime.Parse(AWSSDKUtils.FormattedCurrentTimestampGMT);
                    var timeGetReward =
                        $"{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";
                    _dailyRewardView.TimerNewReward.text = $"Time to get the next reward: {timeGetReward}";
                }
            }

            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].SetData(_dailyRewardView.Rewards[i], i + 1, i == _dailyRewardView.CurrentSlotInActive);
            }
        }

        private void SubscribeButtons()
        {
            _dailyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
            _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
        }

        private void ClaimReward()
        {
            if (!_isGetReward)
            {
                return;
            }

            var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.None:
                    break;
                case RewardType.Wood:
                    CurrencySingletonView.Instance.AddWood(reward.CountCurrency);
                    break;
                case RewardType.Diamond:
                    CurrencySingletonView.Instance.AddDiamonds(reward.CountCurrency);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _dailyRewardView.TimeGetReward = DateTime.Parse(AWSSDKUtils.FormattedCurrentTimestampGMT).ToUnixTimestamp();
            _dailyRewardView.CurrentSlotInActive =
                (_dailyRewardView.CurrentSlotInActive + 1) % _dailyRewardView.Rewards.Count;

            RefreshRewardsState();
        }

        private void ResetTimer()
        {
            PlayerPrefs.DeleteAll();
            _dailyRewardView.CurrentSlotInActive = 0;
            _dailyRewardView.TimeGetReward = null;
            CurrencySingletonView.Instance.Reset();
        }

        public void Execute(float deltaTime)
        {
            _time += deltaTime;
            if (_time < 1)
                return;

            _time %= 1.0f;
            RefreshRewardsState();
        }
    }
}