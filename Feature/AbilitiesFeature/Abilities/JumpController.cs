using CarGameScripts.ContentDataSource.Ability;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature.Abilities
{
    public class JumpController : IAbility
    {
        private readonly AbilityConfiguration _config;

        public JumpController(AbilityConfiguration config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            var activatorGO = activator.GetViewObject();
            var activatorGORigid2D = activatorGO.GetComponent<Rigidbody2D>();
            activatorGORigid2D.AddForce(activatorGO.transform.up * _config.Value, ForceMode2D.Impulse);
        }

        public void Dispose()
        {
            Object.Destroy(_config.View);
        }
    }
}