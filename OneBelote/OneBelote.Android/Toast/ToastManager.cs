using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OneBelote.Toast;
using OneBelote.Droid.Toast;

[assembly: Xamarin.Forms.Dependency(typeof(ToastManager))]
namespace OneBelote.Droid.Toast
{
    public class ToastManager : IToast
    {
        public void ShortAlert(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}