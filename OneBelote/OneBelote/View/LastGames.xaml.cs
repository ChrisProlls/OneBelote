using OneBelote.ViewModel;
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
	public partial class LastGames : ContentPage
	{
        public LastGamesViewModel ViewModel => BindingContext as LastGamesViewModel;
        public LastGames ()
		{
			InitializeComponent();
            BindingContext = App.Locator.LastGames;
        }

        protected override void OnAppearing()
        {
            ViewModel.RefreshList();

            base.OnAppearing();
        }
    }
}