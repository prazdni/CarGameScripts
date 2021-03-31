using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryController
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void ShowInventory(Action hideAction);
        void HideInventory();
    }
}