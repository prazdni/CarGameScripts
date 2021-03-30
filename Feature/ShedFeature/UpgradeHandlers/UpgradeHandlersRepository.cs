using System.Collections.Generic;
using CarGameScripts.Configs;
using CarGameScripts.Feature.ShedFeature.Interface;

namespace CarGameScripts.Feature.ShedFeature.UpgradeHandlers
{
    public class UpgradeHandlersRepository : IRepository<int, IUpgradeHandler>
    {
        public IReadOnlyDictionary<int, IUpgradeHandler> Collection => _upgradeItemsMapByID;
        private Dictionary<int, IUpgradeHandler> _upgradeItemsMapByID = new Dictionary<int, IUpgradeHandler>();

        public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapByID, upgradeItemConfigs);
        }
        
        private void PopulateItems(ref Dictionary<int, IUpgradeHandler> upgradeHandlersMapByType, 
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    continue;
                }
                
                upgradeHandlersMapByType.Add(config.ID, CreateHandlerByType(config));
            }
        }

        private IUpgradeHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.UpgradeType)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeHandler(config.Value);
                default:
                    return StubUpgradeHandler.Default;
            }
        }
    }
}