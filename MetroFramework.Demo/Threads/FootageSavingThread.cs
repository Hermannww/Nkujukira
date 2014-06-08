using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using System;
using System.IO;

namespace MetroFramework.Demo.Threads
{
    class FootageSavingThread : AbstractThread
    {
        private const String FILE_NAME            = "output.avi";
        private static String PATH_TO_FOLDER      = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ours";
        private static String PATH_TO_SAVED_FILES = Path.Combine(PATH_TO_FOLDER, FILE_NAME);
        private VideoWriter video_writer          = null;
        private Image<Bgr, byte> frame            = null;

        public FootageSavingThread(Capture video_capture)
        {
            //CREATE FOLDER IF IT DOESNT EXIST
            FileManager.CreateFolderIfMissing(PATH_TO_FOLDER);

            //INITIALIZE WRITER
            video_writer  = new VideoWriter(PATH_TO_SAVED_FILES,
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC),
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS),
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Width,
                Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Height,
                true);

        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (running)
            {
                if (!paused)
                {
                    //GRAB 1 FRAME
                    //SAVE FRAME ONTO HARD DISK
                    //REPEAT
                    bool sucess = Singleton.FRAMES_TO_BE_STORED.TryDequeue(out frame);
                    if (sucess)
                    {
                        using (frame)
                        {
                            FileManager.SaveFrameInAVIFormat(video_writer, frame);
                        }
                       
                    }

                }
            }
        }

    }
}
