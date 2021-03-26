using Tools;
using UnityEngine;

namespace Game.Wheels
{
    internal class WheelView : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        
        private IReadOnlySubscriptionProperty<float> _diff;
        
        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }
        
        private void OnDestroy()
        {
            _diff?.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (var wheel in _wheels)
            {
                wheel.Move(-value);
            }
        }
    }
}