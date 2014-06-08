using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Interfaces;

namespace MetroFramework.Demo.Views
{
    public partial class DashBoardDialog : MetroForm
    {
        public DashBoardDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;


           /* if (MainWindow.REMOVE_LOGIN_COMPONENT == true)
            {
                remove_login_component.Checked = true;

            }
            else
            {
                remove_login_component.Checked = false;
            }*/
        }

        private void DashBordDialog_Load(object sender, EventArgs e)
        {

        }

        private void save_changes_Click(object sender, EventArgs e)
        {
            FileFactory file_factory = new FileFactory();
            FileInterface text_file = file_factory.GetFile("TEXTFILE");
            String remove_login_component_checked = null;
            if (remove_login_component.Checked == true)
            {

                remove_login_component_checked = "yes";

            }
            else
            {
                remove_login_component_checked = "no";

            }
            bool seetings_saved = text_file.writeToFile("dashBoard.txt", change_theme.Text + "," + remove_login_component_checked);
            if (seetings_saved == true)
            {
                MetroMessageBox.Show(this, "Changes Saved Successfully", "CONGRATULATIONS");
            }
            else
            {
                MetroMessageBox.Show(this, "Changes not saved\n Please try Again", "ERROR");
            }
        }
    }
}
