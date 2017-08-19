using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using OneBelote.Model;
using OneBelote.View;
using Plugin.Iconize;
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
        public Command<BeloteMenuItem> NavigateTo { get; set; }

        public ObservableCollection<BeloteMenuItem> _menuItems = new ObservableCollection<BeloteMenuItem>(
            new[]
            {
                new BeloteMenuItem { Title = "Home",  Page = nameof(Home), Icon = "fa-home" },
                new BeloteMenuItem { Title = "Play", Page = nameof(NewGame), Icon = "fa-play" },
                new BeloteMenuItem { Title = "Show results", Page = nameof(Home), Icon = "fa-trophy"  },
                new BeloteMenuItem { Title = "Contact", Page = nameof(Home), Icon = "fa-envelope"  }
            });

        public ObservableCollection<BeloteMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged();
            }
        }

        public MenuViewModel(INavigationService navigationService)
        {
            NavigateTo = new Command<BeloteMenuItem>(sender =>
            {
                navigationService.NavigateTo(sender.Page);
            });
        }
    }
}
