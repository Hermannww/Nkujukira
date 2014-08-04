using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nkujukira.Demo.Threads
{
    public class VideoFromFileThreadUsingCamera:AbstractThread
    {
        private Camera camera;
        private Image<Bgr, byte> current_frame;
        public static bool WORK_DONE;

        public VideoFromFileThreadUsingCamera(Camera camera) :base()
        {
            this.camera = camera;
            WORK_DONE = false;
        }


        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO THE CONCURRENT QUEUE FOR OTHER THREADS TO PROCESS
        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs ex)
        {
            try
            {
                while (running)
                {
                    if (!paused)
                    {
                        AddNextFrameToQueueForProcessing();
                        Thread.Sleep(SLEEP_TIME);
                    }
                }
                CleanUp();
            }
            catch (Exception e)
            {
                //CATCH ANY WEIRD EXCEPTIONS HERE
                //LIKE OBJECT DISPOSED EXCEPTION
                Debug.WriteLine(e.Message + "In FILE GRABBER");
            }
        }

        private void CleanUp()
        {
            try
            {
                current_frame.Dispose();
                camera.camera_capture.Dispose();
                current_frame = null;
                camera = null;
            }
            catch (Exception) { }
        }



        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE FRAMES
        public bool AddNextFrameToQueueForProcessing()
        {

            using (current_frame   = FramesManager.GetNextFrame(camera.camera_capture))
            {
                if (current_frame != null)
                {
                    int width      = Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.review_image_box).Width;
                    int height     = Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.review_image_box).Height;
                    Size new_size  = new Size(width, height);

                    Singleton.REVIEW_FRAMES_TO_BE_PROCESSED.Enqueue(FramesManager.ResizeColoredImage(current_frame.Clone(), new_size));

                    return true;
                }

                //FRAME IS NULL 
                //MEANING END OF FILE IS REACHED
                else
                {
                    //ADD BLACK FRAME TO DATASTORE AND TERMINATE THREAD
                    //ALSO SIGNAL TO OTHERS THAT THIS THREAD IS DONE
                    WORK_DONE = true;
                    running   = false;
                    Debug.WriteLine("Terminating video from file");
                    return false;
                }
               
            }

        }



        //JUMPS FORWARD OR BACKWARDS IN THE VIDEO PLAYING
        public bool RewindOrForwardVideo(double millisecond_to_jump_to)
        {
            //SETS THE POINTER TO THE FRAME BEFORE THE SPECIFIED MILLISECOND
            //bool sucess = FramesManager.PerformSeekOperationInVideo(millisecond_to_jump_to, video_file.video_capture);
            return true;
        }

       
    }
}
