using GalaSoft.MvvmLight;
using OneBelote.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneBelote.ViewModel
{
    public class NewGameViewModel : ViewModelBase
    {
        #region Commands

        public Command GetScoreForThemCommand { get; set; }
        public Command GetScoreForUsCommand { get; set; }

        public Command SaveScoreCommand { get; set; }

        #endregion

        #region Fields

        public ObservableCollection<ScoreLine> ScoreLines { get; set; }
        public int ScoreThem
        {
            get
            {
                return ScoreLines.Sum(line => line.Them);
            }
        }
        public int ScoreUs
        {
            get
            {
                return ScoreLines.Sum(line => line.Us);
            }
        }
        private ScoreForTeam _currentScoreForTeam;

        #endregion

        public NewGameViewModel()
        {
            this.ScoreLines = new ObservableCollection<ScoreLine>();

            /*this.GetScoreForThemCommand = new Command(GetScoreForThem);
            this.GetScoreForUsCommand = new Command(GetScoreForUs);*/

            this.SaveScoreCommand = new Command(() => SaveScore());
        }

        #region Methods

        private void SaveScore()
        {
            // TODO : Save score in roaming ?

            this.ScoreLines.Clear();

            RaisePropertyChanged(nameof(ScoreThem));
            RaisePropertyChanged(nameof(ScoreUs));
        }

        public void SetScore(ScoreParameter scoreParam)
        {
            var scoreThem = 0;
            var scoreUs = 0;

            if (_currentScoreForTeam == ScoreForTeam.Them)
            {
                scoreThem = scoreParam.Score
                    + (scoreParam.BeloteAnnoucement == BeloteAnnoucementEnum.Them ? 20 : 0)
                    + scoreParam.Announcement.Them;

                scoreUs = Math.Max(162 - scoreParam.Score, 0)
                    + (scoreParam.BeloteAnnoucement == BeloteAnnoucementEnum.Us ? 20 : 0)
                    + scoreParam.Announcement.Us;
            }
            else
            {
                scoreThem = Math.Max(162 - scoreParam.Score, 0)
                    + (scoreParam.BeloteAnnoucement == BeloteAnnoucementEnum.Them ? 20 : 0)
                    + scoreParam.Announcement.Them;

                scoreUs = scoreParam.Score
                    + (scoreParam.BeloteAnnoucement == BeloteAnnoucementEnum.Us ? 20 : 0)
                    + scoreParam.Announcement.Us;
            }

            this.ScoreLines.Add(new ScoreLine { Them = scoreThem, Us = scoreUs });

            RaisePropertyChanged(nameof(ScoreThem));
            RaisePropertyChanged(nameof(ScoreUs));
        }

        #endregion
    }

    public class ScoreRequestedEventArgs : EventArgs
    {
        public string ScoreTold { get; set; }
    }

    public class ScoreParameter
    {
        public int Score { get; set; }
        public BeloteAnnoucementEnum BeloteAnnoucement { get; set; }
        public AnnoucementParameter Announcement { get; set; }
    }

    public class AnnoucementParameter
    {
        public int Them { get; set; }
        public int Us { get; set; }
    }

    public enum BeloteAnnoucementEnum
    {
        None,
        Them,
        Us
    }

    public enum ScoreForTeam
    {
        Them,
        Us
    }
}