using System.Collections.Generic;

namespace CarGameScripts.Feature
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }
    }
}