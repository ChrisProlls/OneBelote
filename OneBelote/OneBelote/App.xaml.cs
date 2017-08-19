using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneBelote.View;

using Xamarin.Forms;
using OneBelote.Locator;

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
