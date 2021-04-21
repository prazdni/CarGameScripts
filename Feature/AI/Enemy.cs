using System;
using AI.Interface;
using UnityEngine;

namespace AI
{
    public class Enemy : IEnemy
    {
        public int Power
        {
            get
            {
                var kHealth = _healthPlayer > 0 ? _healthPlayer : 1;
                var kMoney = _moneyPlayer > 0 ? _moneyPlayer : 1;
                var kPower = _powerPlayer > 0 ? _powerPlayer : 0;
                var kCriminal = _criminalPlayer > 0 ? _criminalPlayer : 1;
                var power = kPower / (kMoney * kHealth * kCriminal);

                return power;
            }
        }
        private const int KCoins = 5;
        private const float KPower = 1.5f;
        private const int MaxHealthPlayer = 20;

        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;
        private int _criminalPlayer;

        public Enemy(string name)
        {
            _name = name;
        }
        
        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.None:
                    break;
                case DataType.Money:
                    _moneyPlayer = dataPlayer.Money;
                    break;
                case DataType.Health:
                    _healthPlayer = dataPlayer.Health;
                    break;
                case DataType.Power:
                    _powerPlayer = dataPlayer.Power;
                    break;
                case DataType.Criminal:
                    _criminalPlayer = dataPlayer.Criminal;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
            
            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }
    }
}