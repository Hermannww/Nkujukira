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
using MetroFramework.Demo.FactoryMethod;
using MetroFramework.Demo.Factories;

namespace MetroFramework.Demo
{
    public partial class ChangeUserLoginDetails : MetroForm
    {
        public ChangeUserLoginDetails()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
        }

        private void ChangeUserLoginDetails_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeloginCredentials_Click(object sender, EventArgs e)
        {
            DataBaseInterface dataBaseFactory = new DataBaseFactory().getDataBase(DATABASE);
            try
            {
                if (this.new_pass_word.Text.Equals(this.confirm_new_pass_word.Text))
                {
                    bool updated = dataBaseFactory.updateLoginCredentials(this.old_user_name.Text, this.old_password.Text, new_user_name.Text, this.new_pass_word.Text);
                    if (updated == true)
                    {
                        MetroMessageBox.Show(this, "Your Login details have been Updated Successfully", "CONGRATULATIONS");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Unexpected error occured. Please try again", "ERROR");
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Please try to confirm your new Password\n They dont Match", "ERROR");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public string DATABASE = "MYSQL";
    }
}
