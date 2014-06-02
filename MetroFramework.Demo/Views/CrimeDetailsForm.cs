using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
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

namespace MetroFramework.Demo.Views
{
    public partial class CrimeDetailsForm : MetroForm
    {
        private Perpetrator perpetrator;
        String[] types_of_crimes                     = { "Crime againist Person", "Crime againist Property", "Crime againist Morality", "White-collar crime" };
        String[] crimes_againist_persons             = { "murder", "aggrevated assault", "rape", "robbery" };
        String[] crimes_againist_property            = { "theft", "burglary", "laceny", "auto theft", "arson" };
        String[] crimes_againist_morality            = { "prostitution", "illegal gambling", "drug use" };
        String[] white_collar_crimes                 = { "embezzling", "insider trading", "tax evasion" };
        //internal List<Victim> victims_of_this_crime=new List<Victim>();

        public CrimeDetailsForm(Perpetrator perpetrator_id)
        {
            this.perpetrator                         = perpetrator_id;
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //get crime details
            String date_of_crime                     = dateTimePicker1.Text;
            String time_of_crime                     = GetTimeOfCrime();
            String type_of_crime                     = type_of_crime_comboBox.Text;
            String crime_commited                    = comboBox_crimeCommited.Text;
            String details_of_crime                  = details_of_crime_textfield.Text;

            //create crime object
            Crime crime                              = new Crime(date_of_crime, details_of_crime, type_of_crime, crime_commited, time_of_crime, -1);


            //if the crime selected has victims
            if (type_of_crime_comboBox.Text.Equals(types_of_crimes[0]) || type_of_crime_comboBox.Text.Equals(types_of_crimes[1]))
            {
                
                Debug.WriteLine("This Crime Has Victims");
                //open victims form
                VictimsDetailsForm form              = new VictimsDetailsForm(perpetrator, crime);
                form.Show();

                //close this form
                this.Close();

                //return
                return;
            }

            // we are dealing with a victimless crime
            else
            {
                Debug.WriteLine("Text=" + comboBox_crimeCommited.Text);
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

        private int GetPerpetratorId()
        {
            throw new NotImplementedException();
        }

        private int GetCrimeId()
        {
            throw new NotImplementedException();
        }

        private string GetTimeOfCrime()
        {
            return "";
        }

        public void details_of_crime_textfield_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void type_of_crime_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (type_of_crime_comboBox.Text)
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
        }

        private void CrimeDetailsForm_Load(object sender, EventArgs e)
        {
            type_of_crime_comboBox.SelectedIndex     = 0;
            comboBox_hours.SelectedIndex             = 0;
            comboBox_minutes.SelectedIndex           = 0;
        }
    }
}
