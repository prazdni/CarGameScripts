using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class CarController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};

        private CarView _carView;
        
        public CarController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _carView = LoadView();
            
            WheelController wheelController = new WheelController(_carView, leftMove, rightMove);
            AddController(wheelController);
        }

        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }
    } 
}

