using Emgu.CV;
using Emgu.CV.CvEnum;
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
        private const double SAVING_INTERVAL = 60 * 60 * 1000;

        private static String FILE_NAME = GetSystemTimeAndDate() + "avi";
        private static String PATH_TO_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ours\";
        private static String PATH_TO_SAVED_FILES = Path.Combine(PATH_TO_FOLDER, FILE_NAME);
        private VideoWriter video_writer = null;
        private Capture video_capture = null;
        private Image<Bgr, byte> frame = null;
        private Timer timer = null;


        public FootageSavingThread(Capture video_capture)
            : base()
        {
            this.video_capture = video_capture;

            //CREATE FOLDER IF IT DOESNT EXIST
            FileManager.CreateFolderIfMissing(PATH_TO_FOLDER);

            ChangeFileName();

            InitilaizeWriter();

            InitilaizeTimer();


        }

        //when the timer interval elapses
        public void TimerElapsed(object obj, ElapsedEventArgs ex)
        {
            //pause this thread
            Pause();

            //change the file name
            ChangeFileName();

            InitilaizeWriter();

            //resume the thread
            Resume();
        }

        //INITILAIZES THE TIMER
        private void InitilaizeTimer()
        {
            timer = new Timer();
            timer.Interval = SAVING_INTERVAL;
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }


        //INITIALIZES THE VIDEO WRITER
        public void InitilaizeWriter()
        {

            video_writer = new VideoWriter(PATH_TO_SAVED_FILES,
                    (int)video_capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FOURCC),
                    (int)5,
                    Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width,
                    Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height,
                    true);
        }

        private void ChangeFileName()
        {
            //change the filename to reflect the time and day
            FILE_NAME = GetSystemTimeAndDate() + ".avi";
            PATH_TO_SAVED_FILES = PATH_TO_FOLDER + FILE_NAME;

        }

        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            //Enalble and start the timer
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

        //GETS THE SYSTEM DATE AND TIME
        private static string GetSystemTimeAndDate()
        {

            return DateTime.Now.ToShortTimeString().Replace(':', '_').Replace(' ', '_') + " " + DateTime.Now.ToShortDateString().Replace('/', '_');
        }


    }
}
