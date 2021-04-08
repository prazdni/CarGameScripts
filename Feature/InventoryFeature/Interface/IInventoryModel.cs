using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
    }
}