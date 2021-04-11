using Tools;

namespace CarGameScripts.Feature.Upgradables
{
    public interface IUpgrade<T> : IRestore
    {
        T Value { get; set; }
    }
}