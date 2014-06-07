using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    class FaceRecognitionThread : AbstractThread
    {
        //the eigen distance threshold between 2 images; the bigger it is the more chances of a false positive 
        private const double EIGEN_DISTANCE_THRESHOLD = 500;
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);

        //images of faces of people to be compared againist
        private List<Image<Gray, byte>> training_images = null;

        //labels of people to be compared againist; it matches the above list index for index
        private List<string> name_labels = null;
        //private List<string> names_of_persons_in_images = new List<string>();

        //face of the perpetrator to be recognized
        private Image<Gray, byte> face_to_recognize = null;
        private string name = null;
        //private String all_names = null;
        private int maximum_iteration, num_labels, t;

        PictureBox perpetrators_pictureBox = null;
        PictureBox unknown_face_pictureBox = null;

        Perpetrator[] perps = null;

        private static int x = 15;
        private static int y = 50;
        private int SLEEP_TIME=200;

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize)
            : base()
        {
            this.face_to_recognize = face_to_recognize;
            this.perps = PerpetratorsManager.GetAllActivePerpetrators();
            training_images = new List<Image<Gray, byte>>();
            name_labels = new List<string>();
            LoadPreviousTrainedFaces();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!paused)
            {
                RecognizeFace();
                DisplayFaceRecognitionProgress(perps);
            }
        }

        private String RecognizeFace()
        {
            if (training_images.ToArray().Length != 0)
            {
                //TermCriteria for face recognition with numbers of trained images like maxIteration
                MCvTermCriteria termCrit = new MCvTermCriteria(maximum_iteration*3, 0.1);

                Debug.WriteLine("Number Of Images=" + training_images.Count());
                Debug.WriteLine("Number of Labels=" + name_labels.Count());

                //Eigen face recognizer
                MetroFramework.Demo.Singletons.EigenObjectRecognizer recognizer = new MetroFramework.Demo.Singletons.EigenObjectRecognizer
                                                          (
                                                            training_images.ToArray(),

                                                            name_labels.ToArray(),

                                                            EIGEN_DISTANCE_THRESHOLD,

                                                            ref termCrit
                                                          );

                //resize the face to recognize so its equal to the faces already in the training set
                int width = training_images.ToArray()[0].Width;
                int height = training_images.ToArray()[0].Height;

                Image<Gray, byte> resized_face = FramesManager.ResizeGrayImage(face_to_recognize, new Size(width, height));
                
                //attempt to recognize the perpetrator
                name = recognizer.Recognize(resized_face);

                Debug.WriteLine("Name=" + name);

                return name;
            }
            return null;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("PERPETRATOR_NAME           =" + name);
            base.ThreadIsDone(sender, e);
        }

        private void LoadPreviousTrainedFaces()
        {
            try
            {

                //Load of previus trainned faces and labels for each image
                string[] labels = GetNamesOfPerpetrators(perps);

                //get the number of labels
                num_labels = Convert.ToInt32(labels.Length);

                maximum_iteration = num_labels;


                for (int i = 0; i < perps.Length; i++)
                {
                    //add the face
                    training_images.AddRange(perps[i].faces);

                    foreach (var face in perps[i].faces)
                    {
                        //add the name of the face
                        name_labels.Add(labels[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private string[] GetNamesOfPerpetrators(Perpetrator[] perps)
        {
            List<String> names = new List<string>();

            //for each perpetrator add their names to the list
            foreach (var perpetrator in perps)
            {
                foreach (var face in perpetrator.faces) 
                {
                    names.Add(perpetrator.name + perpetrator.id);
                }
            }

            //return array
            return names.ToArray();
        }

        public void DisplayFaceRecognitionProgress(Perpetrator[] perps)
        {
            if (perps.Length != 0)
            {
                double i = 0;

                //create picture box for face to be recognized
                unknown_face_pictureBox = new PictureBox();
                unknown_face_pictureBox.Location = new Point(x, y);
                unknown_face_pictureBox.Size = perps[0].faces[0].Size;
                unknown_face_pictureBox.BorderStyle = BorderStyle.Fixed3D;
                unknown_face_pictureBox.Image = face_to_recognize.ToBitmap();

                //create picture box for perpetrators
                perpetrators_pictureBox = new PictureBox();
                perpetrators_pictureBox.Location = new Point(x+170, y);
                perpetrators_pictureBox.Size = perps[0].faces[0].Size;
                perpetrators_pictureBox.BorderStyle = BorderStyle.Fixed3D;

                //create Progress Label
                Label progress_label = new Label();
                progress_label.Location = new Point(x+133, y+50);
                progress_label.ForeColor = Color.Green;
                progress_label.Text = "0%";

                //create separator label
                Label separator = new Label();
                separator.Location = new Point(5, y+132);
                separator.AutoSize = false;
                separator.Height = 2;
                separator.Width = 310;
                separator.BorderStyle = BorderStyle.Fixed3D;

                //add picture boxes to panel in a thread safe way
                Panel panel = (Panel)Singleton.MAIN_WINDOW.GetControl("detected_faces_panel");
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { unknown_face_pictureBox });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { perpetrators_pictureBox });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { progress_label });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { separator });
                

                //for each perpetrator
                foreach (var perpetrator in perps)
                {
                    //get the amount of work done
                    int percentage_completed =(int) (((i / (perps.Length)) * 100));
                    
                    //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
                    foreach (var face in perpetrator.faces)
                    {
                        //display perp face
                        SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());

                        //update progress label
                        SetControlPropertyThreadSafe(progress_label, "Text", ""+percentage_completed+"%");
                        if (percentage_completed >= 97) 
                        {
                            percentage_completed = 100;
                        }

                        //let the thread sleep
                        Thread.Sleep(SLEEP_TIME);      
                    }

                    i++;
                }
                
                y += 145;
            }
        }

        public delegate void AddItemsToPanel(Control item);

    }
}
