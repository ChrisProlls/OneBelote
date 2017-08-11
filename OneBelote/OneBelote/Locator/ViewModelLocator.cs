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

            // Service
            SimpleIoc.Default.Register<NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => Navigation);

            Navigation.Configure(nameof(Home), typeof(Home));
        }

        public NavigationService Navigation
            => ServiceLocator.Current.GetInstance<NavigationService>();

        public MenuViewModel MasterPage
            => ServiceLocator.Current.GetInstance<MenuViewModel>();
    }
}
