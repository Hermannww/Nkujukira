using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class LiveStreamFaceDetectingThread : AbstractThread
    {
        public static string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";

        //signals whether this thread has finished working
        public static bool WORK_DONE;

        //the current frame that is being processed
        private Image<Bgr, byte> current_frame;

        //facial haarcascade file
        private HaarCascade haarcascade;

        //detected faces in the current frame
        public Rectangle[] detected_faces;

        //frame width
        private int frame_width;

        //frame height
        private int frame_height;

        //indicates whether frame grabbing from the cameras has been successfull
        private bool sucessfull;

        public LiveStreamFaceDetectingThread(int frame_width, int frame_height)
            : base()
        {
            haarcascade       = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            this.frame_width  = frame_width;
            this.frame_height = frame_height;
            WORK_DONE         = false;
      
        }


        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            while (running)
            {
                if (!paused)
                {
                    //GET NEXT FRAME
                    //GET DETECTED FACES IN FRAME
                    DetectFacesInFrame();

                    //ADD FRAME TO THE QUEUE FOR DISPLAY
                    StartRecognitionForEachDetectedFace();
                }
            }
        }



        //FIRED WHEN THREAD IS TERMINATING
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            WORK_DONE = true;
        }

        //ADDS A FRAME TO THE DATASTORE MEANT FOR FRAMES TO BE DISPLAYED
        public void StartRecognitionForEachDetectedFace()
        {
            //if frame grabbing was sucessfull
            if (sucessfull)
            {
                if (detected_faces != null)
                {
                    //for each face we have detected in the frame
                    foreach (var detected_face in detected_faces)
                    {
                        //get the face
                        Image<Gray, byte> face = FramesManager.CropSelectedFace(detected_face, current_frame.Clone());

                        //create a new face recognition thread
                        FaceRecognitionThread perpetrator_recognizer = new PerpetratorRecognitionThread(face);

                        //start recognizing
                        perpetrator_recognizer.StartWorking();
                    }
                }

            }
        }



        //DETECTS FACES IN THE CURRENT FRAME
        public void DetectFacesInFrame()
        {
            //try to get a frame from the shared datastore for captured frames
            sucessfull = Singleton.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);


            //if ok
            if (sucessfull)
            {
                //detect faces in frame
                detected_faces = FramesManager.DetectFacesInFrame(current_frame.Clone(), haarcascade);

            }
            //IF NO FRAMES IN DATA STORE
            else
            {
                //IF OUTPUT GRABBER THREAD IS DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if (CameraOutputGrabberThread.WORK_DONE)
                {
                    WORK_DONE = true;
                    running = false;
                }
            }
        }
    }
}
