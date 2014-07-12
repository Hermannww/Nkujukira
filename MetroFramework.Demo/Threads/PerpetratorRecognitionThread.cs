using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    //THIS CLASS REPRESENTS A THREAD POLLS A SHARED DATASTORE FOR DETECTED FACES FROM FRAMES FROM CCTV
    //TO COMPARE AGAINIST THE FACES OF PERPETRATORS
    //IF RECOGNITION IS SUCCESSFULL AN ALERT IS GENERATED
    public class PerpetratorRecognitionThread : FaceRecognitionThread
    {
        //FACES MANAGER FOR ENROLLMENT AND COMPARISON OF FACES 
        private FacesManager faces_manager;

        //ARRAY OF ALL ACTIVE PERPETRATORS
        private Perpetrator[] active_perpetrators = null;

        //USED TO SIGNAL TO OTHER THREADS THAT THIS THREAD IS DONE
        public static bool WORK_DONE               = false;

        //FLAG USED TO SIGNAL TO THE THREAD THAT IT SHOULD ENROLL PERP FACES AGAIN
        //BECAUSE THEY HAVE CHANGED IN THE DATABASE
        public static volatile bool enroll_again  = false;

        //CONSTRUCTOR
        public PerpetratorRecognitionThread()
            : base(null)
        {
            WORK_DONE            = false;
            enroll_again        = false;

            this.faces_manager  = new FacesManager();

            //GET ALL ACTIVE PERPETRATORS
            active_perpetrators = Singleton.ACTIVE_PERPETRATORS;

            //LOAD FACES OF PERPETRATORS
            EnrollFacesToBeComparedAgainst();


        }



        //LOADS FACES OF PERPETRATORS FOR TRAINING OF THE NEURAL NETWORK
        protected override void EnrollFacesToBeComparedAgainst()
        {
            try
            {
                //FOR EACH ACTIVE PERPETRATOR ENROLL HIS FACE SO IT CAN BE USED FOR COMPARISON
                foreach (var perpetrator in active_perpetrators)
                {
                    faces_manager.EnrollFaces(perpetrator);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        protected override void RecognizeFace(Image<Gray, byte> face)
        {
            if (active_perpetrators.Length != 0)
            {

                //RESIZE THE FACE TO RECOGNIZE SO ITS EQUAL TO THE FACES ALREADY IN THE TRAINING SET
                int width                    = 120;
                int height                   = 120;

                face                         = FramesManager.ResizeGrayImage(face, new Size(width, height));

                //GET ID OF MOST SIMILAR PERPETRATOR
                FaceRecognitionResult result = faces_manager.MatchFace(face);

                //IF A VALID RESULT IS RETURNED
                if (result != null)
                {
                    //IF A VALID ID IS RETURMED
                    if (result.match_was_found)
                    {
                        //GET PERPETRATOR ASSOCIATED WITH ID
                        foreach (var perp in active_perpetrators)
                        {
                            if (perp.id == result.id)
                            {
                                result.identified_perpetrator = perp;
                                break;
                            }
                        }
                    }
                    Singleton.FACE_RECOGNITION_RESULTS.Enqueue(result);
                }
                return;
            }
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Perp Recognition Thread Running");
            while (running)
            {
                if (!paused)
                {
                    Image<Gray, byte> face_to_recognize;


                    //TRY DEQUEUEING A FACE TO RECOGNIZE FROM SHARED DATASTORE
                    bool sucessfull         = Singleton.FACES_TO_RECOGNIZE.TryDequeue(out face_to_recognize);

                    //IF DEQUEUE IS OK
                    if (sucessfull)
                    {
                        if (enroll_again)
                        {
                            //CLEAR ALREADY ENROLLED FACES
                            faces_manager.ClearEnrolledFaces();

                            //GET THE LATEST ACTIVE PERPS
                            active_perpetrators = Singleton.ACTIVE_PERPETRATORS;

                            //ENROLL FACES OF THE PERPS
                            EnrollFacesToBeComparedAgainst();
                        }

                        //TRY TO RECOGNIZE THE FACE
                        RecognizeFace(face_to_recognize);
                    }

                    //IF NO FACE RETURNED THEN CHECK SUPPLIER THREADS FOR LIFE
                    else 
                    {
                        //IF BOTH HAVE TERMINATED THEN TERMINATE THIS ONE ALSO
                        if (CameraOutputGrabberThread.WORK_DONE && LiveStreamFaceDetectingThread.WORK_DONE) 
                        {
                            running         = false;
                            WORK_DONE        = true;
                        }
                    }
                }
                Thread.Sleep(SLEEP_TIME);
            }
        }
    }
}
