using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;

namespace Nkujukira.Demo.Views
{
    public partial class DashBoard : MetroForm
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            //Update Settings
            Setting similarity_setting      = SettingsManager.GetSetting(SettingsManager.SETTINGS.SIMILARITY_THRESHOLD);
            similarity_setting.value        = ""+similarity_dropdownlist.Value;
            SettingsManager.Update(similarity_setting);

            Setting theme_setting           = SettingsManager.GetSetting(SettingsManager.SETTINGS.THEME);
            theme_setting.value             = change_theme_combobox.Text;
            SettingsManager.Update(theme_setting);

            Setting minimum_number_of_faces = SettingsManager.GetSetting(SettingsManager.SETTINGS.MINIMUM_NUMBER_OF_FACES_ALLOWED)
            minimum_number_of_faces.value   = ""+numericUpDown1.Value;
            SettingsManager.Update(minimum_number_of_faces);

            //show sucess message
            MessageBox.Show("Your Settings Have Been Saved");

            this.Close();
        }
    }
}
