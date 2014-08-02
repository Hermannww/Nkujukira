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
    public partial class PerpetratorAertForm : MetroForm
    {
        private FaceRecognitionResult result;

        public PerpetratorAertForm(FaceRecognitionResult result)
        {
            this.result=result;
            InitializeComponent();
        }

        private void PerpetratorAertForm_Load(object sender, EventArgs e)
        {
            known_person_label.Text         = result.identified_perpetrator.name.ToUpper();
            unknown_person_pictureBox.Image = result.original_detected_face.ToBitmap();
            known_person_pictureBox.Image   = result.identified_perpetrator.faces[0].ToBitmap();
            similarity_label.Text           = "" + Convert.ToInt32(result.similarity) + "%";
        }

        private void known_person_pictureBox_Click(object sender, EventArgs e)
        {
            PerpetratorDetailsForm form = new PerpetratorDetailsForm(result.identified_perpetrator, true);
            form.Show();
        }

    }
}
