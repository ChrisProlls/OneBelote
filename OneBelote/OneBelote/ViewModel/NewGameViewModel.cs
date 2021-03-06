﻿using GalaSoft.MvvmLight;
using OneBelote.Model;
using OneBelote.SQLite;
using OneBelote.Strings;
using OneBelote.Toast;
using OneBelote.ViewModel.CommandArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public Command<ScoreLine> EditLineCommand { get; set; }
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
        private Score _currentScore;
        private readonly GameDatabase _gameRepository;

        #endregion

        public NewGameViewModel(GameDatabase gameRepository)
        {
            this._gameRepository = gameRepository;

            this.ScoreLines = new ObservableCollection<ScoreLine>();
            this.ScoreLines.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                this.RefreshView();
            };

            this.GetScoreForThemCommand = new Command(GetScoreThem);
            this.GetScoreForUsCommand = new Command(GetScoreUs);
            this.EditLineCommand = new Command<ScoreLine>(line => this.OnEditLineRequested(line));
            this.SaveScoreCommand = new Command(async () => await SaveScore());
        }
        
        #region Methods

        private void GetScoreThem()
        {
            this._currentScoreForTeam = ScoreForTeam.Them;
            this.OnScoreRequested();
        }

        private void GetScoreUs()
        {
            this._currentScoreForTeam = ScoreForTeam.Us;
            this.OnScoreRequested();
        }

        private async Task SaveScore()
        {
            if (this._currentScore == null)
                this._currentScore = new Score();

            this._currentScore.Them = this.ScoreThem;
            this._currentScore.Us = this.ScoreUs;

            // Save score in SQLite
            await this._gameRepository.SaveScore(this._currentScore);

            DependencyService.Get<IToast>().ShortAlert(Resources.SavingOk);
        }

        public void InitScore(Score score)
        {
            this._currentScore = score;

            this.ScoreLines.Clear();
            this.ScoreLines.Add(new ScoreLine
            {
                Them = score.Them,
                Us = score.Us
            });
        }

        public void AddScore(ScoreParameter scoreParam)
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
        }

        public void RefreshView()
        {
            RaisePropertyChanged(nameof(ScoreThem));
            RaisePropertyChanged(nameof(ScoreUs));
        }

        #endregion

        #region Events

        public delegate void ScoreRequestedEventHandler(object sender, EventArgs e);
        public event ScoreRequestedEventHandler ScoreRequested;

        private void OnScoreRequested() 
            => ScoreRequested?.Invoke(this, EventArgs.Empty);

        public delegate void EditLineRequestedEventHandler(object sender, EditLineEventArgs e);
        public event EditLineRequestedEventHandler EditLineRequested;

        private void OnEditLineRequested(ScoreLine line) 
            => EditLineRequested?.Invoke(this, new EditLineEventArgs { LineToEdit = line });

        #endregion
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

    public enum ScoreForTeam
    {
        Them,
        Us
    }
}