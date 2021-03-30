using System.Collections.Generic;
using System.Linq;
using CarGameScripts.Configs;
using Tools;

namespace CarGameScripts.ContentDataSource
{
    public static class ContentDataSourceLoader
    {
        public static List<UpgradeItemConfig> LoadUpgradeItemConfigs(ResourcePath resourcePath)
        {
            var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath);
            return config == null ? new List<UpgradeItemConfig>() : config.ItemConfigs.ToList();
        }
        
        public static List<AbilityItemConfig> LoadAbilityItemConfigs(ResourcePath resourcePath)
        {
            var config = ResourceLoader.LoadObject<AbilityItemConfigDataSource>(resourcePath);
            return config == null ? new List<AbilityItemConfig>() : config.ItemConfigs.ToList();
        }
    }
}