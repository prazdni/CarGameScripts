using CarGameScripts.Feature.AbilitiesFeature.Interface;
using Tools;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature.Abilities
{
    public class GunController : IAbility
    {
        private IGenericReadonlySubscriptionAction<GunAbilityView> _returnObjectToPull;
        private readonly AbilityConfiguration _abilityItemConfig;
        private IPullable<GunAbilityView> _gunPull;
        
        public GunController(AbilityConfiguration abilityItemConfig)
        {
            _returnObjectToPull = new GenericSubscriptionAction<GunAbilityView>();
            _returnObjectToPull.SubscribeOnChange(OnReturnObjectToPull);
            
            _abilityItemConfig = abilityItemConfig;
            _gunPull = new ProjectilePull(abilityItemConfig, _returnObjectToPull);
        }

        public void Dispose()
        {
            _returnObjectToPull.UnSubscriptionOnChange(OnReturnObjectToPull);
            _gunPull.Dispose();
        }

        private void OnReturnObjectToPull(GunAbilityView gunAbilityView)
        {
            _gunPull.Return(gunAbilityView);
        }

        public void Apply(IAbilityActivator activator)
        {
            GunAbilityView projectile = null;
            if (_gunPull.TryGetValue())
            {
                projectile = _gunPull.Get(activator);
            }

            if (projectile != null)
            {
                projectile.Rigidbody2D
                    .AddForce(activator.GetViewObject().transform.right * _abilityItemConfig.Value, ForceMode2D.Force);
            }
        }
    }
}