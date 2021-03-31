using System.Linq;
using CarGameScripts.ContentDataSource;
using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.Feature.AbilitiesFeature;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using CarGameScripts.Feature.InventoryFeature;
using CarGameScripts.Feature.InventoryFeature.Interface;
using Game.InputLogic;
using Game.TapeBackground;
using Game.Trail;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMoveDiff = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMoveDiff = new SubscriptionProperty<float>();
            TapeBackgroundController tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            InputGameController inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);
            CarController carController = new CarController(leftMoveDiff, rightMoveDiff);
            AddController(carController);
            
            var abilityController = ConfigureAbilityController(placeForUi, carController);
            var inventoryController = ConfigureInventoryController(placeForUi);
        }

        private IInventoryController ConfigureInventoryController(Transform placeForUi)
        {
            var upgradeItemsConfigCollection 
                = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath {PathResource = "DataSource/Upgrade/UpgradeItemConfigDataSource"});
            
            var itemsRepository 
                = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.ItemConfig).ToList());
            var inventoryModel
                = new InventoryModel();
            var inventoryViewPath
                = new ResourcePath {PathResource = $"Prefabs/{nameof(InventoryView)}"};
            var inventoryView 
                = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObjects(inventoryView.gameObject);
            var inventoryController 
                = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            AddController(inventoryController);

            return inventoryController;
        }
        
        private IAbilitiesController ConfigureAbilityController(Transform placeForUi, IAbilityActivator abilityActivator)
        {
            var abilityItemsConfigCollection 
                = ContentDataSourceLoader.LoadAbilityItemConfigs(new ResourcePath {PathResource = "DataSource/Ability/AbilityItemConfigDataSource"});
            
            var abilityRepository 
                = new AbilityRepository(abilityItemsConfigCollection);
            
            var abilityCollectionViewPath 
                = new ResourcePath {PathResource = $"Prefabs/{nameof(AbilityCollectionView)}"};
            var abilityCollectionView = 
                ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
            AddGameObjects(abilityCollectionView.gameObject);
            
            var abilityItemsRepository 
                = new ItemsRepository(abilityItemsConfigCollection.Select(value => value.ItemConfig).ToList());
            
            var inventoryModel = new InventoryModel();
            foreach (var item in abilityItemsRepository.Collection.Values)
            {
                inventoryModel.EquipItem(item);
            }
            
            var abilitiesController = new AbilitiesController(abilityRepository, inventoryModel, abilityCollectionView, 
                abilityActivator);
            AddController(abilitiesController);
            
            return abilitiesController;
        }
    }
}

