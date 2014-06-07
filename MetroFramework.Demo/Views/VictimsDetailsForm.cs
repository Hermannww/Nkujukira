using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Forms;
using Nkujukira.Threads;
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
        Perpetrator perpetrator;
        Crime crime;
        Victim victim;
        private bool close_after_saving=false;

        //constructor
        public VictimsDetailsForm(Perpetrator perp,Crime crime)
        {
            this.perpetrator                    = perp;
            this.crime                          = crime;
            InitializeComponent();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            timer1.Start();

            close_after_saving = true;

            //save victim details
            SaveVictimDetails();

            

        }

        private void SaveVictimDetails()
        {
            //get victim details
            String name                         = name_text_box.Text;
            String d_o_b                        = date_of_birth.Text;
            String gender                       = gender_comoboBox.Text;
            bool is_a_student                   = is_a_student_comboBox.Text.Equals("Yes") ? true : false;
            

            //save perp
            PerpetratorsManager.Save(perpetrator);

            //set the perp id in the crime
            crime.perpetrator_id                = perpetrator.id;

            //save crime
            CrimesManager.Save(crime);

            StolenItem[] items_lost             = GetItemsLost();

            //create victims object
            victim                              = new Victim(name, d_o_b, items_lost, gender, is_a_student, crime.id);

            //save victim
            VictimsManager.Save(victim);

          

    
        }


        private StolenItem[] GetItemsLost()
        {
            String items_stolen                 = items_lost_textbox.Text;
            String[] items                      =items_stolen.Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
            List<StolenItem> stolen             = new List<StolenItem>();

            foreach (var item in items) 
            {
                StolenItem stolen_item          = new StolenItem(item, -1);
                stolen.Add(stolen_item);
            }

            return stolen.ToArray();

        }

        private void another_victim_button_Click(object sender, EventArgs e)
        {
            timer1.Start();

            close_after_saving = false;

            //save the details of the victim
            SaveVictimDetails();

            //reset text values
            ResetTextValues();

        }

        //resets the text values of all controls on form
        private void ResetTextValues()
        {
            items_lost_textbox.Text             = "";
            name_text_box.Text                  = "";
            gender_comoboBox.SelectedIndex      = 0;
            is_a_student_comboBox.SelectedIndex = 0;
            label1.Text                         = "";
            label1.Visible                      = false;
            
        }

        private void VictimsDetailsForm_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            ResetTextValues();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar.Value < progressBar.Maximum)
            {

                //display loading progress bar
                progressBar.Visible             = true;
                progressBar.Value++;
                label1.Visible                  = true;
                label1.Text                     = "Saving.Please Wait...";
            }
            else
            {

                //log user in or display error msg
                DisplayResultsOfSaving();

                //disable timer
                timer1.Stop();
                timer1.Enabled                  = false;

            }
        }

        private void DisplayResultsOfSaving()
        {
            //DISABLE SOME STUFF
            progressBar.Visible                 = false;
            progressBar.Value                   = 0;
            label1.Visible                      = true;

            //display results of operations
            label1.ForeColor                    = Color.Green;
            label1.Text                         = "Data Saved";

            //
            if (close_after_saving) 
            {
                FaceRecognitionThread face_recognizer = new FaceRecognitionThread(perpetrator.faces[0]);
                face_recognizer.StartWorking();
                //close this form
                this.Close();
                LoadingScreen screen = new LoadingScreen();
                screen.STATUS_TEXT = "Student recognition starting...";
                screen.StartWorking();
            }

        }








    }
}
