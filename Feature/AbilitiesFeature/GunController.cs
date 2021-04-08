using System;
using CarGameScripts.ContentDataSource.Ability;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using Tools;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class GunController : BaseController, IAbility
    {
        private IGenericReadonlySubscriptionAction<GunAbilityView> _returnObjectToPull;
        private readonly AbilityItemConfig _abilityItemConfig;
        private IPullable<GunAbilityView> _gunPull;
        
        public GunController(AbilityItemConfig abilityItemConfig)
        {
            _returnObjectToPull = new GenericSubscriptionAction<GunAbilityView>();
            _returnObjectToPull.SubscribeOnChange(OnReturnObjectToPull);
            
            _abilityItemConfig = abilityItemConfig;
            _gunPull = new ProjectilePull(abilityItemConfig, _returnObjectToPull);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _returnObjectToPull.UnSubscriptionOnChange(OnReturnObjectToPull);
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