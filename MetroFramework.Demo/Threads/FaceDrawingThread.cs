using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace MetroFramework.Demo.Threads
{
    public class FaceDrawingThread:AbstractThread
    {
        public Image<Bgr, byte> current_frame;
        public Rectangle[] detected_faces_in_frame;
        private int frame_id;
        private int previous_id;



        public FaceDrawingThread(Image<Bgr, byte> next_frame, Rectangle[] detected_faces, int frame_id, int previous_id)
            : base()
        {
            if (next_frame == null)
            {
                throw new NullReferenceException();
            }

            this.current_frame           = next_frame;
            this.detected_faces_in_frame = detected_faces;
            this.frame_id                = frame_id;
            this.previous_id             = previous_id;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs ex)
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
            catch (Exception)
            {

            }
        }

        private void AddImageToQueueForDisplay()
        {

            try
            {

                
                    Debug.WriteLine("Enqueueing Frame In Face Drawer".ToUpper());
                    Singleton.REVIEW_FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame);
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
                        Bitmap a_frame = FramesManager.DrawShapeOnTransparentBackGround(detected_face, current_frame.Width, current_frame.Height);
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

    }
}
