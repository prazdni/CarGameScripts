using CarGameScripts.ContentDataSource.Ability;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature.Abilities
{
    public class ShieldAbility : IAbility
    {
        private readonly AbilityItemConfig _config;

        public ShieldAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.View, activator.GetViewObject().transform);
        }
    }
}