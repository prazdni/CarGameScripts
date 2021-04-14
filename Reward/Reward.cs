using System;
using UnityEngine;

namespace CarGameScripts.Reward
{
    [Serializable]
    public class Reward
    {
        public RewardType RewardType;
        public Sprite IconCurrency;
        public int CountCurrency;
    }
}