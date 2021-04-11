using Tools;

namespace CarGameScripts.Feature.Upgradables
{
    public class SpeedUpgrade : IUpgrade<float>
    {
        public float Value { get; set; }

        private readonly float _defaultValue;

        public SpeedUpgrade(float defaultValue)
        {
            _defaultValue = defaultValue;
            Value = _defaultValue;
        }

        public void Restore()
        {
            Value = _defaultValue;
        }
    }
}