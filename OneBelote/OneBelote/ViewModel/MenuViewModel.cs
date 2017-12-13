using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using OneBelote.Message;
using OneBelote.Model;
using OneBelote.Strings;
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
                new BeloteMenuItem { Title = Resources.HomeLabel,  Page = nameof(Home), Icon = "fa-home" },
                new BeloteMenuItem { Title = Resources.NewGame, Page = nameof(NewGame), Icon = "fa-play" },
                new BeloteMenuItem { Title = Resources.LastParties, Page = nameof(LastGames), Icon = "fa-trophy"  }
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

                Messenger.Default.Send(new NavigatedMessage());
            });
        }
    }
}
