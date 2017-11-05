using OneBelote.Model;
using OneBelote.Strings;

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
	public partial class ScoreParameterPopup : ContentPage
	{
        public BeloteAnnouncementPickerModel SelectedAnnoucement { get; set; }
        public List<BeloteAnnouncementPickerModel> PickerModel {
            get
            {
                return new List<BeloteAnnouncementPickerModel>
                {
                    new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.Us,
                        Announcement = BeloteAnnoucementEnum.Us
                    },
                    new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.NoneContent,
                        Announcement = BeloteAnnoucementEnum.None
                    },
                    new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.Them,
                        Announcement = BeloteAnnoucementEnum.Them
                    },
                };
            }
        }

        public ScoreParameterPopup ()
		{
			InitializeComponent ();
		}
	}
}