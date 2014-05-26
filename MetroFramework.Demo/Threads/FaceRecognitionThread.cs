using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    class FaceRecognitionThread : AbstractThread
    {
        //the eigen distance threshold between 2 images; the bigger it is the more chances of a false positive 
        private const double EIGEN_DISTANCE_THRESHOLD   = 500;
        private MCvFont font                            = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
       
        private Image<Gray, byte> gray                  = null;

        //images of faces of people to be compared againist
        private List<Image<Gray, byte>> training_images = new List<Image<Gray, byte>>();

        //labels of people to be compared againist; it matches the above list index for index
        private List<string> name_labels                = new List<string>();
        private List<string> names_of_persons_in_images = new List<string>();

        //face of the perpetrator to be recognized
        private Image<Bgr, byte> face_to_recognize      = null;
        private string name                             = null;
        private String all_names                        = null;
        private int cont_train, num_labels, t;

        public FaceRecognitionThread(Image<Bgr, byte> face_to_recognize)
        {
            this.face_to_recognize = face_to_recognize;
           
            LoadPreviousTrainedFaces();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!paused)
            {
                RecognizeFace();
            }
        }

        private String RecognizeFace()
        {
            if (training_images.ToArray().Length != 0)
            {
                //TermCriteria for face recognition with numbers of trained images like maxIteration
                MCvTermCriteria termCrit         = new MCvTermCriteria(cont_train, 0.001);

                //Eigen face recognizer
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer
                                                    (
                                                        training_images.ToArray(),
                                                        name_labels.ToArray(),
                                                        EIGEN_DISTANCE_THRESHOLD,
                                                        ref termCrit
                                                    );

                //resize the face to recognize so its equal to the faces already in the training set
                int width                        =training_images.ToArray()[0].Width;
                int height                       =training_images.ToArray()[0].Height;
                Image<Gray,byte> resized_face    =FramesManager.ResizeImage(face_to_recognize,width,height).Convert<Gray,byte>();

                //attempt to recognize the perpetrator
                name                             = recognizer.Recognize(resized_face);
               
                return name;
            }
            return null;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("PERPETRATOR_NAME=" + name);
            base.ThreadIsDone(sender, e);
        }

        private void LoadPreviousTrainedFaces()
        {
            try
            {
                //Load of previus trainned faces and labels for each image
                string labels_info = File.ReadAllText(Singleton.RESOURCES_DIRECTORY + @"\TrainedFaces\TrainedLabels.txt");
                string[] labels    = labels_info.Split('%');
                num_labels         = Convert.ToInt16(labels[0]);
                cont_train         = num_labels;
                string load_faces;

                for (int tf = 1; tf < num_labels + 1; tf++)
                {
                    load_faces = "face" + tf + ".bmp";
                    training_images.Add(new Image<Gray, byte>(Singleton.RESOURCES_DIRECTORY + @"\TrainedFaces\" + load_faces));
                    name_labels.Add(labels[tf]);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
