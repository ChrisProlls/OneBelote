using OneBelote.Model;
using OneBelote.Strings;
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
    public partial class ScoreParameterPopup : ContentPage
    {
        private ScoreParameterPopupViewModel ViewModel => BindingContext as ScoreParameterPopupViewModel;

        public ScoreParameterPopup()
        {
            InitializeComponent();

            BindingContext = App.Locator.ScoreParameterPopup;
            ViewModel.Reset();
        }

        public ScoreParameter GetScoreParameter()
        {
            return this.ViewModel.GetScoreParameter();
        }

        public async Task OnGoClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
            this.OnGoClicked();
        }

        #region Event

        protected virtual void OnGoClicked()
        {
            GoClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler GoClicked;

        #endregion
    }
}