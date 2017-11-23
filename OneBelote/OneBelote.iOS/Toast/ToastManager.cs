using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using OneBelote.Toast;
using OneBelote.iOS.Toast;

[assembly: Xamarin.Forms.Dependency(typeof(ToastManager))]
namespace OneBelote.iOS.Toast
{
    public class ToastManager : IToast
    {
        NSTimer alertDelay;
        UIAlertController alert;

        public void ShortAlert(string message)
        {
            ShowAlert(message, 2.0);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

    }
}