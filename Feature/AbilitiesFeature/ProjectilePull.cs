using CarGameScripts.ContentDataSource.Ability;
using CarGameScripts.Feature.AbilitiesFeature.Interface;
using Tools;
using Object = UnityEngine.Object;

namespace CarGameScripts.Feature.AbilitiesFeature
{
    public class ProjectilePull : IPullable<GunAbilityView>
    {
        private GunAbilityView _pullObject;

        public ProjectilePull(AbilityItemConfig itemConfig, 
            IGenericReadonlySubscriptionAction<GunAbilityView> returnObjectToPull)
        {
            _pullObject = Object.Instantiate(itemConfig.View).GetComponent<GunAbilityView>();
            _pullObject.Init(returnObjectToPull);
            _pullObject.gameObject.SetActive(false);
        }

        public bool TryGetValue()
        {
            return !_pullObject.gameObject.activeSelf;
        }

        public GunAbilityView Get(IAbilityActivator abilityActivator)
        {
            _pullObject.transform.position = abilityActivator.GetViewObject().transform.up;
            _pullObject.gameObject.SetActive(true);
            return _pullObject;
        }

        public void Return(GunAbilityView objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
        }
    }
}