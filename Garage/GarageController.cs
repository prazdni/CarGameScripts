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

namespace CarGameScripts.Garage
{
    public class GarageController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Garage"};
        private readonly ProfilePlayer _profilePlayer;
        private IShedController _shedController;

        private GarageView _view;

        public GarageController(Transform placeForUi, ProfilePlayer profilePlayer, IInventoryModel inventoryModel)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(OnStateChanged);
            _shedController = ConfigureShedController(placeForUi, profilePlayer, inventoryModel);
        }
        
        private GarageView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<GarageView>();
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