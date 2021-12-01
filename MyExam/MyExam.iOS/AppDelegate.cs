using MyExam.iOS.Platform;
using MyExam.Platform;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Lottie.Forms.iOS.Renderers;
using Prism;
using Prism.Ioc;
using UIKit;


namespace MyExam.iOS
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
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 220, 69);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White,
                TextShadowColor = UIColor.Clear
            });

            UITableViewCell.Appearance.BackgroundColor = UIColor.FromRGB(242, 242, 242);


            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyCSW9IQKwMEMvr4gML7i1dDKiO-INKovS4");

            LoadApplication(new App(new iOSInitializer()));
            AnimationViewRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.Register<IAppUrl, AppUrl>();
        }
    }
}
