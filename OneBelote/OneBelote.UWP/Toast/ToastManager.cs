using OneBelote.Toast;
using OneBelote.UWP.Toast;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ToastManager))]
namespace OneBelote.UWP.Toast
{
    public class ToastManager : IToast
    {
        public void ShortAlert(string message)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new NotificationOptions()
            {
                Title = "OneBelote",
                Description = message
            };

            var result = notificator.Notify(options);
        }
    }
}
