using System;
using RakhraWeatherApp.Services;
using RakhraWeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RakhraWeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1MTg1QDMxMzcyZTM0MmUzMGdBSTNKcGNGWDZhbFh6bllQOGtIVWdzZ2dWQU5NaVZEb0hRbkxRbkFqSkE9");
            var bootstrapper = new AppBootstrapper();
            MainPage = bootstrapper.CreateMainPage();
            //MainPage = new NavigationPage(new ToggledButtonDemoPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
