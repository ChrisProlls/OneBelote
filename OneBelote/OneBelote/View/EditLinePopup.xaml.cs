using OneBelote.Model;
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
	public partial class EditLinePopup : ContentPage
	{
        public ScoreLine LineToEdit { get; set; }

        public EditLinePopup(ScoreLine lineToEdit)
		{
            LineToEdit = lineToEdit;
			InitializeComponent ();
            BindingContext = this;
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