namespace CarGameScripts.Feature.Upgradables
{
    public class JumpUpgrade : IUpgrade<float>
    {
        private readonly float _defaultValue;
        public float Value { get; set; }

        public JumpUpgrade(float defaultValue)
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