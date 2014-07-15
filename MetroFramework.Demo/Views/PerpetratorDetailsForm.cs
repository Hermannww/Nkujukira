using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Custom_Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using MetroFramework.Forms;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo
{
    public partial class PerpetratorDetailsForm : MetroForm
    {
        private Perpetrator perpetrator;
        public static bool another_crime;

        //CONSTRUCTOR USED WHEN U WANT TO CAPTURE DETAILS ABOUT A PERP
        public PerpetratorDetailsForm(Perpetrator perpetrator)
        {
            InitializeComponent();
            another_crime = true;
            this.perpetrator                     = perpetrator;
            comboBox_is_a_student.SelectedIndex  = 0;
            comboBox_gender.SelectedIndex        = 0;
            button_getCrimes.Visible             = false;
            button_getCrimes.Enabled             = false;
            button_is_apprehended.Visible        = false;
        }

        //CoNSTRUCTOR USED WHEN DISPLAYING DETAILS ABOUT A PERPETRATOR
        public PerpetratorDetailsForm(Perpetrator perpetrator,bool alert_mode)
        {
            InitializeComponent();
            another_crime = true;
            this.perpetrator                     = perpetrator;
            SetPerpetratorDetails();
            DisableControls();
        }

        //DISABLES NECESSARY CONTROLS WHEN IN ALERT MODE
        private void DisableControls()
        {
            this.ControlBox = false;
            this.TopMost = true;
            comboBox_gender.Enabled              = false;
            button_getCrimes.Visible             = true;
            button_getCrimes.Enabled             = true;
            comboBox_is_a_student.Enabled        = false;
            textBox_perpetrator_name.Enabled     = false;
            button_save.Visible                  = false;

        }

        //SET PERSONAL DETAILS ABOUT THE PERPTRATOR INTO THE TEXTFIELDS
        private void SetPerpetratorDetails()
        {
            //SET PERSONAL DETAILS ABOUT THE PERPTRATOR
            textBox_perpetrator_name.Text        = perpetrator.name;            
            comboBox_is_a_student.SelectedIndex  = perpetrator.is_a_student ? 0 : 1;            
            comboBox_gender.SelectedIndex        = perpetrator.gender.Equals("Male") ? 0 : 1;
           
        }

        private void PerpetratorDetails_Load(object sender, EventArgs e)
        {
            //resize and display one of the images of the perpetrator
            Size face_size                       = new Size(perpetrator_picture_box.Width, perpetrator_picture_box.Height);
            perpetrator_picture_box.Image        = FramesManager.ResizeBitmap(perpetrator.faces[0].ToBitmap(), face_size);
            
        }

        //EVENT HANDLER
        private void save_button_Click(object sender, EventArgs e)
        {
            //DISABLE BUTTON
            button_save.Enabled = false;

            //get more perpetrator details
            String name                          = textBox_perpetrator_name.Text.Trim();
            String is_a_student                  = comboBox_is_a_student.Text;
            String is_active                     = comboBox_is_active.Text;
            String gender                        = comboBox_gender.Text;


            //create perpetrator object
            perpetrator.name                     = name;
            perpetrator.gender                   = gender;
            perpetrator.is_a_student             = is_a_student.Equals("Yes") ? true : false;
            perpetrator.is_still_active          = is_active.Equals("Yes") ? true : false;

            while (another_crime)
            {
                //create crime details form
                CrimeDetailsForm form = new CrimeDetailsForm(perpetrator);

                //show the form
                form.ShowDialog();
            }

            //close this one
            this.Close();
           

        }

        //EVENT HANDLER
        private void button_getCrimes_Click(object sender, EventArgs e)
        {
            //DISPLAY EACH CRIME COMMITTED BY THE PERP
            Crime[] crimes_committed             = CrimesManager.GetCrimesCommitted(perpetrator.id);

            foreach (var crime in crimes_committed) 
            {
                CrimeDetailsForm form            = new CrimeDetailsForm(crime);
                SoundManager.StopPlayingSound();
                form.Show();
            }
        }

        //EVENT HANDLER
        private void is_apprehended_button_Click(object sender, EventArgs e)
        {
            SoundManager.StopPlayingSound();
            this.perpetrator.is_still_active = false;
            PerpetratorsManager.Update(this.perpetrator);
            Singleton.Delete(this.perpetrator);
            this.Close();
        }

        private void PerpetratorDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundManager.StopPlayingSound();
            ((MyImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).DisableAlertMode();
        }

    }
}
