using OneBelote.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBelote.ViewModel
{
    public class ScoreParameterPopupViewModel
    {
        public BeloteAnnouncementPickerModel SelectedAnnoucement { get; set; }
        public List<BeloteAnnouncementPickerModel> PickerModels
        {
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
    }
}
