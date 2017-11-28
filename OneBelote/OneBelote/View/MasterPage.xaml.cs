using GalaSoft.MvvmLight.Messaging;
using OneBelote.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneBelote.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            Messenger.Default.Register<NavigatedMessage>(this, (message) => IsPresented = false);

        }
    }
}