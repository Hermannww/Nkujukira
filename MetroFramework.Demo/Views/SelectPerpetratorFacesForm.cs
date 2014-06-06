using Manina.Windows.Forms;
using MetroFramework.Demo.Singletons;
using MetroFramework.Forms;
using Nkujukira.Threads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Concurrent;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MetroFramework.Demo.Views
{
    public partial class SelectPerpetratorFacesForm : MetroForm
    {
        private LoadingScreen screen = new LoadingScreen();
        //private const int WORKLOAD_THRESHOLD                       = 1000;
        public ConcurrentDictionary<int, Image<Gray, byte>> suspect_faces = new ConcurrentDictionary<int, Image<Gray, byte>>();


        public SelectPerpetratorFacesForm()
        {


            InitializeComponent();

            done_button.Enabled = false;

            Singleton.SELECT_PERP_FACES = this;

            DisplayLoadingScreen(true);

            PlayVideoToDetectMoreFaces();

        }


        public void AddImage(Object key, String txt, Image thumbnail)
        {
            this.image_list_view.Items.Add(key, txt, thumbnail);
        }


        private void DisplayLoadingScreen(bool is_true)
        {
            if (is_true)
            {
                screen.StartWorking();
                screen.Show();
            }
            else
            {
                screen.StopWorking();
                screen.Close();
            }
        }




        private void PlayVideoToDetectMoreFaces()
        {
            FaceDetectingThread.its_time_to_pick_perpetrator_faces = true;

            Singleton.MAIN_WINDOW.ResumeVideo();

        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //reset mode of face detecting thread
            FaceDetectingThread.its_time_to_pick_perpetrator_faces = false;

            //create array for the identified perpetrator faces
            Image<Gray, byte>[] perpetrator_faces = new Image<Gray, byte>[image_list_view.SelectedItems.Count];


            int i = 0;

            //save perpetrator images
            foreach (var item in image_list_view.SelectedItems)
            {
                //get the perpetrator face from the list of suspects faces
                suspect_faces.TryRemove(item.Index, out perpetrator_faces[i]);
                i++;
            }

            Perpetrator perpetrator = new Perpetrator(perpetrator_faces, true, "");


            //clear datastore
            suspect_faces.Clear();

            //open perpetrator details box
            PerpetratorDetailsForm form = new PerpetratorDetailsForm(perpetrator);
            form.Show();

            //close this form
            this.Close();
        }

        public ImageListView GetImageListView()
        {
            return image_list_view;
        }

        private void ImageListView1_SelectionChanged(object sender, EventArgs e)
        {

            if (image_list_view.SelectedItems.Count >= 5)
            {
                done_button.Enabled = true;
            }
            else
            {
                done_button.Enabled = false;
            }
        }

    }
}
