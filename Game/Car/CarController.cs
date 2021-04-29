using CarGameScripts.Feature.AbilitiesFeature.Interface;
using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};

        private CarView _carView;
        
        public CarController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _carView = LoadView<CarView>(_viewPath, null);
            
            WheelController wheelController = new WheelController(_carView, leftMove, rightMove);
            AddController(wheelController);
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    } 
}

