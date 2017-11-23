using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using OneBelote.Model;
using OneBelote.SQLite;
using OneBelote.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace OneBelote.ViewModel
{
    public class LastGamesViewModel : ViewModelBase
    {
        public ObservableCollection<Score> Scores { get; set; }

        public Command<Score> SavedScoreClickedCommand { get; set; }

        private GameDatabase _gameRepository;

        public LastGamesViewModel(
            INavigationService navigationService,
            GameDatabase gameRepository)
        {
            _gameRepository = gameRepository;

            Scores = new ObservableCollection<Score>();
            SavedScoreClickedCommand = new Command<Score>(score =>
            {
                navigationService.NavigateTo(nameof(NewGame), score);
            });
        }

        public void RefreshList()
        {
            Scores.Clear();

            foreach (var score in _gameRepository.Score)
                Scores.Add(score);
        }
    }
}
