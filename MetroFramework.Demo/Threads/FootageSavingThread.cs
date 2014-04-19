using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MetroFramework.Demo.Managers;
using Nkujukira;
using Nkujukira.Threads;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    class FootageSavingThread : ThreadSuperClass
    {
        private const String FILE_NAME = "output.avi";
        private static String PATH_TO_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ours";
        private static String PATH_TO_SAVED_FILES = Path.Combine(PATH_TO_FOLDER, FILE_NAME);
        private VideoWriter video_writer;
        private Image<Bgr, byte> frame;
        public FootageSavingThread(Capture video_capture, ImageBox image_box)
        {
            //CREATE FOLDER IF IT DOESNT EXIST
            StorageManager.CreateFolderIfMissing(PATH_TO_FOLDER);
            //INITIALIZE WRITER
            video_writer = new VideoWriter(PATH_TO_SAVED_FILES,
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC),
                (int)video_capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS),
                image_box.Width,
                image_box.Height,
                true);

        }

        public override void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    //GRAB 1 FRAME
                    //SAVE FRAME ONTO HARD DISK
                    //REPEAT
                    bool sucess = MainWindow.FRAMES_TO_BE_STORED.TryDequeue(out frame);
                    if (sucess)
                    {
                        using (frame)
                        {
                            StorageManager.SaveFrameInAVIFormat(video_writer, frame);
                        }
                       
                    }

                }
            }
        }

        public override bool RequestStop(System.Threading.Thread thread)
        {
            running = false;
            return true;
        }
    }
}
