using CarGameScripts.Feature.ShedFeature.Interface;

namespace CarGameScripts.Feature.ShedFeature.UpgradeHandlers
{
    public class StubUpgradeHandler : IUpgradeHandler
    {
        public static readonly IUpgradeHandler Default = new StubUpgradeHandler();
        
        public IUpgradable Upgrade(IUpgradable upgradable)
        {
            return upgradable;
        }
    }
}