using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal sealed class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Input/endlessMove"};
        private readonly BaseInputView _view;
        
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView<BaseInputView>(_viewPath, null);
            _view.Init(leftMove, rightMove, car.Speed.Value);
        }
    } 
}

