using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature.InventoryFeature.Interface;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryModel : IInventoryModel
    {
        private readonly List<IItem> _stubCollection = new List<IItem>();
        private readonly List<IItem> _equippedItems = new List<IItem>();
        
        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _equippedItems ?? _stubCollection;
        }

        public void EquipItem(IItem item)
        {
            if (_equippedItems.Contains(item))
            {
                return;
            }
            
            _equippedItems.Add(item);
        }

        public void UnequipItem(IItem item)
        {
            if (!_equippedItems.Contains(item))
            {
                return;
            }

            _equippedItems.Remove(item);
        }
    }
}