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

        public void Init(Action<GameState> initObject)
        {
            _startStateButton.AddListener(initObject);
            _shedStateButton.AddListener(initObject);
        }
    }
}

