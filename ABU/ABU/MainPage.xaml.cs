using System;
using Xamarin.Forms;

namespace ABU
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            int dCycle = 0;
            InitializeComponent();
            BSettings.Pressed += BSettings_Pressed;
            DateTime Today = DateTime.Now.ToLocalTime();
            DateTime dateOnly = Today.Date;
            CurDate.Text = dateOnly.ToString("d");
            try
            {
               dCycle = Convert.ToInt32(Application.Current.Properties["cycle"].ToString());
                numCy.Text = "Cycle ("+dCycle.ToString()+" Days):";
            }
            catch (Exception e) { }
            var picker = DaysList;
            for (int i = 0; i < dCycle;i++)
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
