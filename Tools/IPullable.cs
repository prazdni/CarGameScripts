using CarGameScripts.Feature.AbilitiesFeature.Interface;

namespace Tools
{
    public interface IPullable<T>
    {
        bool TryGetValue();
        T Get(IAbilityActivator abilityActivator);
        void Return(T objectToReturn);
    }
}