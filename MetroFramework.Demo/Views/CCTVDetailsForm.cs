using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Threads;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Views
{
    public partial class CCTVDetailsForm : MetroForm
    {
        private Camera cctv_camera;
       
        public CCTVDetailsForm(Camera cctv_camera)
        {
            this.cctv_camera             = cctv_camera;
            InitializeComponent();
            SetCameraDetails();
        }

        private void SetCameraDetails()
        {
            textbox_camera_name.Text     = cctv_camera.name;
            textbox_camera_location.Text = cctv_camera.location;
            label_recording_since.Text   = cctv_camera.recording_since;
            label_video_file_name.Text   = cctv_camera.filepath_to_footage;
        }

    }  
}
