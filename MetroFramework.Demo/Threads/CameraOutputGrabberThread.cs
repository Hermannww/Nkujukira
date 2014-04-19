using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Emgu.CV.UI;
using Nkujukira.Threads;
using System.Drawing;
using MetroFramework.Demo;

namespace Nkujukira.Threads
{
    public class CameraOutputGrabberThread : ThreadSuperClass
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
        public override void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    try
                    {
                        if (!running) { break; }
                        AddNextFrameToQueueForProcessing();
                        if (!running) { break; }

                    }
                    catch (Exception e)
                    {
                        //CATCH ANY WEIRD EXCEPTIONS HERE
                        //LIKE OBJECT DISPOSED EXCEPTION
                        if (!running) { break; }
                        Debug.WriteLine(e.Message);
                    }
                }
            }
        }

        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE 
        //FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE THREADS LATER
        public bool AddNextFrameToQueueForProcessing()
        {
            if (!running) { return false; }
            current_frame = FramesManager.GetNextFrame(this.camera_capture);
            if (!running) { return false; }
            if (current_frame != null)
            {
                if (!running) { return false; }
                MainWindow.FRAMES_TO_BE_PROCESSED.Enqueue(current_frame.Clone());
                return true;
            }
            return false;

        }



        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public  override bool RequestStop(Thread thread)
        {
            running = false;
            thread.Join();
            return true;
        }
    }
}
