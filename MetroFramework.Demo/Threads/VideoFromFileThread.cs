using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Nkujukira.Entities;
using System.Drawing;
using Nkujukira.Threads;
using MetroFramework.Demo;


//THIS THREAD CONTINUOUSLY PICKS FRAMES FROM A GIVEN VIDEO FILE AND DUMPS THEM IN
//SHARED DATASTORES FOR PROCESSING BY OTHER THREADS
namespace Nkujukira.Threads
{
    class VideoFromFileThread : ThreadSuperClass
    {
        private const string PROCESSING_THREAD_NAME = "VIDEO_FROM_FILE_THREAD";
        private Capture video_capture;
        public Image<Bgr, byte> current_frame;
        private ImageBox image_box;




        public VideoFromFileThread(String file_name, ImageBox image_box)
            : base()
        {
            if (file_name == null || image_box == null)
            {
                throw new NullReferenceException();
            }

            video_capture = new Capture(file_name);
            this.image_box = image_box;
        }


        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO THE CONCURRENT QUEUE FOR CAMERA OUTPUT
        public override void DoWork()
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
                //CATCH ANY WEIRD EXCEPTIONS HERE
                //LIKE OBJECT DISPOSED EXCEPTION
                Debug.WriteLine(e.Message + "In FILE GRABBER");
            }
        }



        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE FRAMES
        public bool AddNextFrameToQueueForProcessing()
        {

            current_frame = FramesManager.GetNextFrame(this.video_capture, image_box);
            if (current_frame != null)
            {
                if (running)
                {
                    Image<Bgr, byte> clone_1 = current_frame.Clone();
                    Image<Bgr, byte> clone_2 = current_frame.Clone();
                    MainWindow.FRAMES_TO_BE_PROCESSED.Enqueue(clone_1);
                    //MainWindow.FRAMES_TO_BE_DISPLAYED.Enqueue(clone_2);
                    Debug.WriteLine("Frames Added");
                    return true;
                }
                //DISPOSE OF FRAME FOR GARABAGE COLLECTION
                //current_frame = null;
            }

            return false;

        }

        public void RewindOrForwardVideo(double ratio)
        {
            bool sucess = FramesManager.PerformSeekOperationInVideo(ratio, video_capture);
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
