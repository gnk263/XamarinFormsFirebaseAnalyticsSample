using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Firebase.Analytics;

namespace FASample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // https://github.com/xamarin/GoogleApisForiOSComponents/issues/158#issuecomment-483194061
            var foo = Firebase.Core.Configuration.SharedInstance;

            Firebase.Core.App.Configure();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var events = new Dictionary<string, string>
            {
                {
                    ParameterNamesConstants.ItemCategory,
                    "Friday"
                },
                {
                    ParameterNamesConstants.ItemName,
                    "17:08"
                },
            };

            var sendParams = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(
                events.Values.ToArray(),
                events.Keys.ToArray()
            );

            Analytics.LogEvent(EventNamesConstants.SelectContent, sendParams);

            return base.FinishedLaunching(app, options);
        }
    }
}
