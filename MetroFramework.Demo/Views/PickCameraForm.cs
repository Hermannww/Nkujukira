using MetroFramework.Forms;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nkujukira.Demo.Views
{
    public partial class PickCameraForm : MetroForm
    {
        private string ERROR_MSG="Please select a camera to use";
        private Camera[] all_cameras;
        public  Camera selected_camera{get;set;}

        public PickCameraForm()
        {
            InitializeComponent();

        }

        private void PickCameraForm_Load(object sender, EventArgs e)
        {
            all_cameras=CameraManager.GetAllCamerasConnectedToSystem();
            AddCamerasToComboBox();
        }

        public void AddCamerasToComboBox()
        {
            //-> clear the combobox
            ComboBoxCameraList.DataSource = null;
            ComboBoxCameraList.Items.Clear();

            //-> bind the combobox
            foreach (var camera in all_cameras) 
            {
                ComboBoxCameraList.Items.Add(camera.name);
            }
           
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            
            int selected_index = ComboBoxCameraList.SelectedIndex;

            //IF USER SELECTS NOTHING
            if (selected_index == -1) 
            {
                MessageBox.Show(ERROR_MSG);
                return;
            }

            //GET SELECTED CAMERA
            selected_camera = all_cameras[selected_index];

            //IF SELECTED CAMERA IS A NETWORK CAMERA
            if (selected_camera.name == "Network Camera") 
            {
                //GET IP ADDRESS
                GetIpAdressForm form = new GetIpAdressForm();
                form.ShowDialog();
                selected_camera.ip_address = form.ip_adress;
            }

            selected_camera.InitializeCameraCapture();

            this.Close();
           
        }


    }
}
