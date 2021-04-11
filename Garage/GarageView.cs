using System;
using CarGameScripts.Feature.InventoryFeature;
using CarGameScripts.UI;
using Profile;
using Tools;
using UnityEngine;

namespace CarGameScripts.Garage
{
    public class GarageView : MonoBehaviour, IInitialize<Action<GameState>>
    {
        public InventoryView InventoryView => _inventoryView;

        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private StartStateButton _startStateButton;

        public void Init(Action<GameState> initObject)
        {
            _startStateButton.AddListener(initObject);
        }
    }
}