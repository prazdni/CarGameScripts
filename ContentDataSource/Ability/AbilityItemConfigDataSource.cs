using UnityEngine;

namespace CarGameScripts.ContentDataSource.Ability
{
    [CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "Car/AbilityItemConfigDataSource", order = 0)]
    public class AbilityItemConfigDataSource : ScriptableObject
    {
        public AbilityItemConfig[] ItemConfigs;
    }
}