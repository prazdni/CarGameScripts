using System;
using System.Collections.Generic;
using CarGameScripts.Configs;
using CarGameScripts.Feature.AbilitiesFeature.Abilities;
using CarGameScripts.Feature.AbilitiesFeature.Interface;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class AbilityRepository : IRepository<int, IAbility>
    {
        public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;
        private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();

        public AbilityRepository(List<AbilityItemConfig> itemConfigs)
        {
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
                    return new GunAbility(config);
                case AbilityType.Jump:
                    return new JumpAbility(config);
                default:
                    return StubAbility.Default;
            }
        }
    }
}