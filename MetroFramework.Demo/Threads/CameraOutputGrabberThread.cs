using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System.Threading;

namespace MetroFramework.Demo.Threads
{
    public class CameraOutputGrabberThread : AbstractThread
    {
        //HANDLE TO THE WEB CAM
        public static Capture camera_capture;

        //THE FRAME CURRENTLY BEING WORKED ON
        private Image<Bgr, byte> current_frame;

        //SIGNALS TO OTHER THREADS THAT THIS THREAD HAS FINIHSED WORK
        public static bool WORK_DONE = false;

        private const String FILE_NAME = @"C:\Users\ken\Pictures\VDs\video4.mp4";

        //CONSTRUCTOR
        public CameraOutputGrabberThread()
            : base()
        {
            Debug.WriteLine("Cam output thread starting");
            camera_capture = new Capture(FILE_NAME);
            WORK_DONE= false;

        }


        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO CONCURRENT QUEUES FOR EASY ACCESS BY OTHER THREADS
        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs ex)
        {
            try
            {
                Debug.WriteLine("Cam output thread running");
                while (running)
                {
                    if (!paused)
                    {
                        
                        AddNextFrameToQueuesForProcessing();
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        //ADDS A CAPTURED FRAME TO THREAD SAFE QUEUES 
        //FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE THREADS LATER
        public bool AddNextFrameToQueuesForProcessing()
        {
            //get next frame from camera
            current_frame            = FramesManager.GetNextFrame(camera_capture);

            if (current_frame != null)
            {

                //add frame to queue for display
                Singleton.FRAMES_TO_BE_DISPLAYED.Enqueue(FramesManager.ResizeImage(current_frame.Clone(), Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height));

                //add frame to queue for storage
                //Singleton.FRAMES_TO_BE_STORED.Enqueue(current_frame.Clone());

                //resize frame to save on memory and improve performance
                int width = Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Width;
                int height = Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Height;

                current_frame = FramesManager.ResizeImage(current_frame, width, height);

                //add frame to queue for face detection and recognition
                Singleton.FRAMES_TO_BE_PROCESSED.Enqueue(current_frame.Clone());

                //return
                return true;
            }

            //FRAME IS NULL 
            //MEANING END OF FILE IS REACHED
            else
            {
                //ADD BLACK FRAME TO DATASTORE AND TERMINATE THREAD
                //ALSO SIGNAL TO OTHERS THAT THIS THREAD IS DONE
                WORK_DONE = true;
                running = false;
                Debug.WriteLine("Terminating camera output");
            }
            return false;

        }
    }
}
