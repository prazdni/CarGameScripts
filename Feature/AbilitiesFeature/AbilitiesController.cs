using System;
using CarGameScripts.ContentDataSource.Items.Interface;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using CarGameScripts.Feature.InventoryFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class AbilitiesController : BaseController, IAbilitiesController
    {
        [NotNull] private readonly IAbilityActivator _abilityActivator;
        [NotNull] private readonly IInventoryModel _inventoryModel;
        [NotNull] private readonly IRepository<int, IAbility> _abilityRepository;
        [NotNull] private readonly IAbilityCollectionView _abilityCollectionView;

        public AbilitiesController(
                [NotNull] IRepository<int, IAbility> abilityRepository,
                [NotNull] IInventoryModel inventoryModel,
                [NotNull] IAbilityCollectionView abilityCollectionView,
                [NotNull] IAbilityActivator abilityActivator)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView = abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
            
            SetupView(_abilityCollectionView);
        }

        private void SetupView(IAbilityCollectionView view)
        {
            view.UseRequested += OnAbilityUseRequested;
            view.Init();
        }
        
        private void CleanupView(IAbilityCollectionView view)
        {
            view.UseRequested -= OnAbilityUseRequested;
        }

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Collection.TryGetValue(e.ID, out var ability))
            {
                ability.Apply(_abilityActivator);
            }
        }

        public void ShowAbilities()
        {
            _abilityCollectionView.Show();
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        }
    }
}