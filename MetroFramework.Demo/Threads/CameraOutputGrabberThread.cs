using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;

namespace Nkujukira.Threads
{
    public class CameraOutputGrabberThread : AbstractThread
    {

        private Capture camera_capture;
        private Image<Bgr, byte> current_frame;
        private ImageBox image_box;

        public CameraOutputGrabberThread(ImageBox image_box)
            : base()
        {
            camera_capture = new Capture();
            this.image_box = image_box;

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
            
            current_frame = FramesManager.GetNextFrame(this.camera_capture);
            
            if (current_frame != null)
            {
                Singleton.FRAMES_TO_BE_PROCESSED.Enqueue(current_frame.Clone());
                return true;
            }
            return false;

        }



        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop()
        {
            running = false;
            return true;
        }
    }
}
