using UnityEngine;

namespace CarGameScripts.Configs
{
    [CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "Car/AbilityItemConfigDataSource", order = 0)]
    public class AbilityItemConfigDataSource : ScriptableObject
    {
        public AbilityItemConfig[] ItemConfigs;
    }
}