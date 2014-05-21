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
using MetroFramework.Demo.FactoryMethod;

namespace MetroFramework.Demo
{
    public partial class AddNewUser : MetroForm
    {
        String DATABASE = "MYSQL";
        public AddNewUser()
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
            DataBaseInterface dataBaseFactory = new DataBaseFactory().getDataBase(DATABASE);
            try
            {
                if (pass_word.Text.Equals(confirm_password.Text))
                {
                    String user = user_name.Text;
                    String password = pass_word.Text;
                    String type = role.Text;
                    if (dataBaseFactory.userNameExists(user))
                    {
                        MetroMessageBox.Show(this, "User Name already Exists. Please try again", "ERROR");

                    }
                    else
                    {
                        bool added = dataBaseFactory.createNewUser(new Admin(user, password, type));
                        if (added == true)
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
