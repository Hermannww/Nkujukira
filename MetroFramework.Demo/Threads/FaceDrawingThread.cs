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
using System.Threading;
using System.Threading.Tasks;

namespace MetroFramework.Demo.Threads
{
    public class FaceDrawingThread : ThreadSuperClass
    {
        public Image<Bgr, byte> current_frame;
        public Rectangle[] detected_faces_in_frame;
        private int frame_width = FaceDetectingThread.frame_width;
        private int frame_height = FaceDetectingThread.frame_height;
        private int frame_id;
        private int previous_id;



        public FaceDrawingThread(Image<Bgr, byte> next_frame, Rectangle[] detected_faces, int frame_id, int previous_id)
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

                
                    Debug.WriteLine("Enqueueing Frame In Face Drawer".ToUpper());
                    MainWindow.FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame);
                    //FaceDetectingThread.previous_id = frame_id;
              

            }
            catch (Exception e)
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
                if (detected_faces_in_frame != null)
                {

                    Bitmap current_frame_bitmap = current_frame.ToBitmap();
                    Graphics graphics = Graphics.FromImage(current_frame_bitmap);

                    Debug.WriteLine("Drawing Frame In Face Drawer".ToUpper());
                    Parallel.ForEach(detected_faces_in_frame,detected_face=>
                    {
                        Debug.WriteLine("Drawing On Transparent Bg".ToUpper());
                        Bitmap a_frame = FramesManager.DrawShapeOnTransparentBackGround(detected_face, frame_width, frame_height);
                        lock (current_frame)
                        {
                            Debug.WriteLine("Overlaying Frame In Face Drawer".ToUpper());
                            FramesManager.OverLayBitmapToFormNewImage(a_frame, graphics);
                        }
                    });
                    current_frame = new Image<Bgr, byte>(current_frame_bitmap);
                }

                else 
                {
                    Debug.WriteLine("Detected Faces is Null".ToUpper());
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public bool RequestStop()
        {
            running = false;
            return true;
        }
    }
}
