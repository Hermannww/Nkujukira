using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows;
using System.Diagnostics;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using System.Drawing;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Nkujukira.Entities;

namespace Nkujukira
{
    class FramesManager
    {
        const byte RED = 0;
        const byte GREEN = 1;
        const byte BLUE = 0;
        public static Color COLOR_OF_FACE_RECTANGLE = Color.Green;
        const int THICKNESS = 1;

        const double SCALE = 3.0;
        const double SCALEFACTOR = 1.4;
        const int MINIMUM_NEIGBHOURS = 3;
        const int WINDOW_SIZE = 50;


        public static Image<Bgr, byte> GetNextFrame(Capture capture, ImageBox image_box)
        {
            if (capture == null || image_box == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                return capture.QueryFrame().Resize(image_box.Width, image_box.Height, INTER.CV_INTER_LINEAR);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        public static bool PerformSeekOperationInVideo(double ratio,Capture capture)
        {
            try
            {
                capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_AVI_RATIO, ratio);
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
           
        }

        public static Rectangle[] DetectFacesInFrame(Image<Bgr, byte> current_frame, Emgu.CV.HaarCascade haarcascade)
        {
            if (current_frame == null || haarcascade == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                if (current_frame != null)
                {
                    using (current_frame)
                    {
                        using (Image<Gray, byte> grayscale_image = current_frame.Convert<Gray, byte>())
                        {
                            grayscale_image._EqualizeHist();

                            MCvAvgComp[] detected_faces = grayscale_image.DetectHaarCascade(haarcascade, SCALEFACTOR, MINIMUM_NEIGBHOURS, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(WINDOW_SIZE, WINDOW_SIZE))[0];
                            Debug.WriteLine("NUMBER OF FACES FOUND=" + detected_faces.Length);
                            if (detected_faces.Length != 0)
                            {
                                Rectangle[] face_rectangles = new Rectangle[detected_faces.Length];

                                Parallel.For(0, face_rectangles.Length, i =>
                                {
                                    face_rectangles[i] = detected_faces[i].rect;
                                });
                                detected_faces = null;
                                return face_rectangles;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public static Image<Bgr, byte> DrawShapeAroundDetectedFaces(Rectangle rectangle_of_detected_face, Image<Bgr, byte> current_frame, out bool sucess)
        {
            if (current_frame == null)
            {
                sucess = false;
                throw new NullReferenceException();
            }
            current_frame.Draw(rectangle_of_detected_face, new Bgr(COLOR_OF_FACE_RECTANGLE), THICKNESS);

            sucess = true;
            return current_frame;
        }


        public static Bitmap DrawShapeOnTransparentBackGround(Rectangle a_rectangle, int frame_width, int frame_height)
        {
       
           
            Bitmap bitmap = new Bitmap(frame_width, frame_height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.DrawRectangle(Pens.Green, a_rectangle);
            graphics.Flush();
            
            return bitmap;
        }


        public static bool OverLayBitmapToFormNewImage(Bitmap to_be_overlaid, Graphics graphics)
        {
            try
            {
                using (to_be_overlaid)
                {
                    
                    graphics.DrawImageUnscaled(to_be_overlaid, new Point(0, 0));
                    graphics.Flush();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
