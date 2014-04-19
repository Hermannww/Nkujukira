using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MetroFramework.Demo;
using MetroFramework.Demo.Threads;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    class FaceDetectingThread : ThreadSuperClass
    {
        private Image<Bgr, byte> current_frame;
        private string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";
        private HaarCascade haarcascade;
        private Rectangle[] detected_faces;
        public static int frame_width;
        public static int frame_height;
        private bool sucessfull;
        public static volatile int previous_id = 0;
        private int counter = 0;


        public FaceDetectingThread(ImageBox image_box)
            : base()
        {
            haarcascade = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            frame_width = image_box.Width;
            frame_height = image_box.Height;
        }

        public override void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    //GET NEXT FRAME
                    //GET DETECTED FACES IN FRAME
                    //FOR EACH FACE DRAW A RECTANGLE AROUND FACE IN PARALLEL
                    sucessfull = MainWindow.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);
                    if (sucessfull)
                    {
                        DetectFacesInFrame();
                        DrawShapeAroundDetectedfaces();
                        AddFrameToQueueForDisplay();
                    }
                }
            }
        }

        private void AddFrameToQueueForDisplay()
        {
            MainWindow.FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame);
        }

        private void DrawShapeAroundDetectedfaces()
        {
            if (detected_faces != null)
            {
                foreach (var detected_face in detected_faces) 
                {
                    FramesManager.DrawShapeAroundDetectedFaces(detected_face, current_frame, out sucessfull);
                }
            }
        }


        private void DetectFacesInFrame()
        {
            detected_faces = FramesManager.DetectFacesInFrame(current_frame, haarcascade);
        }

        public override bool RequestStop()
        {
            running = false;
            return true;
        }

    }
}
