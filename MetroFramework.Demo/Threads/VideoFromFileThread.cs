using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using MetroFramework.Demo;
using MediaInfoNET;
using MetroFramework.Demo.Threads;


//THIS THREAD CONTINUOUSLY PICKS FRAMES FROM A GIVEN VIDEO FILE AND DUMPS THEM IN
//SHARED DATASTORES FOR PROCESSING BY OTHER THREADS
namespace Nkujukira.Threads
{
    public class VideoFromFileThread : ThreadSuperClass
    {
        private const string PROCESSING_THREAD_NAME = "VIDEO_FROM_FILE_THREAD";
        private Capture video_capture;
        public Image<Bgr, byte> current_frame;
        private ImageBox image_box;
        public static bool WORK_DONE;
        public static double VIDEO_LENGTH;
        public static string VIDEO_LENGTH_STRING;
        private FootageSavingThread footage_saver;
        private Thread footage_saving_thread;
        private int SLEEP_TIME=30;




        public VideoFromFileThread(String file_name, ImageBox image_box)
            : base()
        {
            if (file_name == null || image_box == null)
            {
                throw new NullReferenceException();
            }

            video_capture = new Capture(file_name);
            MediaFile video_properties = new MediaFile(file_name);

            //VIDEO LENGTH IN SECONDS
            VIDEO_LENGTH = video_properties.General.DurationMillis;
            VIDEO_LENGTH_STRING = video_properties.General.DurationString;
            WORK_DONE = false;
            this.image_box = image_box;
            //StartFootageStorageThread();
        }

        private void StartFootageStorageThread()
        {
            footage_saver = new FootageSavingThread(video_capture, image_box);
            footage_saving_thread = new Thread(footage_saver.DoWork);
            footage_saving_thread.Name = "Camera Thread";
            footage_saving_thread.Priority = ThreadPriority.Highest;
            footage_saving_thread.IsBackground = true;
            footage_saving_thread.Start();
            Debug.WriteLine("Starting camera output thread");
            while (!footage_saving_thread.IsAlive) ;
            Debug.WriteLine("Camera Output Thread is alive");
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

            using (current_frame = FramesManager.GetNextFrame(this.video_capture))
            {
                if (current_frame != null)
                {
                    if (running)
                    {
                        MainWindow.FRAMES_TO_BE_PROCESSED.Enqueue(FramesManager.ResizeImage(current_frame, image_box));
                        //MainWindow.FRAMES_TO_BE_STORED.Enqueue(current_frame.Clone());
                        return true;
                    }
                }
                //FRAME IS NULL 
                //MEANING END OF FILE IS REACHED
                else
                {
                    //ADD BLACK FRAME TO DATASTORE AND TERMINATE THREAD
                    //ALSO SIGNAL TO OTHERS THAT THIS THREAD IS DONE
                    AddBlackFrame();
                    WORK_DONE = true;
                    running = false;
                    Debug.WriteLine("Terminating video from file");
                }
                return false;
            }

        }

        public override void Pause()
        {
            if (footage_saver != null) 
            {
                footage_saver.Pause();
            }
            base.Pause();
        }

        //ADDS BLACK FRAME TO FRAMES DATASTORE
        private void AddBlackFrame()
        {
            int width = image_box.Width;
            int height = image_box.Height;
            Image<Bgr, byte> black_image = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0));
            MainWindow.FRAMES_TO_BE_PROCESSED.Enqueue(black_image);
        }

        public void RewindOrForwardVideo(double millisecond_to_jump_to)
        {
            bool sucess = FramesManager.PerformSeekOperationInVideo(millisecond_to_jump_to, video_capture);
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop(Thread thread)
        {
            running = false;
            if (footage_saver!=null)
            {
                footage_saver.RequestStop(footage_saving_thread);  
            }
            
            return true;
        }
    }
}
