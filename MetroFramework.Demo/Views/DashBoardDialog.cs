using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using Nkujukira.Demo.Factories;
using Nkujukira.Demo.Interfaces;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using MetroFramework;

namespace Nkujukira.Demo.Views
{
    public partial class DashBoardDialog : MetroForm
    {
        public DashBoardDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Blue;    
        }

        private void DashBordDialog_Load(object sender, EventArgs e)
        {

        }

        private void save_changes_Click(object sender, EventArgs e)
        {
            if (remove_login_component.Checked)
            {
                Setting setting = SettingsManager.GetSetting(Setting.DISABLE_LOGIN_COMPONENT);
                setting.value = "true";
                SettingsManager.Save(setting);
            }
            else
            {
                Setting setting = SettingsManager.GetSetting(Setting.DISABLE_LOGIN_COMPONENT);
                setting.value = "false";
                SettingsManager.Save(setting);
            }
        }

        private void remove_login_component_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
