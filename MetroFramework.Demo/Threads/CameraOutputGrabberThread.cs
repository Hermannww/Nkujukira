using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;
using Nkujukira;

namespace MetroFramework.Demo.Threads
{
    public class CameraOutputGrabberThread : AbstractThread
    {

        public static Capture camera_capture;
        private Image<Bgr, byte> current_frame;
        public static bool WORK_DONE = false;

        public CameraOutputGrabberThread()
            : base()
        {
            camera_capture           = new Capture(@"C:\Users\ken\Pictures\VDs\video1.AVI");
            WORK_DONE                = false;

        }


        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO THE CONCURRENT QUEUE FOR CAMERA OUTPUT
        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs ex)
        {
            try
            {
                while (running)
                {
                    if (!paused)
                    {
                        AddNextFrameToQueueForProcessing();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE 
        //FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE THREADS LATER
        public bool AddNextFrameToQueueForProcessing()
        {
            //get next frame from camera
            current_frame            = FramesManager.GetNextFrame(camera_capture);

            if (current_frame != null)
            {
                //add frame to queue for display
                Singleton.FRAMES_TO_BE_DISPLAYED.Enqueue(FramesManager.ResizeImage(current_frame.Clone(), Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width, Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height));

                //add frame to queue for storage
                Singleton.FRAMES_TO_BE_STORED.Enqueue(current_frame.Clone());

                //resize frame to save on memory and improve performance
                int width            = Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Width;
                int height           = Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Height;

                current_frame        = FramesManager.ResizeImage(current_frame, width, height);

                //add frame to queue for face detection and recognition
                Singleton.FRAMES_TO_BE_PROCESSED.Enqueue(current_frame.Clone());



                //return
                return true;
            }
            return false;

        }



        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop()
        {
            running                  = false;
            return true;
        }
    }
}
