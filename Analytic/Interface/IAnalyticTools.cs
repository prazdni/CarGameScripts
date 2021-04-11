using System.Collections.Generic;

namespace CarGameScripts.Analytic.Interface
{
    public interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}