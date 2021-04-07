using System;
using CarGameScripts.UI;
using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour, IInitialize<Action<GameState>>
    {
        [SerializeField] private StartStateButton _startStateButton;
        [SerializeField] private ShedStateButton _shedStateButton;

        public void Init(Action<GameState> stateChanger)
        {
            _startStateButton.AddListener(stateChanger);
            _shedStateButton.AddListener(stateChanger);
        }
    }
}

