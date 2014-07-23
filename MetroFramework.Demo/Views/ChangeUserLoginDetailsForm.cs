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
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Factories;
using Nkujukira.Demo.Entitities;
using MetroFramework;

namespace Nkujukira.Demo
{
    public partial class ChangeUserLoginDetailsForm : MetroForm
    {
        public ChangeUserLoginDetailsForm()
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
            try
            {
                Admin admin = Singletons.Singleton.ADMIN;
                admin.password = new_pass_word.Text;
                admin.user_name = new_user_name.Text;
                if (admin.user_name.Length <= 0)
                {
                    MessageBox.Show(this, "Please Enter Your User Name", "ERROR");

                }
                else if (admin.password.Length <= 0)
                {
                    MessageBox.Show(this, "Please Enter Your PassWord", "ERROR");
                    
                }
                else
                {
                    if (this.new_pass_word.Text.Equals(this.confirm_new_pass_word.Text))
                    {

                        if (AdminManager.Update(admin))
                        {
                            MessageBox.Show(this, "Your Login details have been Updated Successfully", "CONGRATULATIONS");
                            //this.Hide();
                            //this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show(this, "Unexpected error occured. Please try again", "ERROR");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Please try to confirm your new Password\n They dont Match", "ERROR");
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
