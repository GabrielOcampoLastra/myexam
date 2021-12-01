using MyExam.Platform;
using Foundation;
using UIKit;

namespace MyExam.iOS.Platform
{
    /// <summary>
    /// Implementation of interface IAppUrl for iOS
    /// </summary>
    public class AppUrl : IAppUrl
    {
        /// <summary>
        /// Opens phone aplication to make call.
        /// </summary>
        /// <param name="number">Number to make call</param>
        public void OpenCallPhone(string number)
        {
            NSUrl urlToOpen = new NSUrl(string.Empty);
            urlToOpen = new NSUrl("tel:");
            if (UIApplication.SharedApplication.CanOpenUrl(urlToOpen))
            {
                urlToOpen = new NSUrl(string.Format("tel:{0}", number));
            }
            UIApplication.SharedApplication.OpenUrl(urlToOpen);
        }
    }
}