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
    public partial class ChangeUserTypeDialog : MetroForm
    {
        public static String id;
        public static String user;
        public static String user_role;
        public ChangeUserTypeDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
            user_name.Text = user;
            role.Text = user_role;
        }

        private void ChangeUserTypeDialog_Load(object sender, EventArgs e)
        {

        }

        private void user_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeUserRole_Click(object sender, EventArgs e)
        {
            DataBaseInterface dataBaseFactory = new DataBaseFactory().getDataBase(DATABASE);
            try {
                bool role_updated = dataBaseFactory.changeUserRole(id, role.Text);
                if (role_updated==true)
                {
                    MetroMessageBox.Show(this, "User Role Updated Successfully", "CONGRATULATIONS");
                }
                else {
                    MetroMessageBox.Show(this, "Unexpected error occured. Please try again", "ERROR");
                }
            }catch(Exception ex){
                Debug.WriteLine(ex.Message);
            }
        }

        public string DATABASE = "MYSQL";
    }
}
