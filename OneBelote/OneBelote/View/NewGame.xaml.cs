using OneBelote.Model;
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
    public partial class NewGame : ContentPage
    {
        public NewGameViewModel ViewModel => BindingContext as NewGameViewModel;

        public NewGame()
        {
            InitializeComponent();
            InitPage();
        }

        public NewGame(Score score) : this()
        {
            ViewModel.InitScore(score);
        }

        private void InitPage()
        {
            BindingContext = App.Locator.NewGame;

            ViewModel.ScoreRequested += async (sender, args) =>
            {
                var scoreModal = new ScoreParameterPopup();
                scoreModal.GoClicked += (object modal, EventArgs e) =>
                {
                    ViewModel.AddScore(scoreModal.GetScoreParameter());
                };

                await Navigation.PushModalAsync(scoreModal);
            };
        }
    }
}