using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private const double EIGEN_DISTANCE_THRESHOLD                           = 100;

        //font for writing on images
        //private MCvFont font                                                    = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);

        //images of faces of people to be compared againist
        protected List<Image<Gray, byte>> known_faces                           = null;

        //labels of people to be compared againist; it matches the above list index for index
        protected List<string> known_faces_labels                               = null;

        //face of the perpetrator to be recognized
        protected Image<Gray, byte> face_to_recognize                           = null;
        protected static string name_of_recognized_face                         = null;
        protected int maximum_iteration, num_labels;

        //controls for displaying results
        protected PictureBox perpetrators_pictureBox                            = null;
        protected PictureBox unknown_face_pictureBox                            = null;
        protected const int SLEEP_TIME                                          = 200;
        protected Label separator                                               = null;
        protected Label progress_label                                          = null;

        
       

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize): base()
        {
            this.face_to_recognize                                              = face_to_recognize            ;
            known_faces                                                         = new List<Image<Gray, byte>>();
            known_faces_labels                                                  = new List<string>()           ;
            name_of_recognized_face = null                                                                     ;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!paused)
            {
                Debug.WriteLine("Recognizing face NOW");
                RecognizeFace(face_to_recognize); 
            }
        }

      public String RecognizeFace(Image<Gray,byte> face)
      {
            if (known_faces.Count()!= 0)
            {
                //Termination criteria for face recognition
                MCvTermCriteria termination_criteria                            = new MCvTermCriteria(maximum_iteration, 0.1);

                //Eigen face recognizer
                Emgu.CV.EigenObjectRecognizer recognizer = new Emgu.CV.EigenObjectRecognizer
                                                          (
                                                            known_faces.ToArray(),

                                                            known_faces_labels.ToArray(),

                                                            EIGEN_DISTANCE_THRESHOLD,

                                                            ref termination_criteria
                                                          );

                //resize the face to recognize so its equal to the faces already in the training set
                int width                                                       = known_faces.ToArray()[0].Width;
                int height                                                      = known_faces.ToArray()[0].Height;

                face_to_recognize                                               = FramesManager.ResizeGrayImage(face, new Size(width, height));

                //attempt to recognize the perpetrator
                name_of_recognized_face                                         = recognizer.Recognize(face_to_recognize);

                Debug.WriteLine("Name=" + name_of_recognized_face);

                return name_of_recognized_face;
            }
            return null;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisplayFaceRecognitionProgress();
        }

        protected abstract void LoadPreviousTrainedFaces();



        public abstract void DisplayFaceRecognitionProgress();
        

        protected abstract void GenerateAlarm();
       

        public class FaceRecognitionProgress:AbstractThread
        {
            

            private List<Image<Gray,byte>> known_faces;
            private PictureBox perp_picturebox;
            private Label progress_label;
            private Image<Gray, byte> current_face;
            private FaceRecognitionThread thread;

            public FaceRecognitionProgress(FaceRecognitionThread thread,PictureBox perp_picturebox,Label progress_label)
            {
                //initialize some variables
                this.known_faces                             = thread.known_faces;
                this.perp_picturebox                         = perp_picturebox;
                this.progress_label                          = progress_label;
                this.thread                                  = thread;

                //initialize back ground worker
                background_worker                            = new BackgroundWorker();
                background_worker.WorkerReportsProgress      = true;
                background_worker.WorkerSupportsCancellation = true;

                //set event handlers
                background_worker.DoWork             += new DoWorkEventHandler(DoWork);
                background_worker.ProgressChanged    += new ProgressChangedEventHandler(ProgressChanged);
                background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ThreadIsDone);

                
            }

            public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                //this keeps track of progress
                double i = 1;

                //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
                foreach (var face in known_faces.ToArray())
                {
                    //get the amount of work done
                    int percentage_completed = (int)(((i / (known_faces.Count())) * 100));

                    //make the current face global access
                    current_face = face;

                    //report progress
                    background_worker.ReportProgress(percentage_completed);

                    //let the thread sleep
                    Thread.Sleep(SLEEP_TIME);

                    i++;
                }
            }

            public override void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                //get percentage completed
                int percentage_completed = e.ProgressPercentage;


                if (percentage_completed >= 100)
                {
                    if ((name_of_recognized_face != null && name_of_recognized_face.Length >= 3))
                    {
                        //update progress label
                        progress_label.ForeColor = Color.Purple;
                        SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");
                    }
                    else
                    {
                        //update progress label
                        progress_label.ForeColor = Color.Red;
                        SetControlPropertyThreadSafe(progress_label, "Text", "No\nMatch\nFound");
                    }
                }
                else
                {
                    //update progress label
                    SetControlPropertyThreadSafe(progress_label, "Text", "" + percentage_completed + "%");
                }
                //display perp facee
                SetControlPropertyThreadSafe(perp_picturebox, "Image", current_face.ToBitmap());

                

               
            }

            public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
            {
                thread.GenerateAlarm();
            }
        
        }

    }
}
