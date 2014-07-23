using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nkujukira.Demo.Threads
{
    public class LiveStreamFaceDetectingThread : AbstractThread
    {
        public static string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Singleton.HAARCASCADE_FILE_PATH;

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
        //private bool sucessfull;

        public LiveStreamFaceDetectingThread(Size frame_size)
            : base()
        {
            haarcascade       = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            this.frame_width  = frame_size.Width;
            this.frame_height = frame_size.Height;
            WORK_DONE         = false;
      
        }

        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            Debug.WriteLine("Live Face Dectecting Thread Running");
            while (running)
            {
                if (!paused)
                {
                    //GET NEXT FRAME
                    //GET DETECTED FACES IN FRAME
                    DetectFacesInFrame();                
                }
                //Thread.Sleep(SLEEP_TIME);
            }
        }



        //FIRED WHEN THREAD IS TERMINATING
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            WORK_DONE = true;
        }

        
        //DETECTS FACES IN THE CURRENT FRAME
        public bool DetectFacesInFrame()
        {
            try
            {
                //try to get a frame from the shared datastore for captured frames
                bool sucessfull = Singleton.LIVE_FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);


                //if ok
                if (sucessfull)
                {
                    //detect faces in frame
                    detected_faces = FramesManager.DetectFacesInFrame(current_frame.Clone(), haarcascade);

                    if (detected_faces != null)
                    {
                        //for each face we have detected in the frame
                        foreach (var detected_face in detected_faces)
                        {
                            //get the face
                            Image<Bgr, byte> face = FramesManager.CropSelectedFace(detected_face, current_frame.Clone());

                            //add face to shared datastore so face recog thread can access it
                            Singleton.FACES_TO_RECOGNIZE.Enqueue(face);
                        }
                        detected_faces = null;
                    }
                    return true;


                }

                //IF NO FRAMES IN DATA STORE THEN CHECK SUPPLIER THREAD FOR LIFE
                else
                {
                    CheckForTerminationOfThisThread();
                    return true;
                }
            }
            catch (Exception) 
            {
                return false;
            }
           
        }

        private void CheckForTerminationOfThisThread()
        {
            //IF OUTPUT GRABBER THREAD IS DONE THEN IT MEANS THE FRAMES ARE DONE
            //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
            if (CameraOutputGrabberThread.WORK_DONE)
            {
                WORK_DONE = true;
                running = false;
                Debug.WriteLine("Terminating live face detection");
            }
        }
    }
}
