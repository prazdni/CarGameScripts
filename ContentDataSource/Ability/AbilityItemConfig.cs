using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.Feature.AbilitiesFeature;
using UnityEngine;

namespace CarGameScripts.ContentDataSource.Ability
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Car/AbilityItem", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        public int ID => ItemConfig.ID;
        
        public ItemConfig ItemConfig;
        public GameObject View;
        public AbilityType Type;
        public float Value;
    }
}