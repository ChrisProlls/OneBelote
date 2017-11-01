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

		public NewGame ()
		{
			InitializeComponent();
            BindingContext = App.Locator.NewGame;

            ViewModel.ScoreRequested += async (sender, args) => {
                ScorePopup.ResetPopup(args.ScoreTold);

                ContentDialogScore.Visibility = Visibility.Visible;
                var result = await ContentDialogScore.ShowAsync();
                ContentDialogScore.Visibility = Visibility.Collapsed;

                if (result != ContentDialogResult.None)
                    ViewModel.SetScore(new ScoreParameter
                    {
                        Score = int.Parse(ScorePopup.Score),
                        BeloteAnnoucement = ScorePopup.BeloteAnnouncement,
                        Announcement = new AnnoucementParameter
                        {
                            Them = ScorePopup.AnnouncementThem,
                            Us = ScorePopup.AnnouncementUs
                        }
                    });
            };

        }
    }
}