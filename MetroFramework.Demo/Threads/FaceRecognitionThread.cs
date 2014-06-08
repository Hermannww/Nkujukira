using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public abstract class FaceRecognitionThread : AbstractThread
    {
        //the eigen distance threshold between 2 images; the bigger it is the more chances of a false positive 
        private const double EIGEN_DISTANCE_THRESHOLD                           = 500;
        private MCvFont font                                                    = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);

        //images of faces of people to be compared againist
        protected List<Image<Gray, byte>> known_faces                           = null;

        //labels of people to be compared againist; it matches the above list index for index
        protected List<string> known_faces_labels                               = null;

        //face of the perpetrator to be recognized
        protected Image<Gray, byte> face_to_recognize                           = null;
        protected string name_of_recognized_face                                = null;
        protected int maximum_iteration, num_labels;

        PictureBox perpetrators_pictureBox                                      = null;
        PictureBox unknown_face_pictureBox                                      = null;

        //Perpetrator[] perps                                                   = null;

        private static int x                                                    = 15;
        private static int y                                                    = 50;
        private int SLEEP_TIME                                                  = 200;

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize): base()
        {
            this.face_to_recognize                                              = face_to_recognize;
            known_faces                                                         = new List<Image<Gray, byte>>();
            known_faces_labels                                                  = new List<string>();
            //LoadPreviousTrainedFaces();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!paused)
            {
                RecognizeFace();
                DisplayFaceRecognitionProgress();
                
            }
        }

        private String RecognizeFace()
        {
            if (known_faces.Count()!= 0)
            {
                //TermCriteria for face recognition with numbers of trained images like maxIteration
                MCvTermCriteria termination_criteria                            = new MCvTermCriteria(maximum_iteration * 3, 0.1);

                Debug.WriteLine("Number Of Images=" + known_faces.Count());
                Debug.WriteLine("Number of Labels=" + known_faces_labels.Count());

                //Eigen face recognizer
                MetroFramework.Demo.Singletons.EigenObjectRecognizer recognizer = new MetroFramework.Demo.Singletons.EigenObjectRecognizer
                                                          (
                                                            known_faces.ToArray(),

                                                            known_faces_labels.ToArray(),

                                                            EIGEN_DISTANCE_THRESHOLD,

                                                            ref termination_criteria
                                                          );

                //resize the face to recognize so its equal to the faces already in the training set
                int width                                                       = known_faces.ToArray()[0].Width;
                int height                                                      = known_faces.ToArray()[0].Height;

                Image<Gray, byte> resized_face                                  = FramesManager.ResizeGrayImage(face_to_recognize, new Size(width, height));

                //attempt to recognize the perpetrator
                name_of_recognized_face                                         = recognizer.Recognize(resized_face);

                Debug.WriteLine("Name=" + name_of_recognized_face);

                return name_of_recognized_face;
            }
            return null;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("PERPETRATOR_NAME=" + name_of_recognized_face);
            base.ThreadIsDone(sender, e);
        }

        protected abstract void LoadPreviousTrainedFaces();



        public void DisplayFaceRecognitionProgress()
        {
            if (known_faces.Count() != 0)
            {
                double i                                                        = 0;

                //create picture box for face to be recognized
                unknown_face_pictureBox                                         = new PictureBox();
                unknown_face_pictureBox.Location                                = new Point(x, y);
                unknown_face_pictureBox.Size                                    = known_faces.ToArray()[0].Size;
                unknown_face_pictureBox.BorderStyle                             = BorderStyle.Fixed3D;
                unknown_face_pictureBox.Image                                   = face_to_recognize.ToBitmap();

                //create picture box for perpetrators
                perpetrators_pictureBox                                         = new PictureBox();
                perpetrators_pictureBox.Location                                = new Point(x + 170, y);
                perpetrators_pictureBox.Size                                    = known_faces.ToArray()[0].Size;
                perpetrators_pictureBox.BorderStyle                             = BorderStyle.Fixed3D;

                //create Progress Label
                Label progress_label                                            = new Label();
                progress_label.Location                                         = new Point(x + 133, y + 50);
                progress_label.ForeColor                                        = Color.Green;
                progress_label.Text                                             = "0%";

                //create separator label
                Label separator                                                 = new Label();
                separator.Location                                              = new Point(5, y + 132);
                separator.AutoSize                                              = false;
                separator.Height                                                = 2;
                separator.Width                                                 = 310;
                separator.BorderStyle                                           = BorderStyle.Fixed3D;

                //add picture boxes to panel in a thread safe way
                Panel panel                                                     = (Panel)Singleton.MAIN_WINDOW.GetControl("detected_faces_panel");
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { unknown_face_pictureBox });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { perpetrators_pictureBox });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { progress_label });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { separator });





                //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
                foreach (var face in known_faces.ToArray())
                {
                    //get the amount of work done
                    int percentage_completed = (int)(((i / (known_faces.Count())) * 100));
                    //display perp face
                    SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());

                    //update progress label
                    SetControlPropertyThreadSafe(progress_label, "Text", "" + percentage_completed + "%");

                    if (percentage_completed >= 97)
                    {
                        percentage_completed = 100;
                    }

                    //let the thread sleep
                    Thread.Sleep(SLEEP_TIME);
                    i++;
                }

                y += 145;

                GenerateAlarm();
            }
        }

        protected abstract void GenerateAlarm();
       

        public delegate void AddItemsToPanel(Control item);

    }
}
