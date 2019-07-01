using System.Collections.Generic;

using Android.OS;

using Xamarin.Forms;

using FASample.Droid;

[assembly: Dependency(typeof(Analytics_Android))]
namespace FASample.Droid
{
    public class Analytics_Android : IAnalytics
    {
        public void LogEvent(string eventName, Dictionary<string, string> eventParams)
        {
            var analytics = AnalyticsSingleton.GetInstance.Analytics;

            var bundle = new Bundle();

            foreach (var eventParam in eventParams)
            {
                bundle.PutString(eventParam.Key, eventParam.Value);
            }

            analytics.LogEvent(eventName, bundle);
        }
    }
}