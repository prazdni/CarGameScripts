using System;
using System.Collections.Generic;
using System.Linq;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Items.Interface;
using JetBrains.Annotations;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryController : BaseController, IInventoryController
    {
        [NotNull] private readonly IInventoryModel _inventoryModel;
        [NotNull] private readonly IRepository<int, IItem> _repository;
        [NotNull] private readonly IInventoryView _inventoryView;

        private Action _hideAction;

        public InventoryController([NotNull] IRepository<int, IItem> repository, [NotNull] IInventoryModel inventoryModel,
            [NotNull] IInventoryView inventoryView)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
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

        public void ShowInventory(Action hideAction)
        {
            _hideAction = hideAction;
            _inventoryView.Show();
            _inventoryView.Display(_repository.Collection.Values.ToList());
        }

        public void HideInventory()
        {
            throw new NotImplementedException();
        }
        
        private void OnItemSelected(object sender, IItem item)
        {
            _inventoryModel.EquipItem(item);
        }
        
        private void OnItemDeselected(object sender, IItem item)
        {
            _inventoryModel.UnequipItem(item);
        }
    }
}