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

        private Image<Gray, byte> gray = null;

        //images of faces of people to be compared againist
        private List<Image<Gray, byte>> training_images = new List<Image<Gray, byte>>();

        //labels of people to be compared againist; it matches the above list index for index
        private List<string> name_labels = new List<string>();
        private List<string> names_of_persons_in_images = new List<string>();

        //face of the perpetrator to be recognized
        private Image<Gray, byte> face_to_recognize = null;
        private string name = null;
        private String all_names = null;
        private int cont_train, num_labels, t;

        PictureBox perpetrators_pictureBox = null;
        PictureBox unknown_face_pictureBox = null;

        Perpetrator[] perps = null;

        private static int x = 0;
        private static int y = 10;

        public FaceRecognitionThread(Image<Gray, byte> face_to_recognize)
            : base()
        {
            this.face_to_recognize = face_to_recognize;
            this.perps = PerpetratorsManager.GetAllActivePerpetrators();
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
                MCvTermCriteria termCrit = new MCvTermCriteria(cont_train, 0.001);

                //Eigen face recognizer
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer
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
                num_labels = Convert.ToInt16(labels.Length);
                cont_train = num_labels;


                for (int i = 0; i < perps.Length; i++)
                {
                    training_images.AddRange(perps[i].faces);
                    name_labels.Add(labels[i]);
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
            foreach (var perpetrator in perps)
            {
                names.Add(perpetrator.name + perpetrator.id);
            }
            return names.ToArray();
        }

        public void DisplayFaceRecognitionProgress(Perpetrator[] perps)
        {
            if (perps.Length != 0)
            {
                int i = 0;

                //create picture box for face to be recognized
                unknown_face_pictureBox = new PictureBox();
                unknown_face_pictureBox.Location = new Point(x, y);
                unknown_face_pictureBox.Size = perps[0].faces[0].Size;

                //create picture box for perpetrators
                perpetrators_pictureBox = new PictureBox();
                perpetrators_pictureBox.Location = new Point(x + 130, y);
                perpetrators_pictureBox.Size = perps[0].faces[0].Size;

                //add picture boxes to panel in a thread safe way
                Panel panel = (Panel)Singleton.MAIN_WINDOW.GetControl("detected_faces_panel");
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { unknown_face_pictureBox });
                panel.Invoke(new AddItemsToPanel(Singleton.MAIN_WINDOW.AddItemsToPanel), new Object[] { perpetrators_pictureBox });

                //for each perpetrator
                foreach (var perpetrator in perps)
                {
                    int percentage_completed = (int)((i / perps.Length) * 100);

                    //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
                    foreach (var face in perpetrator.faces)
                    {
                        SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());
                        Thread.Sleep(500);
                    }

                    i++;
                }

                y += 130;
            }
        }

        public delegate void AddItemsToPanel(Control item);

    }
}
