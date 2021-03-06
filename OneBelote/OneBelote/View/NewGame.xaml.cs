﻿using OneBelote.Model;
using OneBelote.ViewModel;
using OneBelote.ViewModel.CommandArgs;
using Plugin.Iconize;
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

            ViewModel.EditLineRequested += async (sender, args) =>
            {
                var editModel = new EditLinePopup(args.LineToEdit);
                editModel.GoClicked += (object modal, EventArgs e) =>
                {
                    this.ViewModel.RefreshView();
                };

                await Navigation.PushModalAsync(editModel);
            };

            InitToolbar();
        }

        private void InitToolbar()
        {
            // Hack because Iconize don't implements UWP
            if (Device.RuntimePlatform == Device.UWP)
                this.ToolbarItems.Add(new ToolbarItem
                {
                    Text = Strings.Resources.Save,
                    Icon = new FileImageSource
                    {
                        File = "Assets/SaveIcon.png"
                    },
                    Command = ViewModel.SaveScoreCommand
                });
            else
                this.ToolbarItems.Add(new IconToolbarItem
                {
                    Icon = "fa-save",
                    IconColor = Color.White,
                    Command = ViewModel.SaveScoreCommand
                });
        }
    }
}