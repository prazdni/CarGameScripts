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
        [SerializeField] private int _timeCooldown = 86400;
        [SerializeField] private int _timeDeadline = 172800;

        [Header("Settings Rewards"), SerializeField] private List<Reward> _rewards;

        [Header("Ui Elements")]
        [SerializeField] private TMP_Text _timerNewReward;
        [SerializeField] private Image _timerImage;
        [SerializeField] private Transform _mountRootSlotsReward;
        [SerializeField] private ContainerSlotRewardView _containerSlotRewardView;
        [SerializeField] private Button _getRewardButton;
        [SerializeField] private Button _resetButton;

        public int TimeCooldown => _timeCooldown;
        public int TimeDeadline => _timeDeadline;
        public List<Reward> Rewards => _rewards;
        public TMP_Text TimerNewReward => _timerNewReward;
        public Image TimerImage => _timerImage;
        public Transform MountRootSlotsReward => _mountRootSlotsReward;
        public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;
        public Button GetRewardButton => _getRewardButton;
        public Button ResetButton => _resetButton;
        
        private readonly Dictionary<string, int> _currentSlotInActive = new Dictionary<string, int>();
        private readonly Dictionary<string, long?> _timeGetReward = new Dictionary<string, long?>();

        public int CurrentSlotInActive
        {
            get => _currentSlotInActive[CurrentSlotInActiveKey];
            set => _currentSlotInActive[CurrentSlotInActiveKey] = value;
        }

        public long? TimeGetReward
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
            _currentSlotInActive.Add(CurrentSlotInActiveKey, DataStorage.CurrentSlotInActive.Read());
        }

        private void SetCurrentTimeGetReward()
        {
            var data = DataStorage.DateTime.Read();
            long? dateTime = null;
            
            if (!string.IsNullOrEmpty(data))
            {
                dateTime = long.Parse(data);
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
                DataStorage.CurrentSlotInActive.Write(value);
            }
            
            if (_timeGetReward[TimeGetRewardKey] == null)
            {
                DataStorage.DateTime.Remove();
            }
            else
            {
                DataStorage.DateTime.Write(_timeGetReward[TimeGetRewardKey].Value.ToString());
            }
        }
    }
}