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
using MetroFramework.Demo.FactoryMethod;
using MetroFramework.Demo.Factories;

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

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// 

        public LoginForm()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
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
           
        }



        public string DATABASE = "MYSQL";

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (user_name.Text == "" && pass_word.Text == "")
            {

                progressBar.Enabled = false;
                timer1.Enabled = false;
                progressBar.Visible = false;
                progressBar.Value = 0;
                label3.Text = "Please!! Enter Your Username or Password.";
            }
            else 
            {
                progressBar.Visible = true;
                progressBar.Value = progressBar.Value + 5;
                label3.Visible = true;
                label3.Text = "Please Wait While we are checking Authentication...";

                if (progressBar.Value == progressBar.Maximum)
                {

                    DatabaseInterface dataBaseFactory = new DatabaseFactory().getDataBase(DATABASE);
                    try
                    {
                        String user = user_name.Text;
                        String password = pass_word.Text;
                        if (dataBaseFactory.getUser(user, password) == true)
                        {
                            if (MySQLDatabaseHandler.firstUser == true)
                            {
                                MetroMessageBox.Show(this, "Please You are advised to change your login credentials", "WARNING");
                                (new ChangeInitialLoginSettingsForm()).Show();
                                this.Close();
                            }
                            else
                            {

                                timer1.Enabled = false;
                                progressBar.Visible = false;
                                label3.Text = "Welcome!! you are Authorised User.";
                                progressBar.Enabled = false;
                                progressBar.Value = 0;
                                (new MainWindow()).Show();
                                this.Close();
                            }


                        }
                        else
                        {

                            progressBar.Enabled = false;
                            timer1.Enabled = false;
                            progressBar.Visible = false;
                            progressBar.Value = 0;
                            user_name.Text = "";
                            pass_word.Text = "";
                            label3.Text = "Sorry!! Username or Password is Wrong.";

                        }



                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);

                    }
                }
            }
            
        }
    }


}
