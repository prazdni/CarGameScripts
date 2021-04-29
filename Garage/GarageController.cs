using System.Linq;
using CarGameScripts.ContentDataSource;
using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.Feature.InventoryFeature;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Feature.ShedFeature.Interface;
using CarGameScripts.Feature.ShedFeature.UpgradeHandlers;
using CarGameScripts.Shed;
using Profile;
using Tools;
using Ui;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CarGameScripts.Garage
{
    public sealed class GarageController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Assets/Resources_moved/Prefabs/Garage.prefab"};
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly IInventoryModel _inventoryModel;
        private IShedController _shedController;

        private GarageView _view;

        public GarageController(Transform placeForUi, ProfilePlayer profilePlayer, IInventoryModel inventoryModel)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            _inventoryModel = inventoryModel;
            LoadAddressableView(_viewPath);
        }

        protected override void OnViewLoaded(AsyncOperationHandle<GameObject> handle)
        {
            base.OnViewLoaded(handle);
            _view = Object.Instantiate(handle.Result, _placeForUi).GetComponent<GarageView>();
            AddGameObjects(_view.gameObject);
            _view.Init(OnStateChanged);
            _shedController = ConfigureShedController(_placeForUi, _profilePlayer, _inventoryModel);
        }

        private void OnStateChanged(GameState state)
        {
            _profilePlayer.CurrentState.Value = state;
            _shedController.Exit();
            _profilePlayer.AnalyticTools.SendMessage(state.ToString());
        }
        
        private ShedController ConfigureShedController(Transform placeForUi, 
            ProfilePlayer profilePlayer, IInventoryModel inventoryModel)
        {
            var upgradeItemsConfigCollection 
                = ContentDataSourceLoader
                    .LoadUpgradeItemConfigs(new ResourcePath {PathResource = "DataSource/Upgrade/UpgradeItemConfigDataSource"});
            var upgradeItemsRepository
                = new UpgradeHandlersRepository(upgradeItemsConfigCollection);

            var itemsRepository 
                = new ItemsRepository(upgradeItemsConfigCollection
                    .Select(value => value.ItemConfig).ToList());
            
            //var inventoryModel
            //    = new InventoryModel();

            var inventoryView = _view.InventoryView;
            AddGameObjects(inventoryView.gameObject);
            var inventoryController 
                = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            AddController(inventoryController);
            
            var shedController
                = new ShedController(upgradeItemsRepository, inventoryController, profilePlayer.CurrentCar);
            AddController(shedController);
            
            return shedController;
        }
    }
}