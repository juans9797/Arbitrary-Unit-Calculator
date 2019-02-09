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
            if (!Application.Current.Properties.ContainsKey("day"))
            {
                Application.Current.Properties["day"] = 0;
                Application.Current.Properties["IniDate"] = DateTime.Now.Date.ToString();
                for (int j = 0; j < 29; j++)
                {
                    Application.Current.Properties[j.ToString()] = 0;
                }

            }
            if (Application.Current.Properties.ContainsKey("cycle"))
            {
                dCycle = Convert.ToInt32(Application.Current.Properties["cycle"].ToString());
                numCy.Text = "Cycle (Last " + dCycle.ToString() + " Days):";
            }
            var db = (Convert.ToDateTime(Application.Current.Properties["IniDate"].ToString()));
            var dif = (db - DateTime.Now.Date).TotalDays;
            dif = dif * -1;
            if (dif > 1)
            {
                var num = Convert.ToInt32(Application.Current.Properties["day"]);
                if (num+dif < 29)
                {
                    Application.Current.Properties["day"] = num + dif;

                }
                else
                {
                    Application.Current.Properties["day"] = ((num+dif)-29);
                }
                Application.Current.Properties["IniDate"]= DateTime.Now.Date.ToString();
            }
            var picker = DaysList;
            for (int i = 0; i < 29;i++)
            {
                picker.Items.Add(i.ToString());
            }
            var picker1 = Hours;
            for (int i = 0; i < 13; i++)
            {
                picker1.Items.Add(i.ToString());
            }
            var picker2 = Unit;
            for (int i = 0; i < 11; i++)
            {
                picker2.Items.Add(i.ToString());
            }

            CurDate.Text = Application.Current.Properties["day"].ToString();
        }

        private void DaysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var j = DaysList.SelectedItem.ToString();
            Day.Text = Application.Current.Properties[j].ToString();
        }

        private void BClear_Pressed(object sender, EventArgs e)
        {
            var j = DaysList.SelectedItem.ToString();
            Application.Current.Properties[j] = 0;
            Day.Text = Application.Current.Properties[j].ToString();
            DaysList.SelectedIndex = -1;
            Hours.SelectedIndex = -1;
            Unit.SelectedIndex = -1;
        }

        private void BAdd_Pressed(object sender, EventArgs e)
        {
            var j = DaysList.SelectedItem.ToString();
            var current = Convert.ToInt32(Application.Current.Properties[j]);
            var add = Convert.ToInt32(Hours.SelectedItem) * Convert.ToInt32(Unit.SelectedItem);
            Application.Current.Properties[j] = current + add;
            Day.Text = Application.Current.Properties[j].ToString();
            DaysList.SelectedIndex = -1;
            Hours.SelectedIndex = -1;
            Unit.SelectedIndex = -1;
        }

        private void BSettings_Pressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }
    }
}
