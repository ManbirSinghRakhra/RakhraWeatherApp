using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ReactiveUI;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using UIKit;

namespace RakhraWeatherApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //


        private AutoSuspendHelper suspendHelper;

        public AppDelegate()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE1MTg1QDMxMzcyZTM0MmUzMGdBSTNKcGNGWDZhbFh6bllQOGtIVWdzZ2dWQU5NaVZEb0hRbkxRbkFqSkE9");
            RxApp.SuspensionHost.CreateNewAppState = () => new AppBootstrapper();
        }
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfListViewRenderer.Init();
            SfPullToRefreshRenderer.Init();
            
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
