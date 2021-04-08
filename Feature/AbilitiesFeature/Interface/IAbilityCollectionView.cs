using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Items.Interface;
using Tools;

namespace CarGameScripts.Feature.AbilitiesFeature.Interface
{
    public interface IAbilityCollectionView : IView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
        void Init();
    }
}