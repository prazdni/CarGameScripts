using System;
using System.Collections.Generic;
using CarGameScripts.Feature.InventoryFeature.Interface;
using CarGameScripts.Items.Interface;
using UnityEngine;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryView : MonoBehaviour, IInventoryView
    { 
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        private List<IItem> _itemInfoCollection;

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