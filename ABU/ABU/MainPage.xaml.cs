using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ABU
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BSettings.Pressed += BSettings_Pressed;
        }

        private void BSettings_Pressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }
    }
}
