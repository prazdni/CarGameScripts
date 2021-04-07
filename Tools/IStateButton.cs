using System;
using Profile;
using UnityEngine.Events;

namespace Tools
{
    public interface IStateButton
    {
        void AddListener(Action<GameState> action);
        void RemoveListener(Action<GameState> action);
    }
}