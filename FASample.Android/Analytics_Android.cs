using System.Collections.Generic;

using Android.OS;

using Xamarin.Forms;

using FASample.Droid;

[assembly: Dependency(typeof(Analytics_Android))]
namespace FASample.Droid
{
    public class Analytics_Android : IAnalytics
    {
        public void LogEvent(string eventName, Dictionary<string, object> eventParams)
        {
            if (eventName == null || eventParams == null) return;

            var analytics = AnalyticsSingleton.GetInstance.Analytics;

            var bundle = new Bundle();

            foreach (var eventParam in eventParams)
            {
                if (eventParam.Value.GetType() == typeof(string))
                {
                    bundle.PutString(eventParam.Key, (string)eventParam.Value);
                }

                if (eventParam.Value.GetType() == typeof(int))
                {
                    bundle.PutInt(eventParam.Key, (int)eventParam.Value);
                }
            }

            analytics.LogEvent(eventName, bundle);
        }

        public void Screen(string screenName)
        {
            if (screenName == null) return;

            var analytics = AnalyticsSingleton.GetInstance.Analytics;
            var activity = AnalyticsSingleton.GetInstance.Activity;

            analytics.SetCurrentScreen(activity, screenName, null);
        }
    }
}