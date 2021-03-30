using System;
using System.Collections.Generic;
using CarGameScripts.Items.Interface;
using Tools;

namespace CarGameScripts.Feature.AbilitiesFeature.Interface
{
    public interface IAbilityCollectionView : IView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}