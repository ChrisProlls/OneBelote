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
		public NewGame ()
		{
			InitializeComponent();
            BindingContext = App.Locator.NewGame;
        }
	}
}