using UnityEngine;

namespace CarGameScripts.Configs
{
    [CreateAssetMenu(fileName = "UpgradeItem", menuName = "Car/UpgradeItem", order = 0)]
    public class UpgradeItemConfig : ScriptableObject
    {
        public int ID => ItemConfig.ID;
        
        public ItemConfig ItemConfig;
        public UpgradeType UpgradeType;
        public float Value;
    }
}