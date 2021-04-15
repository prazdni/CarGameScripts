using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Reward
{
    public class DailyRewardView : MonoBehaviour
    {
        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

        [Header("Settings Time Get Reward")] 
        [SerializeField] private float _timeCooldown = 86400;
        [SerializeField] private float _timeDeadline = 172800;

        [Header("Settings Rewards"), SerializeField] private List<Reward> _rewards;

        [Header("Ui Elements")]
        [SerializeField] private TMP_Text _timerNewReward;
        [SerializeField] private Transform _mountRootSlotsReward;
        [SerializeField] private ContainerSlotRewardView _containerSlotRewardView;
        [SerializeField] private Button _getRewardButton;
        [SerializeField] private Button _resetButton;

        public float TimeCooldown => _timeCooldown;
        public float TimeDeadline => _timeDeadline;
        public List<Reward> Rewards => _rewards;
        public TMP_Text TimerNewReward => _timerNewReward;
        public Transform MountRootSlotsReward => _mountRootSlotsReward;
        public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;
        public Button GetRewardButton => _getRewardButton;
        public Button ResetButton => _resetButton;
        
        private readonly Dictionary<string, int> _currentSlotInActive = new Dictionary<string, int>();
        private readonly Dictionary<string, DateTime?> _timeGetReward = new Dictionary<string, DateTime?>();

        public int CurrentSlotInActive
        {
            get => _currentSlotInActive[CurrentSlotInActiveKey];
            set => _currentSlotInActive[CurrentSlotInActiveKey] = value;
        }

        public DateTime? TimeGetReward
        {
            get => _timeGetReward[TimeGetRewardKey];
            set => _timeGetReward[TimeGetRewardKey] = value;
        }

        private void Awake()
        {
            SetCurrentSlot();
            
            SetCurrentTimeGetReward();
        }

        private void SetCurrentSlot()
        {
            _currentSlotInActive.Add(CurrentSlotInActiveKey, PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0));
        }

        private void SetCurrentTimeGetReward()
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKey, null);
            DateTime? dateTime = null;
            
            if (!string.IsNullOrEmpty(data))
            {
                dateTime = DateTime.Parse(data);
                Debug.Log(dateTime.Value.Second);
            }
            
            _timeGetReward.Add(TimeGetRewardKey, dateTime);
        }

        private void OnDestroy()
        {
            _getRewardButton.onClick.RemoveAllListeners();
            _resetButton.onClick.RemoveAllListeners();
        }

        private void OnApplicationQuit()
        {
            if (_currentSlotInActive.TryGetValue(CurrentSlotInActiveKey, out var value))
            {
                PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
            }
            
            if (_timeGetReward[TimeGetRewardKey] == null)
            {
                PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
            else
            {
                PlayerPrefs.SetString(TimeGetRewardKey, _timeGetReward[TimeGetRewardKey].ToString());
            }
        }
    }
}