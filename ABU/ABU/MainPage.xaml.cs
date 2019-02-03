using System;
using Xamarin.Forms;

namespace ABU
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BSettings.Pressed += BSettings_Pressed;
            DateTime Today = DateTime.Now.ToLocalTime();
            DateTime dateOnly = Today.Date;
            CurDate.Text = dateOnly.ToString("d");
            var picker = DaysList;
            for (int i = 0; i < 7;i++)
            {
                picker.Items.Add(dateOnly.AddDays(-i).ToString("d"));
            }
        }

        private void BSettings_Pressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }
    }
}
