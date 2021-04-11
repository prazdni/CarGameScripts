using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryItemView
    {
        void Display(IReadOnlyList<IItem> items);
        void Init(EventHandler<IItem> selected, EventHandler<IItem> deselected);
    }
}