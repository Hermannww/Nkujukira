using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Factories;

namespace MetroFramework.Demo
{
    public partial class AddNewUserForm : MetroForm
    {
        
        public AddNewUserForm()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeloginCredentials_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (pass_word.Text.Equals(confirm_password.Text))
                {
                    String username = user_name.Text;
                    String password = pass_word.Text;
                    String type = role.Text;
                    if (AdminManager.Exists(username))
                    {
                        MetroMessageBox.Show(this, "User Name already Exists. Please try again", "ERROR");

                    }
                    else
                    {
                        Admin new_admin = new Admin(username, password, type);
                        if (AdminManager.Save(new_admin))
                        {
                            MetroMessageBox.Show(this, "New User Created Successfully", "CONGRATULATIONS");
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Unexpected error occured. Please try again", "ERROR");
                        }

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Please try to confirm your Password\n Passwords dont Match", "ERROR");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void user_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
