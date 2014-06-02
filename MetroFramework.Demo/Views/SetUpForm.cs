using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Views
{
    public partial class SetUpForm : MetroForm
    {
        public SetUpForm()
        {
            InitializeComponent();
            label5.Visible            = false;

        }

        private void user_login_Click(object sender, EventArgs e)
        {
            //ENABLE SOME STUFF
            timer1.Start();
            progressBar.Visible = true;

            //GET USER INPUT
            String username           = txtbox_username.Text;
            String password           = txtbox_password.Text;
            String confirmed_password = txtbox_confirmedPassword.Text;
            String images_folder      = txtbox_saveImagesPath.Text;

            //IF SOME FIELDS ARE EMPTY
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmed_password))
            {
                //disable some stuff
                timer1.Stop();
                progressBar.Enabled   = false;
                progressBar.Visible   = false;
                progressBar.Value     = 0;
                label5.Visible        = true;
                label5.Text           = "Please Enter A Valid Username/Password ";
                return;
            }

            //IF THE PASSWORDS DONT MATCH
            if (!password.Equals(confirmed_password))
            {
                //disable some stuff
                timer1.Stop();
                progressBar.Enabled   = false;
                progressBar.Visible   = false;
                progressBar.Value     = 0;
                label5.Visible        = true;
                label5.Text           = "Sorry!! Your Password Entries Dont Match ";
                return;
            }

            //CREATE OBJECTS
            Admin admin               = new Admin(username, password, "Admin");
            Setting setting           = new Setting("images_folder", images_folder);

            //DROP ALL TABLES IN DATABASE
            DatabaseManager.Droptables();

            //CREATE NEW TABLES
            DatabaseManager.CreateTables();

            //POPULATE THEM WITH INITIAL DATA
            DatabaseManager.PopulateTables();

            //SAVE THE USER AS A NEW ADMIN
            AdminManager.Save(admin);

            //SAVE HIS IMAGES FOLDER AS A SETTING
            SettingsManager.Save(setting);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {

                //display loading progress bar
                progressBar.Visible   = true;
                progressBar.Value ++;
                label5.Visible        = true;
                label5.Text           = "Please Wait While Create The Database...";
            }
            else
            {

                //log user in or display error msg
                DisplayResultsOfLogin();

                //disable timer
                timer1.Stop();
                timer1.Enabled        = false;

            }
        }

        private void DisplayResultsOfLogin()
        {
            //DISABLE SOME STUFF
            progressBar.Visible       = false;
            progressBar.Value         = 0;
            label5.Visible            = true;

            //display results of operations
            label5.Text               = "Welcome!! We are Done Setting Up...\nClose This To Login";
            

        }

        private void SetUpForm_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
