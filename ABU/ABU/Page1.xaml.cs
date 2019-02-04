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
            try
            {
                DaysC.Text = Application.Current.Properties["cycle"].ToString();
            }
            catch (Exception e){ }

        }

        private void DaysC_Completed(object sender, EventArgs e)
        {
            Application.Current.Properties["cycle"] = DaysC.Text;
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new MainPage());

        }
    }
}