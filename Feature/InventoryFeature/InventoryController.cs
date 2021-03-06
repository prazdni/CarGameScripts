using System;
using System.Collections.Generic;
using System.Linq;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature.InventoryFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryController : BaseController, IInventoryController
    {
        [NotNull] private readonly IRepository<int, IItem> _repository;
        [NotNull] private readonly IInventoryModel _inventoryModel;
        [NotNull] private readonly IInventoryView _inventoryView;
        
        public InventoryController([NotNull] IRepository<int, IItem> repository, [NotNull] IInventoryModel inventoryModel,
            [NotNull] IInventoryView inventoryView)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

            SetupView(_inventoryView);
        }
        
        protected override void OnDispose()
        {
            CleanupView();
            base.OnDispose();
        }

        private void SetupView(IInventoryView inventoryView)
        {
            inventoryView.Selected += OnItemSelected;
            inventoryView.Deselected += OnItemDeselected;
            
            inventoryView.Init();
        }
        
        private void CleanupView()
        {
            _inventoryView.Selected -= OnItemSelected;
            _inventoryView.Deselected -= OnItemDeselected;
        }

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _inventoryModel.GetEquippedItems();
        }

        public void ShowInventory()
        {
            _inventoryView.Show();
            _inventoryView.Display(_inventoryModel.GetEquippedItems());
        }

        public void HideInventory()
        {
            _inventoryView.Hide();
        }
        
        private void OnItemSelected(object sender, IItem item)
        {
            Debug.Log("Equipped");
            _inventoryModel.EquipItem(item);
        }
        
        private void OnItemDeselected(object sender, IItem item)
        {
            Debug.Log("Unequipped");
            _inventoryModel.UnequipItem(item);
        }
    }
}