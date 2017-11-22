using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using OneBelote.Service;
using OneBelote.SQLite;
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
            // VM
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<NewGameViewModel>();
            SimpleIoc.Default.Register<ScoreParameterPopupViewModel>();

            // Service
            SimpleIoc.Default.Register<NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => Navigation);
            SimpleIoc.Default.Register<GameDatabase>();

            Navigation.Configure(nameof(Home), typeof(Home));
            Navigation.Configure(nameof(NewGame), typeof(NewGame));
        }

        public NavigationService Navigation
            => SimpleIoc.Default.GetInstance<NavigationService>();

        public MenuViewModel Menu
            => SimpleIoc.Default.GetInstance<MenuViewModel>();

        public NewGameViewModel NewGame
            => SimpleIoc.Default.GetInstance<NewGameViewModel>();

        public ScoreParameterPopupViewModel ScoreParameterPopup
            => SimpleIoc.Default.GetInstance<ScoreParameterPopupViewModel>();
    }
}
