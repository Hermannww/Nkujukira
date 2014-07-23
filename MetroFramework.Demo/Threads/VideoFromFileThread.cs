using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using MediaInfoNET;
using Nkujukira.Demo.Singletons;
using Nkujukira;


//THIS THREAD CONTINUOUSLY PICKS FRAMES FROM A GIVEN VIDEO FILE AND DUMPS THEM IN
//SHARED DATASTORES FOR PROCESSING BY OTHER THREADS
namespace Nkujukira.Demo.Threads
{
    public class VideoFromFileThread : AbstractThread
    {
        public static Capture video_capture;
        public Image<Bgr, byte> current_frame;
        public static bool WORK_DONE;
       

        public VideoFromFileThread(String file_name): base()
        {
            if (file_name == null)
            {
                throw new ArgumentException();
            }

            //CREATE HANDLE TO VIDEO FILE
            video_capture              = new Capture(file_name);

            WORK_DONE                  = false;
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

            using (current_frame   = FramesManager.GetNextFrame(VideoFromFileThread.video_capture))
            {
                if (current_frame != null)
                {
                    int width      =Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Width;
                    int height     =Singleton.MAIN_WINDOW.GetControl("review_footage_imagebox").Height;
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


        public override bool Pause()
        {
            return base.Pause();
        }

        //JUMPS FORWARD OR BACKWARDS IN THE VIDEO PLAYING
        public bool RewindOrForwardVideo(double millisecond_to_jump_to)
        {
            //SETS THE POINTER TO THE FRAME BEFORE THE SPECIFIED MILLISECOND
            bool sucess = FramesManager.PerformSeekOperationInVideo(millisecond_to_jump_to, video_capture);
            return sucess;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop()
        {
            paused  = true;
            running = false;
            return true;
        }
    }
}
