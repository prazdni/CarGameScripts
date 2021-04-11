
using CarGameScripts.Feature.ShedFeature.Interface;
using CarGameScripts.Feature.Upgradables;
using Tools;

namespace Profile
{
    public sealed class Car : IUpgradable, IRestore
    {
        public IUpgrade<float> Speed { get; }

        public Car(float speed)
        {
            Speed = new SpeedUpgrade(speed);
        }
        
        public void Restore()
        {
            Speed.Restore();
        }
    }
}

