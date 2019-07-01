using System.Collections.Generic;

namespace FASample
{
    public interface IAnalytics
    {
        void LogEvent(string eventName, Dictionary<string, string> eventParams);
    }
}