using Game.Wheels;
using Tools;
using UnityEngine;

namespace Game
{
    internal class WheelController : BaseController
    {
        private readonly SubscriptionProperty<float> _leftMove;
        private readonly SubscriptionProperty<float> _rightMove;
        
        private readonly SubscriptionProperty<float> _diff;
        
        private WheelView _wheelView;
        
        public WheelController(CarView carView, SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            
            _diff = new SubscriptionProperty<float>();
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
                
            _wheelView = LoadView(carView);
            _wheelView.Init(_diff);
        }
        
        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
            
            base.OnDispose();
        }

        private WheelView LoadView(CarView carView)
        {
            return carView.GetComponentInChildren<WheelView>();
        }

        private void Move(float value)
        {
            _diff.Value = value;
        }
    }
}