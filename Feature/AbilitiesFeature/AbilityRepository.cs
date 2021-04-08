using System;
using System.Collections.Generic;
using CarGameScripts.ContentDataSource.Ability;
using CarGameScripts.Feature.AbilitiesFeature.Abilities;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using Tools;
using Object = UnityEngine.Object;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class AbilityRepository : IRepository<int, IAbility>
    {
        private SubscriptionAction _onRepositoryDispose;
        public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;
        private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();

        public AbilityRepository(List<AbilityItemConfig> itemConfigs)
        {
            _onRepositoryDispose = new SubscriptionAction();
            PopulateItems(ref _abilityMapById, itemConfigs);
        }

        private void PopulateItems(ref Dictionary<int, IAbility> upgradeHandlersMapByType, 
            List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    continue;
                }
                
                upgradeHandlersMapByType.Add(config.ID, CreateAbilityByType(config));
            }
        }

        private IAbility CreateAbilityByType(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbilityType.Gun:
                    return new GunController(InstantiateAbilityConfiguration(config));
                case AbilityType.Jump:
                    return new JumpAbility(InstantiateAbilityConfiguration(config));
                default:
                    return StubAbility.Default;
            }
        }
        
        private AbilityConfiguration InstantiateAbilityConfiguration(AbilityItemConfig abilityItemConfig)
        {
            return new AbilityConfiguration(abilityItemConfig.ID, Object.Instantiate(abilityItemConfig.View),
                abilityItemConfig.Type, abilityItemConfig.Value);
        }

    }
}