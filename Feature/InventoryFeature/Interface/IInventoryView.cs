using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using Tools;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryView : IView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
        void Init();
    }
}