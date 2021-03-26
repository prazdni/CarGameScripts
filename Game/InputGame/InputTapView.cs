using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Game.InputLogic
{
    internal sealed class InputTapView : BaseInputView
    {
        [SerializeField] private Button _buttonMoveLeft;
        [SerializeField] private Button _buttonMoveRight;
        
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _buttonMoveLeft.onClick.AddListener(OnClickLeft);
            _buttonMoveRight.onClick.AddListener(OnClickRight);
        }
        
        private void OnClickLeft()
        {
            OnLeftMove(-Time.deltaTime * _speed);
        }

        private void OnClickRight()
        {
            OnRightMove(Time.deltaTime * _speed);
        }
    }
}

