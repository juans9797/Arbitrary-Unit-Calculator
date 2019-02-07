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
                for (int j = 0; j < 31; j++)
                {
                    Application.Current.Properties[j.ToString()] = "";
                }

            }
            if (Application.Current.Properties.ContainsKey("cycle"))
            {
                dCycle = Convert.ToInt32(Application.Current.Properties["cycle"].ToString());
                numCy.Text = "Cycle (Last " + dCycle.ToString() + " Days):";
            }
            var db = (Convert.ToDateTime(Application.Current.Properties["IniDate"].ToString()));
            if((db - DateTime.Now.Date).TotalDays > 1)
            {
                var num = Convert.ToInt32(Application.Current.Properties["day"]);
                if (num < 31)
                {
                    Application.Current.Properties["day"] = num + 1;

                }
                else
                {
                    Application.Current.Properties["day"] = 0;
                }
                Application.Current.Properties["IniDate"]= DateTime.Now.Date.ToString();
            }
            var picker = DaysList;
            for (int i = 0; i < 31;i++)
            {
                picker.Items.Add(i.ToString());
            }

            CurDate.Text = Application.Current.Properties["day"].ToString();
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
            Application.Current.Properties[j.ToString()] = Convert.ToInt32(Hours) * Convert.ToInt32(Unit);
        }

        private void BSettings_Pressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }
    }
}
