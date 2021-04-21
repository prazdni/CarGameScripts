using Profile;
using Tools;
using UnityEngine;

namespace AI
{
    public class FightWindowController : BaseController, IInitialize
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/FightWindow"};
        private FightWindowView _fightWindowView;
        
        private Enemy _enemy;
        private DataPlayer _dataPlayer;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _allCountCriminalPlayer;

        public FightWindowController(ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _fightWindowView = LoadView();
            Init();
        }
        
        private FightWindowView LoadView()
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objectView);
            return objectView.GetComponent<FightWindowView>();
        }

        public void Init()
        {
            _enemy = new Enemy("Enemy");
            
            _dataPlayer = new DataPlayer(nameof(DataPlayer));
            _dataPlayer.Attach(_enemy);

            SubscribeButtons();
        }

        private void SubscribeButtons()
        {
            _fightWindowView.AddCoinsButton.onClick.AddListener(() => ChangeMoney(true));
            _fightWindowView.MinusCoinsButton.onClick.AddListener(() => ChangeMoney(false));
    
            _fightWindowView.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _fightWindowView.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
    
            _fightWindowView.AddPowerButton.onClick.AddListener(() => ChangePower(true));
            _fightWindowView.MinusPowerButton.onClick.AddListener(() => ChangePower(false));
            
            _fightWindowView.AddCriminalButton.onClick.AddListener(() => ChangeCriminal(true));
            _fightWindowView.MinusCriminalButton.onClick.AddListener(() => ChangeCriminal(false));
    
            _fightWindowView.FightButton.onClick.AddListener(Fight);
            _fightWindowView.PassButton.onClick.AddListener(Pass);
            _fightWindowView.PassButton.gameObject.SetActive(_allCountCriminalPlayer <= 2);
            _fightWindowView.LeaveFightButton.onClick.AddListener(CloseWindow);
        }
        
        private void CloseWindow()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }

        
        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount)
                _allCountMoneyPlayer++;
            else
                _allCountMoneyPlayer--;

            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
        }


        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount)
            {
                _allCountHealthPlayer++;
            }
            else
            {
                _allCountHealthPlayer--;
            }
            
            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
        }
        
        private void ChangePower(bool isAddCount)
        {
            if (isAddCount)
                _allCountPowerPlayer++;
            else
                _allCountPowerPlayer--;

            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
        }

        private void ChangeCriminal(bool isAddCount)
        {
            if (isAddCount)
            {
                _allCountCriminalPlayer++;

                if (_allCountCriminalPlayer > 5)
                {
                    _allCountCriminalPlayer = 5;
                }
            }
            else
            {
                _allCountCriminalPlayer--;

                if (_allCountCriminalPlayer < 0)
                {
                    _allCountCriminalPlayer = 0;
                }
            }

            _fightWindowView.PassButton.gameObject.SetActive(_allCountCriminalPlayer <= 2);

            ChangeDataWindow(_allCountCriminalPlayer, DataType.Criminal);
        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.None:
                    break;
                case DataType.Money:
                    _fightWindowView.CountMoneyText.text = $"Player Money {countChangeData.ToString()}";
                    _dataPlayer.Money = countChangeData;
                    break;
                case DataType.Health:
                    _fightWindowView.CountHealthText.text = $"Player Health {countChangeData.ToString()}";
                    _dataPlayer.Health = countChangeData;
                    break;
                case DataType.Power:
                    _fightWindowView.CountPowerText.text = $"Player Power {countChangeData.ToString()}";
                    _dataPlayer.Power = countChangeData;
                    break;
                case DataType.Criminal:
                    _fightWindowView.CountCriminalText.text = $"Player Criminal {countChangeData.ToString()}";
                    _dataPlayer.Criminal = countChangeData;
                    break;
            }

            _fightWindowView.CountPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
        }
        
        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }

        private void Pass()
        {
            Debug.Log("<color=blue>Passed</color>");
        }

        protected override void OnDispose()
        {
            _fightWindowView.AddCoinsButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusCoinsButton.onClick.RemoveAllListeners();
    
            _fightWindowView.AddHealthButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusHealthButton.onClick.RemoveAllListeners();
    
            _fightWindowView.AddPowerButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusPowerButton.onClick.RemoveAllListeners();
            
            _fightWindowView.AddCriminalButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusCriminalButton.onClick.RemoveAllListeners();
    
            _fightWindowView.FightButton.onClick.RemoveAllListeners();
            _fightWindowView.LeaveFightButton.onClick.RemoveAllListeners();

            _dataPlayer.Detach(_enemy);

            base.OnDispose();
        }
    }
}