using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using Nkujukira;

namespace MetroFramework.Demo
{
    public partial class SelectPerpetratorForm : MetroForm
    {
        private Image<Bgr, byte> frame_with_perpetrator;

        private Point initial_mouse_position = new Point(0, 0);
        private Point current_mouse_position = new Point(0, 0);
        private Point final_mouse_position   = new Point(0, 0);
        private bool drawing_rect            = false;

        public SelectPerpetratorForm(Image<Bgr, byte> perpetrator_frame)
        {
            InitializeComponent();
            Size new_size                       = new Size(perpetrator_frame_picture_box.Width,perpetrator_frame_picture_box.Height);
            perpetrator_frame_picture_box.Image = FramesManager.ResizeBitmap(perpetrator_frame.ToBitmap(), new_size);
            this.frame_with_perpetrator         = perpetrator_frame;
        }



        private void perpetrator_frame_picture_box_MouseDown(object sender, MouseEventArgs e)
        {
            this.initial_mouse_position = e.Location;
            drawing_rect                = true;
        }

        private void perpetrator_frame_picture_box_MouseUp(object sender, MouseEventArgs e)
        {
            this.final_mouse_position = e.Location;
            drawing_rect              = false;
        }

        private void perpetrator_frame_picture_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing_rect)
            {
                this.current_mouse_position = e.Location;
                perpetrator_frame_picture_box.Invalidate();
            }
        }

        private void perpetrator_frame_picture_box_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Green, 1.0F))
            {
                Rectangle current_rect = Rectangle.FromLTRB(
                                       this.initial_mouse_position.X,
                                       this.initial_mouse_position.Y,
                                       this.current_mouse_position.X,
                                       this.current_mouse_position.Y);
                e.Graphics.DrawRectangle(pen, current_rect);
            }
        }

        private void done_button_Click(object sender, EventArgs e)
        {
            if (NoFaceSelected())
            {
                //MetroMessageBox.Show()
                this.Close();
                Singleton.MAIN_WINDOW.ResumeVideo();
                return;
            }

            SelectPerpetratorFacesForm form = new SelectPerpetratorFacesForm();
            form.ShowDialog();
            this.Close();
        }

        private bool NoFaceSelected()
        {
            if (initial_mouse_position.X == 0 && initial_mouse_position.Y == 0 && final_mouse_position.X == 0 && final_mouse_position.Y == 0)
            {
                return true;
            }
            return false;
        }




    }
}
