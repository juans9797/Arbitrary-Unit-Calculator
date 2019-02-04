using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ABU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
            InitializeComponent ();
            DaysC.Completed += DaysC_Completed;
            if (Application.Current.Properties.ContainsKey("cycle"))
            {
                DaysC.Text = Application.Current.Properties["cycle"].ToString();
            }
        }

        private void DaysC_Completed(object sender, EventArgs e)
        {
            Application.Current.Properties["cycle"] = DaysC.Text;
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new MainPage());

        }
    }
}