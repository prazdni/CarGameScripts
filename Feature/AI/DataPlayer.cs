using System.Collections.Generic;
using AI.Interface;

namespace AI
{
    public abstract class DataPlayer
    {
        public string TitleData => _titleData;
        private readonly string _titleData;

        public int Money
        {
            get => _money;
            set
            {
                if (_money != value)
                {
                    _money = value;
                    Notify(DataType.Money);
                }
            }
        }

        public int Health
        {
            get => _health;
            set
            {
                if (_health != value)
                {
                    _health = value;
                    Notify(DataType.Health);
                }
            }
        }

        public int Power
        {
            get => _power;
            set
            {
                if (_power != value)
                {
                    _power = value;
                    Notify(DataType.Power);
                }
            }
        }

        public int Criminal
        {
            get => _criminal;
            set
            {
                if (_criminal != value)
                {
                    _criminal = value;
                    Notify(DataType.Criminal);
                }
            }
        }

        private int _money;
        private int _health;
        private int _power;
        private int _criminal;
        
        private List<IEnemy> _enemies = new List<IEnemy>();
        
        protected DataPlayer(string titleData)
        {
            _titleData = titleData;
        }

        protected void Notify(DataType dataType)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Update(this, dataType);
            }
        }

        public void Attach(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Detach(IEnemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}