using System;

namespace CarGameScripts.Feature.AbilitiesFeature.Interface
{
    public interface IAbility : IDisposable
    {
        void Apply(IAbilityActivator activator);
    }
}