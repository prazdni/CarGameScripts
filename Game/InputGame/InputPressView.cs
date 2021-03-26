using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputPressView : BaseInputView
    {
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            if (Input.touchCount > 0)
            {
                if (_camera.ScreenToViewportPoint(Input.touches[0].position).x >= 0.5f)
                {
                    OnRightMove(Time.deltaTime * _speed);
                }
                else
                {
                    OnLeftMove(-Time.deltaTime * _speed);
                }
            }
        }
    }
}