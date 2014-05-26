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
    public partial class CrimeDetailsForm : MetroForm
    {
        int perpetrator_id;

        public CrimeDetailsForm(int perpetrator_id)
        {
            this.perpetrator_id = perpetrator_id;
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            PerpetratorsManager.Delete(perpetrator_id);
            this.Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //get crime details
            String date_of_crime    = dateTimePicker1.Text;
            String time_of_crime    = GetTimeOfCrime();
            String type_of_crime    = type_of_crime_comboBox.Text;
            String details_of_crime = details_of_crime_textfield.Text;
            int id                  = CrimesManager.CRIME_ID;

            //create crime object
            Crime crime             = new Crime(id, date_of_crime, details_of_crime, type_of_crime, time_of_crime);

            //save crime
            bool sucess             = CrimesManager.Save(crime);

            //if saved
            if (sucess)
            {
                //start face recognition for perpetrator from students database

                //close this form
                this.Close();

                //return
                return;
            }

            //display error message


        }

        private string GetTimeOfCrime()
        {
            return "";
        }

        private void details_of_crime_textfield_MouseDown(object sender, MouseEventArgs e)
        {
            //check for right click
            if (e.Button == MouseButtons.Right) 
            {
                //handle right click by
                //create victim details form
                VictimsDetailsForm form = new VictimsDetailsForm(CrimesManager.CRIME_ID);
                
                //set focus to form
                form.Focus();

                //make it top most form
                form.TopMost = true;

                //show it
                form.Show();
            }
        }
    }
}
