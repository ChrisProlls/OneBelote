using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using OneBelote.Service;
using OneBelote.View;
using OneBelote.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBelote.Locator
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // VM
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<NewGameViewModel>();

            // Service
            SimpleIoc.Default.Register<NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => Navigation);

            Navigation.Configure(nameof(Home), typeof(Home));
            Navigation.Configure(nameof(NewGame), typeof(NewGame));
        }

        public NavigationService Navigation
            => ServiceLocator.Current.GetInstance<NavigationService>();

        public MenuViewModel Menu
            => ServiceLocator.Current.GetInstance<MenuViewModel>();

        public NewGameViewModel NewGame
            => ServiceLocator.Current.GetInstance<NewGameViewModel>();
    }
}
