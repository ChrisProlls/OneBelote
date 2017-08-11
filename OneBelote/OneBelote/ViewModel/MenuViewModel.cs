using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using OneBelote.Model;
using OneBelote.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace OneBelote.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public Command NavigateTo { get; set; }

        public ObservableCollection<BeloteMenuItem> _menuItems = new ObservableCollection<BeloteMenuItem>(new[]
            {
                    new BeloteMenuItem { Title = "Home", Page = nameof(Home) }
                });

        public ObservableCollection<BeloteMenuItem> MenuItems {
            get { return _menuItems; }
            set {
                _menuItems = value;
                RaisePropertyChanged();
            }
        }
        
        public MenuViewModel(INavigationService navigationService)
        {
            NavigateTo = new Command(sender =>
            {
                var test = "test";
            });
        }
    }
}
