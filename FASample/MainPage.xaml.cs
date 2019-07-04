using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace FASample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DependencyService.Get<IAnalytics>().Screen("This is MainPage!!!");

            base.OnAppearing();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var events = new Dictionary<string, object>
            {
                {
                    "item_category",
                    "August"
                },
                {
                    "item_name",
                    "18th"
                },
                {
                    "item_id",
                    18
                }
            };

            DependencyService.Get<IAnalytics>().LogEvent("select_content", events);
        }
    }
}
