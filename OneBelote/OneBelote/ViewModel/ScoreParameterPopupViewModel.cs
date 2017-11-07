using GalaSoft.MvvmLight;
using OneBelote.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBelote.ViewModel
{
    public class ScoreParameterPopupViewModel : ViewModelBase
    {
        public BeloteAnnouncementPickerModel SelectedAnnoucement { get; set; }
        public int Score { get; set; }
        public int AnnouncementThem { get; set; }
        public int AnnouncementUs { get; set; }

        private List<BeloteAnnouncementPickerModel> _pickerModels;
        public List<BeloteAnnouncementPickerModel> PickerModels
        {
            get
            {
                if (_pickerModels == null)
                    this._pickerModels = new List<BeloteAnnouncementPickerModel>
                {
                        new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.NoneContent,
                        Announcement = BeloteAnnoucementEnum.None
                    },
                        new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.Us,
                        Announcement = BeloteAnnoucementEnum.Us
                    },
                    new BeloteAnnouncementPickerModel {
                        Label = Strings.Resources.Them,
                        Announcement = BeloteAnnoucementEnum.Them
                    }
                };

                return this._pickerModels;
            }
        }

        public void Reset()
        {
            this.Score = 0;
            this.SelectedAnnoucement = null;
            this.AnnouncementThem = 0;
            this.AnnouncementUs = 0;

            RaisePropertyChanged(nameof(Score));
            RaisePropertyChanged(nameof(SelectedAnnoucement));
            RaisePropertyChanged(nameof(AnnouncementThem));
            RaisePropertyChanged(nameof(AnnouncementUs));
        }

        public ScoreParameter GetScoreParameter()
        {
            return new ScoreParameter
            {
                Score = this.Score,
                BeloteAnnoucement = this.SelectedAnnoucement?.Announcement ?? BeloteAnnoucementEnum.None,
                Announcement = new AnnoucementParameter
                {
                    Them = this.AnnouncementThem,
                    Us = this.AnnouncementUs
                }
            };
        }
    }
}
