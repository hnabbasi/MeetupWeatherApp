using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Views;
using System.IO;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : Application
    {
        static LocationDB database;

        public static LocationDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocationDB(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Location.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=913331d8-6161-4c41-ac75-602058f99478;" +
                     "android=332cad5e-0bfd-4e6b-a53b-088746505588",
                     typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
