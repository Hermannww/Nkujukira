using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using System;
using System.ComponentModel;
using System.IO;
using System.Timers;

namespace MetroFramework.Demo.Threads
{
    class FootageSavingThread : AbstractThread
    {
        private const double SAVING_INTERVAL       = 60 * 60 * 1000;

        private static String FILE_NAME            = GetCurrentTimeAndDate()+"avi";
        private static String PATH_TO_FOLDER       = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ours\";
        private static String PATH_TO_SAVED_FILES  = Path.Combine(PATH_TO_FOLDER, FILE_NAME);
        private VideoWriter video_writer           = null;
        private Capture video_capture              = null;
        private Image<Bgr, byte> frame             = null;
        private Timer timer                        = null;
        

        public FootageSavingThread(Capture video_capture):base()
        {
            //CREATE FOLDER IF IT DOESNT EXIST
            FileManager.CreateFolderIfMissing(PATH_TO_FOLDER);

            //INITIALIZE WRITER
            video_writer       = new VideoWriter(PATH_TO_SAVED_FILES,
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC),
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS),
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Width,
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Height,
                true);

            this.video_capture = video_capture;

            //set timer to fire once every hour
            timer              = new Timer(SAVING_INTERVAL);

            //handle the time elapsed event
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);

        }

        //when the timer interval elapses
        public void TimerElapsed(object obj, ElapsedEventArgs ex) 
        {
            //pause this thread
            Pause();

            //change the file name
            ChangeFileName();

            //resume the thread
            Resume();
        }

        private void ChangeFileName()
        {
            //change the filename to reflect the time and day
            FILE_NAME           = GetCurrentTimeAndDate() + "avi";
            PATH_TO_SAVED_FILES = Path.Combine(PATH_TO_FOLDER, FILE_NAME);

            //re initialize the writer
            video_writer        = new VideoWriter(PATH_TO_SAVED_FILES,
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC),
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS),
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Width,
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Height,
                true);
        }

        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            //Enalble and start the timer
            timer.Enabled = true;
            timer.Start();

            while (running)
            {
                if (!paused)
                {
                    //GRAB 1 FRAME
                    bool sucess = Singleton.FRAMES_TO_BE_STORED.TryDequeue(out frame);
                    if (sucess)
                    {
                        using (frame)
                        {
                            //SAVE FRAME ONTO HARD DISK 
                            FileManager.SaveFrameInAVIFormat(video_writer, frame);
                        }
                        //REPEAT
                    }

                }
            }
        }

        public static String GetCurrentTimeAndDate() 
        {
            //get the current system time and date
            return DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
        }

    }
}
