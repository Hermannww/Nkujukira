using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using MetroFramework.Forms;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo
{
    public partial class PerpetratorDetailsForm : MetroForm
    {
        private Perpetrator perpetrator;

        public PerpetratorDetailsForm(Perpetrator perpetrator)
        {
            InitializeComponent();

            this.perpetrator                     = perpetrator;
            comboBox_is_a_student.SelectedIndex  = 0;
            comboBox_gender.SelectedIndex        = 0;
            button_getCrimes.Visible             = false;
            button_getCrimes.Enabled             = false;
        }

        public PerpetratorDetailsForm(Perpetrator perpetrator,bool alert_mode)
        {
            InitializeComponent();

            this.perpetrator                     = perpetrator;
            SetPerpetratorDetails();
            DisableControls();
        }

        private void DisableControls()
        {
            comboBox_gender.Enabled              = false;
            button_getCrimes.Visible             = true;
            button_getCrimes.Enabled             = true;
            comboBox_is_a_student.Enabled        = false;
            textBox_perpetrator_name.Enabled     = false;
            button_save.Visible                  = false;

        }

        private void SetPerpetratorDetails()
        {
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

        private void save_button_Click(object sender, EventArgs e)
        {
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

            //create crime details form
            CrimeDetailsForm form                = new CrimeDetailsForm(perpetrator);

            //close this one
            this.Close();

            //show the form
            form.ShowDialog();

           

        }

        public Control GetControl(String name) 
        {
            switch (name) 
            {
                case "name":
                    return textBox_perpetrator_name;
                case "is_a_student":
                    return comboBox_is_a_student;
                case "is_active":
                    return comboBox_is_active;
                case "gender":
                    return comboBox_gender;
                case "get crimes":
                    return button_getCrimes;
                default:
                    return null;
            }
        
        }

        private void button_getCrimes_Click(object sender, EventArgs e)
        {

            Crime[] crimes_committed             = CrimesManager.GetCrimesCommitted(perpetrator.id);

            foreach (var crime in crimes_committed) 
            {
                CrimeDetailsForm form            = new CrimeDetailsForm(crime);
                form.Show();
            }
        }

    }
}
