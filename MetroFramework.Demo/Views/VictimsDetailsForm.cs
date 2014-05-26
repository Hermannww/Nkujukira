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
    public partial class VictimsDetailsForm : MetroForm
    {
        //the id of the crime commited againist this victim
        private int crime_id;

        //constructor
        public VictimsDetailsForm(int crime_id)
        {
            this.crime_id = crime_id;
            InitializeComponent();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //get victim details
            String name         = name_text_box.Text;
            String d_o_b        = date_of_birth.Text;
            String gender       = gender_comoboBox.Text;
            bool is_a_student   = is_a_student_comboBox.Text.Equals("Yes")?true:false;
            String[] items_lost = GetItemsLost();
            int id              = VictimsManager.VICTIM_ID;

            //create victims object
            Victim victim = new Victim(name, d_o_b, items_lost, gender, is_a_student, crime_id);

            //save victim
            bool sucess= VictimsManager.Save(victim);

            if (sucess) 
            {
                //close this form
                this.Close();

                //return
                return;
            }

            //display error message

        }

        private string[] GetItemsLost()
        {
            return null;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            //close this form
            this.Close();
        }

        private void VictimsDetailsForm_Load(object sender, EventArgs e)
        {
            name_text_box.Focus();
        }








    }
}
