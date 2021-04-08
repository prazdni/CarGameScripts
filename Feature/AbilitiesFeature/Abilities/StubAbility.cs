using CarGameScripts.Feature.AbilitiesFeature.Interface;

namespace CarGameScripts.Feature.AbilitiesFeature.Abilities
{
    public class StubAbility : IAbility
    {
        public static readonly IAbility Default = new StubAbility();
        
        public void Apply(IAbilityActivator activator)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}