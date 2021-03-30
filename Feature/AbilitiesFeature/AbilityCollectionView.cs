using System;
using System.Collections.Generic;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using CarGameScripts.Items.Interface;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        public event EventHandler<IItem> UseRequested;
        
        private IReadOnlyList<IItem> _abilityItems;

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