using CarGameScripts.Feature.ShedFeature.Interface;

namespace CarGameScripts.Feature.ShedFeature.UpgradeHandlers
{
    public class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _speed;

        public SpeedUpgradeHandler(float speed)
        {
            _speed = speed;
        }
        
        public IUpgradable Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed.Value = _speed;
            return upgradable;
        }
    }
}