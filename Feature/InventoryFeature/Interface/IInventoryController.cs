using System;
using System.Collections.Generic;
using CarGameScripts.Items.Interface;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryController
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void ShowInventory(Action hideAction);
        void HideInventory();
    }
}