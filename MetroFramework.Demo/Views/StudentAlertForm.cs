using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using Nkujukira.Demo.Entitities;

namespace Nkujukira.Demo.Views
{
    public partial class StudentAlertForm : MetroForm
    {
        private FaceRecognitionResult result;

        public StudentAlertForm(FaceRecognitionResult result)
        {
            this.result = result;
            InitializeComponent();
        }

        private void known_person_pictureBox_Click(object sender, EventArgs e)
        {
            StudentDetailsForm form = new StudentDetailsForm(result.identified_student);
            form.ShowDialog();
        }

        private void StudentAlertForm_Load(object sender, EventArgs e)
        {
            known_person_label.Text = result.identified_student.firstName.ToUpper();
            unknown_person_pictureBox.Image = result.original_detected_face.ToBitmap();
            known_person_pictureBox.Image = result.identified_student.photos[0].ToBitmap();
            similarity_label.Text = "" + Convert.ToInt32(result.similarity) + "%";
        }


    }
}
