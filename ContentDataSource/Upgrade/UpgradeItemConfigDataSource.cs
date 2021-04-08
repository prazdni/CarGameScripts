using UnityEngine;

namespace CarGameScripts.ContentDataSource.Upgrade
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "Car/UpgradeItemConfigDataSource", order = 0)]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        public UpgradeItemConfig[] ItemConfigs;
    }
}