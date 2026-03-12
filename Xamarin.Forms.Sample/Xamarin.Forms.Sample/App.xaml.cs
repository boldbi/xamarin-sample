using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sample
{
    public partial class App : Application
    {
        public App()
        {
            // Load configuration from embedded JSON before creating MainPage
            ConfigStore.Load();

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
