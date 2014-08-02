using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MB.Controls;
using MetroFramework.Forms;
using Nkujukira.Demo.Managers;
using System.Diagnostics;
using Nkujukira.Demo.Factories;
using Nkujukira.Demo.Interfaces;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Views;
using Nkujukira.Demo.Singletons;
using Nkujukira.Demo.DataStores;

namespace Nkujukira.Demo
{
    public partial class LoginForm : MetroForm
    {
        //admin object 
        private static Admin admin;

        //flag indicating if user is admin
        private bool is_admin                  =false;
        private Color ERROR_COLOR              =Color.Purple;
        private Color SUCCESS_COLOR            = Color.Green;
        private string WRONG_USERNAME_PASSWORD_ERROR_MSG = "Username/Password Combination Is Wrong.";
        private string EMPTY_FIELDS_ERROR_MSG            = "Enter A Valid Username and Password.";

        
       

        public LoginForm()
        {
            InitializeComponent();
        }

        private void user_login_Click(object sender, EventArgs e)
        {
            try 
            {
                AuthenticateUser();
            }
            catch (CantAcessDatabaseException eX)
            {
                MessageBox.Show(
                                    "Sorry but Nkujukira Cant Acess the Database.Try Again Later"+
                                    "\n Main Error :"+eX.ErrorMessage
                                );
            }
        }

        public void AuthenticateUser()
        {
            DisableControls();

            //get user input
            String username = textbox_username.Text;
            String password = textbox_password.Text;

            //validate user input
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {

                status_label.ForeColor = ERROR_COLOR;
                status_label.Text = EMPTY_FIELDS_ERROR_MSG;
                EnableControls();
                return;
            }

            //enable timer
            timer1.Enabled = true;
            timer1.Start();

            //ENABLE PROGRESS INDICATOR
            spining_progress_indicator.Visible = true;
            spining_progress_indicator.Start();

            //if user is an admin
            admin = AdminManager.GetAdmin(username, password);

            if (admin != null)
            {
                //make admin object a session object
                Singletons.Singleton.ADMIN = admin;

                //signal to show Main Winow
                is_admin = true;

            }

            //wrong credentials provided
            else
            {
                //signal to display error message 
                is_admin = false;

            }
        }

        public void EnableControls()
        {
            button_login.Enabled               = true;
        }

        public void DisableControls() 
        {
            button_login.Enabled               = false;
        }

       


        private void timer1_Tick(object sender, EventArgs e)
        {         
                //log user in or display error msg
                DisplayResultsOfLogin();

                //STOP TIMER
                timer1.Stop();

                //disable timer
                timer1.Enabled                 = false;
        }

        private void DisplayResultsOfLogin()
        {
            //disable some stuff
            spining_progress_indicator.Stop();
            spining_progress_indicator.Visible = false;
            textbox_username.Text              = "";
            textbox_password.Text              = "";

            //user is admin
            if (is_admin)
            {
                //set the admin object to be an admin object
                Singletons.Singleton.ADMIN     = admin;

                //close this form
                this.Close();
            }

            //wrong credentials
            else
            {
                EnableControls();

                status_label.ForeColor         = ERROR_COLOR;

                //display error message
                status_label.Text              = WRONG_USERNAME_PASSWORD_ERROR_MSG;
            }
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            //create setup form
            SetUpForm form                     = new SetUpForm();

            //show the form
            form.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //HIDE THE SPINING PROGRESS INDICATOR
            spining_progress_indicator.Visible = false;
        }

       


    }


}
