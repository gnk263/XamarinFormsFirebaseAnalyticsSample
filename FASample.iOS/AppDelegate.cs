using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Firebase.Analytics;
using Firebase.PerformanceMonitoring;

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
            Firebase.Crashlytics.Crashlytics.Configure();

            var trace = Performance.StartTrace("XamarinFormsInitTrace");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            trace.Stop();

            return base.FinishedLaunching(app, options);
        }
    }
}
