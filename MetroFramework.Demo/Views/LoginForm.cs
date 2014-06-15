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
using MetroFramework.Demo.Managers;
using System.Diagnostics;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Interfaces;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Views;

namespace MetroFramework.Demo
{
    public partial class LoginForm : MetroForm
    {
        //admin object 
        private Admin admin;

        //flag indicating if user is admin
        private bool is_admin              =false;
        
       

        public LoginForm()
        {
            InitializeComponent();
            status_label.Visible           = false;    
        }

        private void user_login_Click(object sender, EventArgs e)
        {
            //enable timer
            timer1.Enabled                 = true;

            //get user input
            String username                = textbox_username.Text;
            String password                = textbox_password.Text;

            //validate user input
            if (String.IsNullOrEmpty(username)||String.IsNullOrEmpty(password))
            {
                progressBar.Enabled        = false;
                timer1.Enabled             = false;
                progressBar.Visible        = false;
                progressBar.Value          = 0;

                status_label.Visible       = true;
                status_label.Text          = "Please Enter Your  A Valid Username or Password.";

                return;
            }

            //if user is an admin
            admin                          =AdminManager.GetAdmin(username, password);

            if (admin != null)
            {
                //make admin object a session object
                Singletons.Singleton.ADMIN = admin;

                //signal to show Main Winow
                is_admin                   = true;

            }

            //wrong credentials provided
            else
            {
                Debug.WriteLine("user is not admin");
                //signal to display error message 
                is_admin                   = false;

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (progressBar.Value < progressBar.Maximum)
            {
               
                //display loading progress bar
                progressBar.Visible        = true;
                progressBar.Value          = progressBar.Value + 5;
                status_label.Visible       = true;
                status_label.Text          = "Please Wait While we are checking Authentication...";
            }
            else 
            {
                
                //log user in or display error msg
                DisplayResultsOfLogin();

                //disable timer
                timer1.Enabled             = false;
                
            }

        }

        private void DisplayResultsOfLogin()
        {
            //disable some stuff
            progressBar.Enabled            = false;
            progressBar.Visible            = false;
            progressBar.Value              = 0;
            textbox_username.Text          = "";
            textbox_password.Text          = "";

            //user is admin
            if (is_admin)
            {
                
                //log admin
                status_label.Text          = "Welcome!! you are Authorised User.";

                //set the admin object to be an admin object
                Singletons.Singleton.ADMIN = admin;

                //close this form
                this.Close();
            }

            //wrong credentials
            else
            {
                //display error message
                status_label.Text          = "Sorry!! Username or Password is Wrong.";
            }
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            //create setup form
            SetUpForm form                 = new SetUpForm();

            //show the form
            form.Show();
        }




    }


}
