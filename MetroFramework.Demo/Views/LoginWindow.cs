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
    public partial class Login : MetroForm
    {
        public const int SC_CLOSE = 61536;
        public const int WM_SYSCOMMAND = 274;
        public bool close = false;

        public Login()
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
            DataBaseInterface dataBaseFactory = new DataBaseFactory().getDataBase(DATABASE);
            try
            {
                String user = user_name.Text;
                String password = pass_word.Text;
                if (dataBaseFactory.getUser(user, password) == true)
                {
                    if (MySQLDataBaseHandler.firstUser==true)
                    {
                        MetroMessageBox.Show(this, "Please You are advised to change your login credentials", "WARNING");
                        (new ChangeInitialLoginSettings()).Show();
                        this.Close();
                    }
                    else
                    {
                        (new MainWindow()).Show();
                        this.Close();
                    }


                }
                else
                {
                    MetroMessageBox.Show(this, "Please Get the right User Login Details", "ERROR");
                    
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
