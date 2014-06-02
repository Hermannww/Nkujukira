using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using MetroFramework.Forms;
using Nkujukira;
using Nkujukira.Threads;
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
        }

        private void PerpetratorDetails_Load(object sender, EventArgs e)
        {
            //resize and display one of the images of the perpetrator
            Size face_size                       = new Size(perpetrator_picture_box.Width, perpetrator_picture_box.Height);
            perpetrator_picture_box.Image        = FramesManager.ResizeBitmap(perpetrator.faces[1], face_size);
            is_a_student_combo_box.SelectedIndex = 0;
            comboBox_gender.SelectedIndex        = 0;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //get more perpetrator details
            String name                          = perpetrator_name_textbox.Text;
            String is_a_student                  = is_a_student_combo_box.Text;
            String is_active                     = is_active_combo_box.Text;
            String gender                        = comboBox_gender.Text;
           

            //create perpetrator object
            perpetrator.name                     = name;
            perpetrator.gender                   = gender;
            perpetrator.is_a_student             = is_a_student.Equals("Yes") ? true : false;
            perpetrator.is_still_active          = is_active.Equals("Yes") ? true : false;

            //create crime details form
            CrimeDetailsForm form                = new CrimeDetailsForm(perpetrator);

            //show the form
            form.Show();

            //close this one
            this.Close();

        }

    }
}
