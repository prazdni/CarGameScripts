using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Reward
{
    public class RewardButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _reward;
        private bool _isActive;

        private void Awake()
        {
            _button.onClick.AddListener(OnRewardOpen);
            _reward.gameObject.SetActive(_isActive);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnRewardOpen()
        {
            _isActive = !_isActive;
            _reward.gameObject.SetActive(_isActive);
            _text.text = _isActive ? "OpenReward" : "CloseReward";
        }
    }
}