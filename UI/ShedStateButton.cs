using System;
using Profile;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CarGameScripts.UI
{
    public class ShedStateButton : MonoBehaviour, IMainMenuStateButton
    {
        public GameState GameStateChanger => _gameState;
        
        [SerializeField] private GameState _gameState;
        [SerializeField] private Button _button;

        private Action<GameState> _changeGameStateAction = state => { }; 

        private void Awake()
        {
            _button.onClick.AddListener(OnShedButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void AddListener(Action<GameState> action)
        {
            _changeGameStateAction += action;
        }

        public void RemoveListener(Action<GameState> action)
        {
            _changeGameStateAction -= action;
        }

        private void OnShedButtonClick()
        {
            _changeGameStateAction.Invoke(_gameState);
        }
    }
}