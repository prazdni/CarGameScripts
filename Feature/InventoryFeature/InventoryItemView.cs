using System;
using CarGameScripts.ContentDataSource.Items;
using CarGameScripts.ContentDataSource.Items.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Toggle _itemToggle;
        [SerializeField] private ItemConfig _itemConfig;

        private EventHandler<IItem> _selected;
        private EventHandler<IItem> _deselected;

        private IItem _item;

        public void Init(EventHandler<IItem> selected, EventHandler<IItem> deselected)
        {
            _selected = selected;
            _deselected = deselected;
            
            _itemToggle.onValueChanged.AddListener(OnValueChanged);
            
            _item = CreateItem(_itemConfig);
        }

        private void OnValueChanged(bool isActive)
        {
            if (isActive)
            {
                _selected.Invoke(this, _item);
            }
            else
            {
                _deselected.Invoke(this, _item);
            }
        }
        
        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                ID = config.ID,
                Info = new ItemInfo {Title = config.Title}
            };
        }
    }
}