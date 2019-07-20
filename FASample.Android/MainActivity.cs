using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Firebase.Analytics;
using Com.Google.Firebase.Perf.Metrics;

namespace FASample.Droid
{
    [Activity(Label = "FASample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [AddTrace(Name = "OnCreateTrace", Enabled = true)]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            AnalyticsSingleton.GetInstance.Analytics = FirebaseAnalytics.GetInstance(this);
            AnalyticsSingleton.GetInstance.Activity = this;

            Fabric.Fabric.With(this, new Crashlytics.Crashlytics());
            Crashlytics.Crashlytics.HandleManagedExceptions();

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


            var analytics = AnalyticsSingleton.GetInstance.Analytics;


            var timestamp = DateTime.Now.ToString("s");

            // ------------------------------------
            var bundle1 = new Bundle();
            bundle1.PutLong(FirebaseAnalytics.Param.Score, 111);
            bundle1.PutLong(FirebaseAnalytics.Param.Level, 333);
            bundle1.PutString(FirebaseAnalytics.Param.Character, $"any_charactor_name_{timestamp}");

            analytics.LogEvent(FirebaseAnalytics.Event.PostScore, bundle1);
            analytics.LogEvent("post_socre_custom1", bundle1);

            bundle1.PutString("post_score_add_param", $"post_score_add_value_{timestamp}");

            analytics.LogEvent(FirebaseAnalytics.Event.PostScore, bundle1);
            analytics.LogEvent("post_socre_custom2", bundle1);

            // ------------------------------------

            var bundle2 = new Bundle();
            bundle2.PutString(FirebaseAnalytics.Param.ContentType, $"any_content_type_{timestamp}");
            bundle2.PutString(FirebaseAnalytics.Param.ItemId, "123");

            analytics.LogEvent(FirebaseAnalytics.Event.SelectContent, bundle2);
            analytics.LogEvent("select_content_custom1", bundle2);

            bundle2.PutString("select_content_add_param", $"select_content_add_value_{timestamp}");

            analytics.LogEvent(FirebaseAnalytics.Event.SelectContent, bundle2);
            analytics.LogEvent("select_content_custom2", bundle2);

            // ------------------------------------

            var bundle3 = new Bundle();
            bundle3.PutString(FirebaseAnalytics.Param.ItemId, "any_item_id");
            bundle3.PutString(FirebaseAnalytics.Param.ItemName, $"any_item_name_{timestamp}");
            bundle3.PutString(FirebaseAnalytics.Param.ItemCategory, "any_item_category");
            
            analytics.LogEvent(FirebaseAnalytics.Event.ViewItem, bundle3);
            analytics.LogEvent("view_item_custom1", bundle3);

            bundle3.PutString("view_item_add_param", $"view_item_add_value_{timestamp}");


            analytics.LogEvent(FirebaseAnalytics.Event.ViewItem, bundle3);
            analytics.LogEvent("view_item_custom2", bundle3);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}