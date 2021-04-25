using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AI
{
    public class FightWindowView : MonoBehaviour
    {
        public TMP_Text CountMoneyText => _countMoneyText;
        [SerializeField] private TMP_Text _countMoneyText;
        public TMP_Text CountHealthText => _countHealthText;
        [SerializeField] private TMP_Text _countHealthText;
        public TMP_Text CountPowerText => _countPowerText;
        [SerializeField] private TMP_Text _countPowerText;
        public TMP_Text CountCriminalText => _countCriminalText;
        [SerializeField] private TMP_Text _countCriminalText;
        public TMP_Text CountPowerEnemyText => _countPowerEnemyText;
        [SerializeField] private TMP_Text _countPowerEnemyText;

        public Button AddCoinsButton => _addCoinsButton;
        [SerializeField] private Button _addCoinsButton;
        public Button MinusCoinsButton => _minusCoinsButton;
        [SerializeField] private Button _minusCoinsButton;
        public Button AddHealthButton => _addHealthButton;
        [SerializeField] private Button _addHealthButton;
        public Button MinusHealthButton => _minusHealthButton;
        [SerializeField] private Button _minusHealthButton;
        public Button AddPowerButton => _addPowerButton;
        [SerializeField] private Button _addPowerButton;
        public Button MinusPowerButton => _minusPowerButton;
        [SerializeField] private Button _minusPowerButton;
        public Button AddCriminalButton => _addCriminalButton;
        [SerializeField] private Button _addCriminalButton;
        public Button MinusCriminalButton => _minusCriminalButton;
        [SerializeField] private Button _minusCriminalButton;
        public Button FightButton => _fightButton;
        [SerializeField] private Button _fightButton;
        public Button PassButton => _passButton;
        [SerializeField] private Button _passButton;
        public Button LeaveFightButton => _leaveFightButton;
        [SerializeField] private Button _leaveFightButton;
    }
}