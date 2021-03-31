using System;
using UnityEngine;
using UnityEngine.UI;

namespace CarGameScripts.Feature.InventoryFeature
{
    public class InventoryButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Transform _inventoryTransform;

        private bool _isActive;

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
            
            _isActive = false;
            _inventoryTransform.gameObject.SetActive(_isActive);
        }

        private void OnClick()
        {
            _inventoryTransform.gameObject.SetActive(!_isActive);

            _isActive = !_isActive;

            Time.timeScale = _isActive ? 0.0f : 1.0f;
        }
    }
}