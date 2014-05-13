using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Demo.Managers;
using System.Diagnostics;

namespace MetroFramework.Demo
{
    public partial class ChangeInitialLoginSettings : MetroForm
    {
        public ChangeInitialLoginSettings()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Green;
        }

        private void newUserName_Click(object sender, EventArgs e)
        {

        }
        private void changeInitialCredentials_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            try
            {
                if (db.userTableIsNotEmpty())
                {
                    String new_username = new_UserName.Text;
                    String new_password = new_PassWord.Text;
                    String confirm_new_pass_word = new_ConfirmPassWord.Text;

                    if (new_password.Equals(confirm_new_pass_word))
                    {
                        db.updateLoginCredentials("admin", "123", new_username, new_password);
                        new MainWindow().Show();
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Password is not matching", "ERROR");
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}