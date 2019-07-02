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

            var events = new Dictionary<string, string>
            {
                {
                    "item_category",
                    "August"
                },
                {
                    "item_name",
                    "18th"
                },
            };

            DependencyService.Get<IAnalytics>().LogEvent("select_content", events);

            DependencyService.Get<IAnalytics>().Screen("aaaaa");
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAnalytics>().Screen("bbbbb");
        }
    }
}
