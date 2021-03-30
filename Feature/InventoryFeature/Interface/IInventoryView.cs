using System;
using System.Collections.Generic;
using CarGameScripts.Items.Interface;
using Tools;

namespace CarGameScripts.Feature.InventoryFeature.Interface
{
    public interface IInventoryView : IView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> items);
    }
}