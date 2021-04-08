using System;
using CarGameScripts.Feature.AbilitiesFeature.Interface;

namespace Tools
{
    public interface IPullable<T> : IDisposable
    {
        bool TryGetValue();
        T Get(IAbilityActivator abilityActivator);
        void Return(T objectToReturn);
    }
}