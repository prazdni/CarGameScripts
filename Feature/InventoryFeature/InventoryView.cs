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

        private List<IItem> _itemInfoCollection;

        public void Init()
        {
            foreach (var inventoryItemView in _inventoryItemViews)
            {
                inventoryItemView.Init(Selected, Deselected);
            }
        }

        public void Display(List<IItem> items)
        {
            _itemInfoCollection = items;
        }

        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }
        
        protected virtual void OnDeselected(IItem e)
        {
            Deselected?.Invoke(this, e);
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}