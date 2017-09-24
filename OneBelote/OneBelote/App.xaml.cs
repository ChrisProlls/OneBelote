﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneBelote.View;

using Xamarin.Forms;
using OneBelote.Locator;
using OneBelote.Localization;

namespace OneBelote
{
    public partial class App : Application
    {
        private static readonly ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator { get { return _locator; } }

        public App()
        {
            InitializeComponent();

            var detailPage = new NavigationPage(new Home());
            MainPage = new MasterPage();

            var masterPage = MainPage as MasterDetailPage;
            masterPage.Detail = detailPage;

            Locator.Navigation.Initialize(detailPage);

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Strings.Resources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
