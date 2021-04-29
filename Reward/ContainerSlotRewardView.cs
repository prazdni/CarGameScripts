using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Reward
{
    public class ContainerSlotRewardView : MonoBehaviour
    {
        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _iconCurrency;
        [SerializeField] private TMP_Text _textDays;
        [SerializeField] private TMP_Text _countReward;

        private string _dayText;

        private void Start()
        {
            _dayText = _textDays.text;
        }

        public void SetData(Reward reward, int countDay, bool isSelect)
        {
            _iconCurrency.sprite = reward.IconCurrency;
            _textDays.text = $"{_dayText} {countDay}";
            _countReward.text = reward.CountCurrency.ToString();
            _selectBackground.gameObject.SetActive(isSelect);
        }
    }
}