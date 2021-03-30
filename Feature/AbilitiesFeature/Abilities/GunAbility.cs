using CarGameScripts.Configs;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature.Abilities
{
    public class GunAbility : IAbility
    {
        private readonly AbilityItemConfig _config;

        public GunAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.View).GetComponent<Rigidbody2D>();
            projectile.AddForce(activator.GetViewObject().transform.right * _config.Value, ForceMode2D.Force);
        }
    }
}