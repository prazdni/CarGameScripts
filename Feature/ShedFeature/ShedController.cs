using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Feature.ShedFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Shed
{
    public class ShedController : BaseController, IShedController
    {
        private readonly IUpgradable _upgradable;
        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IInventoryController _inventoryController;

        public ShedController([NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository, 
            [NotNull] IInventoryController inventoryController, [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository = upgradeHandlersRepository ?? 
                                         throw new ArgumentNullException(nameof(upgradeHandlersRepository));

            _inventoryController = inventoryController ?? 
                                   throw new ArgumentNullException(nameof(inventoryController));

            _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));

            Enter();
        }

        public void Enter()
        {
            _inventoryController.ShowInventory();
        }

        public void Exit()
        {
            _inventoryController.HideInventory();
            UpgradeCarWithEquippedItems(_upgradable, _inventoryController.GetEquippedItems(), 
                _upgradeHandlersRepository.Collection);
        }

        private void UpgradeCarWithEquippedItems(IUpgradable upgradable, IReadOnlyList<IItem> equippedItems, 
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
        {
            upgradable.Restore();
            
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.ID, out var handler))
                {
                    handler.Upgrade(upgradable);
                }
            }
        }
    }
}