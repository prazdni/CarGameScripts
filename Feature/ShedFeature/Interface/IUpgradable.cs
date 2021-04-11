using CarGameScripts.Feature.Upgradables;

namespace CarGameScripts.Feature.ShedFeature.Interface
{
    public interface IUpgradable
    {
        IUpgrade<float> Speed { get; }
        void Restore();
    }
}