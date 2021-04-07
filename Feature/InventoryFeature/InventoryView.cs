using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature.InventoryFeature.Interface;
using UnityEngine;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private InventoryItemView[] _inventoryItemViews;
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        private IReadOnlyList<IItem> _itemInfoCollection;

        public void Init()
        {
            foreach (var inventoryItemView in _inventoryItemViews)
            {
                inventoryItemView.Init(Selected, Deselected);
            }
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            _itemInfoCollection = items;
            foreach (var inventoryItemView in _inventoryItemViews)
            {
                inventoryItemView.Display(items);
            }
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}