namespace CarGameScripts.Feature.ShedFeature.Interface
{
    public interface IUpgradable
    {
        float Speed { get; set; }
        void Restore();
    }
}