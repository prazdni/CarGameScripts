using CarGameScripts.ContentDataSource.Items;
using UnityEngine;

namespace CarGameScripts.ContentDataSource.Upgrade
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