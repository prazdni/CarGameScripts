using System;
using Tools;
using UnityEngine;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class GunAbilityView : MonoBehaviour, IInitialize<IGenericReadonlySubscriptionAction<GunAbilityView>>
    {
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private IGenericReadonlySubscriptionAction<GunAbilityView> _onTriggerSubscription;

        public void Init(IGenericReadonlySubscriptionAction<GunAbilityView> initObject)
        {
            _onTriggerSubscription = initObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _onTriggerSubscription.Invoke(this);
        }
    }
}