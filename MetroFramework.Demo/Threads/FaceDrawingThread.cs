using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Singletons;
using Nkujukira;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace Nkujukira.Demo.Threads
{
    public class FaceDrawingThread : AbstractThread
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

            this.current_frame = next_frame;
            this.detected_faces_in_frame = detected_faces;
            this.frame_id = frame_id;
            this.previous_id = previous_id;
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

        public bool AddImageToQueueForDisplay()
        {

            try
            {
                Singleton.REVIEW_FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool DrawFaceRectangles()
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

                    Parallel.ForEach(detected_faces_in_frame, detected_face =>
                    {
                        Bitmap a_frame = FramesManager.DrawShapeOnTransparentBackGround(detected_face, current_frame.Width, current_frame.Height);
                        lock (current_frame)
                        {
                            FramesManager.OverLayBitmapToFormNewImage(a_frame, graphics);
                        }
                    });

                    current_frame = new Image<Bgr, byte>(current_frame_bitmap);
                    return true;
                }



            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                
            }
            return false;
        }

    }
}
