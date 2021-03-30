
using CarGameScripts.Feature.ShedFeature.Interface;

namespace Profile
{
    public sealed class Car : IUpgradable
    {
        public float Speed { get; set; }

        private readonly float _defaultSpeed;
        
        public Car(float speed)
        {
            _defaultSpeed = speed;
            
            Restore();
        }
        
        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}

