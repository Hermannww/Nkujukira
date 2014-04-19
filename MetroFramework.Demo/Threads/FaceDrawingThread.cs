using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira;
using Nkujukira.Threads;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroFramework.Demo.Threads
{
    class FaceDrawingThread : ThreadSuperClass
    {
        private Image<Bgr, byte> current_frame;
        private Rectangle[] detected_faces_in_frame;
        private  int frame_width=FaceDetectingThread.frame_width;
        private  int frame_height=FaceDetectingThread.frame_height;
        private int frame_id;
        private int previous_id;



        public FaceDrawingThread(Image<Bgr, byte> next_frame, Rectangle[] detected_faces, int frame_id,int previous_id)
            : base()
        {
            if (next_frame == null)
            {
                throw new NullReferenceException();
            }

            this.current_frame = next_frame;
            this.detected_faces_in_frame = detected_faces;
            this.frame_id = frame_id;
            this.previous_id = previous_id;
        }

        public void DoWork(Object thread_context)
        {
            try
            {
                //GET CURRENT FRAME
                //GET DETECTED FACES IN FRAME
                //FOR EACH FACE CREATE THREAD TO DRAW FACE RECT OVER TRANSPARENT RECT
                //OVERLAY ALL SUBSEQUENT IMAGES ON ORIGINAL IMAGE
                //ADD TO QUEUE FOR DISPLAY

                DrawFaceRectangles();
                AddImageToQueueForDisplay();

            }
            catch (Exception e)
            {

            }
        }

        private void AddImageToQueueForDisplay()
        {

            try
            {
                if (frame_id == (previous_id + 1))
                {
                    MainWindow.FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame);
                    FaceDetectingThread.previous_id = frame_id;
                }
                else
                {
                    AddImageToQueueForDisplay();
                }
            }
            catch (StackOverflowException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
        }

        private void DrawFaceRectangles()
        {
            if (current_frame == null) 
            {
                throw new NullReferenceException();
            }

            try
            {
               
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }

        }

        public override bool RequestStop()
        {
            current_frame = null;
            detected_faces_in_frame = null;
            return true;
        }
    }
}
