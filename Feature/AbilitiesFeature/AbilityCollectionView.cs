using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField] private AbilityView[] _abilityViews;
        public event EventHandler<IItem> UseRequested;
        
        private IReadOnlyList<IItem> _abilityItems;

        public void Init()
        {
            foreach (var abilityView in _abilityViews)
            {
                abilityView.Init(UseRequested);
            }
        }

        protected virtual void OnUseRequested(IItem e)
        {
            UseRequested?.Invoke(this, e);
        }
        
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            _abilityItems = abilityItems;
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}