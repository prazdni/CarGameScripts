using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public struct AbilityConfiguration
    {
        public int ID { get; }
        public GameObject View { get; }
        public AbilityType Type { get; }
        public float Value { get; }
        
        public AbilityConfiguration(int id, GameObject view, AbilityType type, float value)
        {
            ID = id;
            View = view;
            Type = type;
            Value = value;
        }
    }
}