using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Singletons;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;

namespace Nkujukira.Demo.Threads
{
    class FootageSavingThread : AbstractThread
    {
        //INTERVAL INDICATING HOW OFTEN WE CHANGE FILES : EVERY 1 HOUR (60 min * 60 sec * 1000msc)
        private const double SAVING_INTERVAL_MILLISECS = 60 * 60 * 1000;

        //THE NAME OF THE VIDEO FILE WE SAVE TO
        private static String FILE_NAME                = GetSystemTimeAndDate() + "avi";
        
        //PATH TO THE FOLDER WE SAVE TO
        private static String PATH_TO_FOLDER           = Singleton.VIDEOS_DIRECTORY;
       
        //PATH TO FILES WE SAVE TO
        private static String PATH_TO_SAVED_FILES      = Path.Combine(PATH_TO_FOLDER, FILE_NAME);
        
        //WRITER TO WRITE TO FILE
        private VideoWriter video_writer               = null;
        private Capture camera_capture                 = null;
        
        //THE FRAME WE ARE CURRENTLY WRITING TO FILE
        private Image<Bgr, byte> frame_to_be_saved     = null;
        
        //TIMER TO INDICATE WHEN SAVING INTERVAL HAS ELAPSED
        private System.Timers.Timer timer              = null;

        //SIGNAL TO OTHER THREADS THAT THIS THREAD IS DONE
        public static bool WORKDONE                    = false;


        //CONSTRUCTOR
        public FootageSavingThread(Capture video_capture)
            : base()
        {
            //GET HANDLE TO VIDEO CAPTURE
            this.camera_capture = video_capture;

            //CREATE FOLDER IF IT DOESNT EXIST
            FileManager.CreateFolderIfMissing(PATH_TO_FOLDER);

            //CHANGE THE FILE NAME OF THE FILE WE WRITE TO
            ChangeFileName();

            //INITIALIZE THE VIDEO WRITER
            InitilaizeWriter();

            //INITIALIZE TIMER THAT EXPIRES ONCE EVERY HOUR
            InitilaizeTimer();


        }

        //WHEN THE TIMER INTERVAL ELAPSES
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
            timer          = new System.Timers.Timer();
            timer.Interval = SAVING_INTERVAL_MILLISECS;
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }


        //INITIALIZES THE VIDEO WRITER
        public void InitilaizeWriter()
        {

            video_writer = new VideoWriter(
                                            PATH_TO_SAVED_FILES,
                                            (int)camera_capture.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FOURCC),
                                            (int)5,
                                            Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Width,
                                            Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox").Height,
                                            true
                                          );
        }

        //CHANGE THE FILENAME TO REFLECT THE TIME AND DAY
        private void ChangeFileName()
        {          
            FILE_NAME           = GetSystemTimeAndDate() + ".avi";
            PATH_TO_SAVED_FILES = PATH_TO_FOLDER + FILE_NAME;

        }

        //DOES VIDEO SAVING WORK IN THE BACKGROUND
        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            //ENABLE AND START THE TIMER
            timer.Start();
            Debug.WriteLine("Footage Saving Thread Running");
            while (running)
            {
                if (!paused)
                {
                    
                    //GRAB 1 FRAME
                    bool sucess = Singleton.FRAMES_TO_BE_STORED.TryDequeue(out frame_to_be_saved);
                    if (sucess)
                    { 
                        //SAVE FRAME ONTO HARD DISK 
                        FileManager.SaveFrameInAVIFormat(video_writer, frame_to_be_saved);
                        frame_to_be_saved = null;
                    }

                    //IF NO SUCESS THEN CHECK OTHER THREADS
                    else 
                    {
                        //IF THE CAMERA OUTPUT THREAD HAS TERMINATED THEN ALSO TERMINATE THIS
                        if (CameraOutputGrabberThread.WORK_DONE) 
                        {
                            running = false;
                            WORKDONE = true;
                            Debug.WriteLine("Terminating footage saver");
                        }
                    }

                    Thread.Sleep(SLEEP_TIME);
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
