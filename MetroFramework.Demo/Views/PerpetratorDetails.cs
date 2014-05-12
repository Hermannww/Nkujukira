using Emgu.CV;
using Emgu.CV.Structure;
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
    public partial class PerpetratorDetails : MetroForm
    {
        private Bitmap perpetrators_face;

        public PerpetratorDetails( Image<Bgr, byte> perpetrators_face)
        {
            InitializeComponent();
            this.Theme             = MetroThemeStyle.Dark;
            this.Style             = MetroColorStyle.Red;
            this.perpetrators_face = perpetrators_face.ToBitmap();
        }

        private void PerpetratorDetails_Load(object sender, EventArgs e)
        {
            
            Size face_size                = new Size(perpetrator_picture_box.Width,perpetrator_picture_box.Height);
            perpetrator_picture_box.Image = FramesManager.ResizeBitmap(perpetrators_face, face_size);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
