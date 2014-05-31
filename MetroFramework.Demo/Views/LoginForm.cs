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
        public const int SC_CLOSE = 61536;
        public const int WM_SYSCOMMAND = 274;
        public bool close = false;
        /// <summary>
        /// to be used by splash screen
        /// 
        /// </summary>

        private bool m_bLayoutCalled = false;
        //private System.ComponentModel.IContainer components;
        private DateTime m_dt;
        private bool is_admin=false;
        MainWindow main_window = new MainWindow();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// 

        public LoginForm()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
            label4.Visible = false;
            //this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormCosed);
        }

        private void Login_FormCosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        private void user_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void user_login_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            //get user input
            Debug.WriteLine("getting user input");
            String username = user_name.Text;
            String password = pass_word.Text;

            //validate user input
            if (username == "" && password == "")
            {
                progressBar.Enabled = false;
                timer1.Enabled      = false;
                progressBar.Visible = false;
                progressBar.Value   = 0;

                label4.Visible      = true;
                label4.Text         = "Please Enter Your  A Valid Username or Password.";

                return;
            }

            //if user is an admin
            Debug.WriteLine("getting admin");
            Admin admin=AdminManager.GetAdmin(username, password);
            if (admin != null)
            {
                Debug.WriteLine("user in an admin");
                //make admin object a session object
                Singletons.Singleton.ADMIN = admin;

                //signal to show Main Winow
                is_admin = true;

            }

            //wrong credentials provided
            else
            {
                Debug.WriteLine("user is not admin");
                //signal to display error message 
                is_admin = false;

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (progressBar.Value < progressBar.Maximum)
            {
               
                //display loading progress bar
                progressBar.Visible = true;
                progressBar.Value   = progressBar.Value + 5;
                label4.Visible      = true;
                label4.Text         = "Please Wait While we are checking Authentication...";
            }
            else 
            {
                
                //log user in or display error msg
                DisplayResultsOfLogin();

                //disable timer
                timer1.Enabled = false;
                
            }

        }

        private void DisplayResultsOfLogin()
        {
            //disable some stuff
            progressBar.Enabled = false;
            progressBar.Visible = false;
            progressBar.Value   = 0;
            user_name.Text      = "";
            pass_word.Text      = "";

            //user is admin
            if (is_admin)
            {
                
                //log admin
                label4.Text     = "Welcome!! you are Authorised User.";
             
               
                this.Close();
            }

            //wrong credentials
            else
            {
                //display error message
                label4.Text     = "Sorry!! Username or Password is Wrong.";
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SetUpForm form = new SetUpForm();
            form.Show();
        }



    }


}
