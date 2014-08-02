using Manina.Windows.Forms;
using Nkujukira.Demo.Singletons;
using MetroFramework.Forms;
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
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Threads;

namespace Nkujukira.Demo.Views
{
    public partial class SelectPerpetratorFacesForm : MetroForm
    {
        private LoadingScreen screen                                      = new LoadingScreen();
        public ConcurrentDictionary<int, Image<Bgr, byte>> suspect_faces  = new ConcurrentDictionary<int, Image<Bgr, byte>>();
        private int MIN_NUMBER_OF_FACES_PER_PERP_ALLOWED                  = 3;


        public SelectPerpetratorFacesForm()
        {


            InitializeComponent();
            done_button.Enabled         = false;
            Singleton.SELECT_PERP_FACES = this;
            DisplayLoadingScreen();
            PlayVideoToDetectMoreFaces();

        }


        public void AddImage(Object key, String txt, Image thumbnail)
        {
            this.image_list_view.Items.Add(key, txt, thumbnail);
        }


        private void DisplayLoadingScreen()
        {
            screen.StartWorking();
            screen.Show();
        }

        private void PlayVideoToDetectMoreFaces()
        {
            ReviewFaceDetectingThread.its_time_to_pick_perpetrator_faces = true;
            Singleton.MAIN_WINDOW.ResumeVideo();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //reset mode of face detecting thread
            ReviewFaceDetectingThread.its_time_to_pick_perpetrator_faces = false;

            //create array for the identified perpetrator faces
            Image<Bgr, byte>[] perpetrator_faces = new Image<Bgr, byte>[image_list_view.SelectedItems.Count];

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

            //close this form
            this.Close();

            form.ShowDialog();
        }

        public ImageListView GetImageListView()
        {
            return image_list_view;
        }

        private void ImageListView1_SelectionChanged(object sender, EventArgs e)
        {

            if (image_list_view.SelectedItems.Count >= MIN_NUMBER_OF_FACES_PER_PERP_ALLOWED)
            {
                done_button.Enabled = true;
            }
            else
            {
                done_button.Enabled = false;
            }
        }

        private void SelectPerpetratorFacesForm_Load(object sender, EventArgs e)
        {
            minimum_faces_label.Text = "PICK AT LEAST: " + MIN_NUMBER_OF_FACES_PER_PERP_ALLOWED + " FACES";
        }

    }
}
