using System.Collections.Generic;
using System.Linq;

using Foundation;

using Firebase.Analytics;
using Xamarin.Forms;

using FASample.iOS;

[assembly: Dependency(typeof(Analytics_iOS))]
namespace FASample.iOS
{
    public class Analytics_iOS : IAnalytics
    {
        public void LogEvent(string eventName, Dictionary<string, object> eventParams)
        {
            if (eventName == null || eventParams == null) return;

            var sendParams = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(
                eventParams.Values.ToArray(),
                eventParams.Keys.ToArray()
            );

            Analytics.LogEvent(eventName, sendParams);
        }

        public void Screen(string screenName)
        {
            Analytics.SetScreenNameAndClass(screenName, null);
        }
    }
}
