using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using MediaInfoNET;
using Nkujukira.Demo.Singletons;
using Nkujukira;
using Nkujukira.Demo.Entitities;


//THIS THREAD CONTINUOUSLY PICKS FRAMES FROM A GIVEN VIDEO FILE AND DUMPS THEM IN
//SHARED DATASTORES FOR PROCESSING BY OTHER THREADS
namespace Nkujukira.Demo.Threads
{
    public class VideoFromFileThread : AbstractThread
    {
        private VideoFile video_file;
        private Image<Bgr, byte> current_frame;
        public static bool WORK_DONE;
       

        public VideoFromFileThread(VideoFile video_file): base()
        {
            this.video_file = video_file;
            WORK_DONE = false;
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
                video_file.video_capture.Dispose();
                video_file = null;
                current_frame = null;
            }
            catch (Exception) { }
        }



        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE FRAMES
        public bool AddNextFrameToQueueForProcessing()
        {

            using (current_frame   = FramesManager.GetNextFrame(video_file.video_capture))
            {
                if (current_frame != null)
                {
                    int width      =Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.review_image_box).Width;
                    int height     =Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.review_image_box).Height;
                    Size new_size = new Size(width, height);

                    Singleton.REVIEW_FRAMES_TO_BE_PROCESSED.Enqueue(FramesManager.ResizeColoredImage(current_frame,new_size));
                
                    return true;
                }

                //FRAME IS NULL 
                //MEANING END OF FILE IS REACHED
                else
                {
                    //ADD BLACK FRAME TO DATASTORE AND TERMINATE THREAD
                    //ALSO SIGNAL TO OTHERS THAT THIS THREAD IS DONE
                    WORK_DONE      = true;
                    running        = false;
                    Debug.WriteLine("Terminating video from file");
                }
                return false;
            }

        }

        //JUMPS FORWARD OR BACKWARDS IN THE VIDEO PLAYING
        public bool RewindOrForwardVideo(double millisecond_to_jump_to)
        {
            //SETS THE POINTER TO THE FRAME BEFORE THE SPECIFIED MILLISECOND
            bool sucess = FramesManager.PerformSeekOperationInVideo(millisecond_to_jump_to, video_file.video_capture);
            return sucess;
        }

      
    }
}
