using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Demo.Views
{
    public partial class CrimeDetailsForm : MetroForm
    {
        private Perpetrator perpetrator;
        String[] types_of_crimes                     = { "Crime againist Person", "Crime againist Property", "Crime againist Morality", "White-collar crime" };
        String[] crimes_againist_persons             = { "murder", "aggrevated assault", "rape", "robbery" };
        String[] crimes_againist_property            = { "theft", "burglary", "laceny", "auto theft", "arson" };
        String[] crimes_againist_morality            = { "prostitution", "illegal gambling", "drug use" };
        String[] white_collar_crimes                 = { "embezzling", "insider trading", "tax evasion" };
        Crime crime;
        
        public CrimeDetailsForm(Perpetrator perpetrator_id)
        {
            this.perpetrator                         = perpetrator_id;
            InitializeComponent();
            this.button_getVictims.Visible           = false;
        }

        public CrimeDetailsForm(Crime crime)
        {
            InitializeComponent();
            SetCrimeDetails(crime);
            DisableControls();
            this.crime                               = crime;
        }

        private void DisableControls()
        {
            this.dateTimePicker_dateOfCrime.Enabled  = false;
            this.comboBox_type_of_crime.Enabled      = false;
            this.comboBox_crimeCommited.Enabled      = false;
            this.textfield_details_of_crime.Enabled  = false;
            this.textfield_crime_location.Enabled = false;
            this.button_save.Visible                 = false;
        }

        private void SetCrimeDetails(Crime crime)
        {
            this.dateTimePicker_dateOfCrime.Text     = crime.date_of_crime;
            this.comboBox_type_of_crime.Text         = crime.type_of_crime;
            this.comboBox_crimeCommited.Text         = crime.crime_committed;
            this.textfield_details_of_crime.Text     = crime.details_of_crime;
            this.textfield_crime_location.Text = crime.location;
        }

        private void button_getVictims_Click(object sender, EventArgs e)
        {
            button_getVictims.Enabled = false;

            Victim[] victims                         = VictimsManager.GetVictimsOfCrime(this.crime.id);

            foreach (var victim in victims) 
            {
                victim.items_stolen=StolenItemsManager.GetVictimsStolenItems(victim.id);
                VictimsDetailsForm form = new VictimsDetailsForm(victim);
                form.Show();
            }

            
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //DISABLE BUTTON
            button_save.Enabled = false;

            //get crime details
            String date_of_crime                     = dateTimePicker_dateOfCrime.Text;
            String time_of_crime                     = GetTimeOfCrime();
            String type_of_crime                     = comboBox_type_of_crime.Text;
            String crime_commited                    = comboBox_crimeCommited.Text;
            String details_of_crime                  = textfield_details_of_crime.Text;
            String location_of_crime = textfield_crime_location.Text;

            //create crime object
            Crime crime                              = new Crime(date_of_crime, details_of_crime, type_of_crime, crime_commited, time_of_crime,location_of_crime,-1);


            //if the crime selected has victims
            if (comboBox_type_of_crime.Text.Equals(types_of_crimes[0]) || comboBox_type_of_crime.Text.Equals(types_of_crimes[1]))
            {

                //create victims form
                VictimsDetailsForm form              = new VictimsDetailsForm(perpetrator, crime);

                //close this form
                this.Close();

                //show it
                form.ShowDialog();
                
                //return
                return;
            }

            // we are dealing with a victimless crime
            else
            {
                Debug.WriteLine("Text                =" + comboBox_crimeCommited.Text);
                Debug.WriteLine("This Crime Has No Victims");
                //save perpetrator
                PerpetratorsManager.Save(perpetrator);

                //set the id of the perpetrator
                crime.perpetrator_id                 = perpetrator.id;


                //save crime
                bool sucess                          = CrimesManager.Save(crime);


            }

            //display error message


        }

       
        private string GetTimeOfCrime()
        {
            return comboBox_hours.Text+":"+comboBox_minutes.Text;
        }

        private void type_of_crime_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_type_of_crime.Text)
            {
                case "Crime againist Person":
                    comboBox_crimeCommited.Items.Clear();
                    comboBox_crimeCommited.Items.AddRange(crimes_againist_persons);

                    break;
                case "Crime againist Property":
                    comboBox_crimeCommited.Items.Clear();
                    comboBox_crimeCommited.Items.AddRange(crimes_againist_property);
                    break;
                case "Crime againist Morality":
                    comboBox_crimeCommited.Items.Clear();
                    comboBox_crimeCommited.Items.AddRange(crimes_againist_morality);
                    break;
                case "White-collar crime":
                    comboBox_crimeCommited.Items.Clear();
                    comboBox_crimeCommited.Items.AddRange(white_collar_crimes);
                    break;
            }
            comboBox_crimeCommited.Enabled           = true;
            comboBox_crimeCommited.SelectedIndex     = 0;
        }

        private void CrimeDetailsForm_Load(object sender, EventArgs e)
        {
            comboBox_type_of_crime.SelectedIndex     = 0;
            comboBox_hours.SelectedIndex             = 0;
            comboBox_minutes.SelectedIndex           = 0;
        }

        private void CrimeDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                PerpetratorDetailsForm.another_crime = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
