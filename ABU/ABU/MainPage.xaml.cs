using System;
using System.IO;
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
            BAdd.Pressed += BAdd_Pressed;
            BClear.Pressed += BClear_Pressed;
            DaysList.SelectedIndexChanged += DaysList_SelectedIndexChanged;
            DateTime Today = DateTime.Now.ToLocalTime();
            DateTime dateOnly = Today.Date;
            CurDate.Text = dateOnly.ToString("d");
            if (!Application.Current.Properties.ContainsKey("day"))
            {
                Application.Current.Properties["day"] = 0;
                for (int j = 0; j < 31; j++)
                {
                    Application.Current.Properties["day" + j] = "";
                }

            }
            if (Application.Current.Properties.ContainsKey("cycle"))
            {
                dCycle = Convert.ToInt32(Application.Current.Properties["cycle"].ToString());
                numCy.Text = "Cycle (Last " + dCycle.ToString() + " Days):";
            }
            var picker = DaysList;
            for (int i = 0; i < dCycle;i++)
            {
                picker.Items.Add(dateOnly.AddDays(-i).ToString("d"));
            }
        }

        private void DaysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Day.Text = DaysList.SelectedItem.ToString();
        }

        private void BClear_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BAdd_Pressed(object sender, EventArgs e)
        {
            var j = Application.Current.Properties["day"];
            Application.Current.Properties["day" + j] = Convert.ToInt32(Hours) * Convert.ToInt32(Unit);
        }

        private void BSettings_Pressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }
    }
}
