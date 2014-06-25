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
        protected const int SLEEP_TIME                                          = 30;
        protected Label separator                                               = null;
        protected Label progress_label                                          = null;

        
       

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize): base()
        {
            this.face_to_recognize                                              = face_to_recognize;
            known_faces                                                         = new List<Image<Gray, byte>>();
            known_faces_labels                                                  = new List<string>();
            name_of_recognized_face                                             = null;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!paused)
            {
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

        protected abstract void LoadPreviousTrainedFaces();

        public abstract void DisplayFaceRecognitionProgress(int x_pos,int y_pos);

        protected abstract void GenerateAlarm();
       
       

    }
}
