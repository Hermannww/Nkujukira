using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Accord.Vision.Tracking;
using AForge.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;


namespace Nkujukira.Entities
{
    public class Face
    {
        public static List<int> face_ids_for_recycling = new List<int>();
        public static int counter = 0;

        public string name { get; set; }
        public Rectangle face_rectangle;
        public Camshift face_tracker { get; set; }

        public int face_id;
        private float xscale;
        private float yscale;

        // CONSTRUCTOR 
        // NAME-NAME OF PERSON IN IMAGE
        // RECTANGLE RECTANGLE WITH PERSONS FACE
        // IMAGE FRAME CONAINING FACE OF PERSON
        public Face(string name, Rectangle face_rect, Image<Bgr, byte> image)
        {
            if (name == null || face_rect == null || image == null)
            {
                throw new NullReferenceException();
            }
            this.name = name;
            this.face_rectangle = face_rect;
            bool success;
            xscale = face_rect.Width / 160f;
            yscale = face_rect.Height / 120f;
            InitializeTracker(image, out success);
            face_id = GenerateFaceId();
        }


        public int GenerateFaceId()
        {
            if (face_ids_for_recycling.Count > 0)
            {
                foreach (var recycled_id in face_ids_for_recycling)
                {
                    if (face_ids_for_recycling.Remove(recycled_id) == true)
                    {
                        return recycled_id;
                    }
                }
            }
            return counter++;
        }

        public int GetId()
        {
            return face_id;
        }

        public void SetFaceRectangle()
        {
            //face_tracker.AspectRatio = 30;
            //face_tracker.
        }


        //INITIALIZES TRACKER TO TRACK A SPECIFIC OBJECT
        public void InitializeTracker(Image<Bgr, byte> image, out bool success)
        {
            try
            {
                Bitmap bitmap = image.ToBitmap();
                UnmanagedImage unmanaged_image = UnmanagedImage.FromManagedImage(bitmap);
                face_tracker = new Camshift();
                face_tracker.Reset();
                face_tracker.Mode = CamshiftMode.Mixed;
                face_tracker.Conservative = true;
                face_tracker.AspectRatio = 1f;
                face_tracker.Smooth = true;
                // Reduce the face size to avoid tracking background
                Rectangle window = new Rectangle(
                    (int)((face_rectangle.X + face_rectangle.Width / 2f) * xscale),
                    (int)((face_rectangle.Y + face_rectangle.Height / 2f) * yscale),
                    1, 1);

                window.Inflate(
                    (int)(0.2f * face_rectangle.Width * xscale),
                    (int)(0.4f * face_rectangle.Height * yscale));
                //face_tracker.Mode=face_tracker.
                face_tracker.SearchWindow = face_rectangle;
                face_tracker.ProcessFrame(unmanaged_image);
                success = true;
            }
            catch (Exception e)
            {

                success = false;
            }
        }

        public Rectangle GetRectangle()
        {
            return face_rectangle;
        }

        //LOOKS FOR THE POSITION OF THE OBJECT ITS TRACKING IN THE CURRENT FRAME
        public Rectangle GetCurrentPositionOfFace(Image<Bgr, byte> current_frame, out bool sucess)
        {
            try
            {
                Bitmap bitmap = current_frame.ToBitmap();
                UnmanagedImage unmanaged_image = UnmanagedImage.FromManagedImage(bitmap);
                // Track the object
                face_tracker.ProcessFrame(unmanaged_image);

                // Get the object position
                var face_position = face_tracker.TrackingObject;
                face_rectangle = face_position.Rectangle;
                sucess = true;
                return face_rectangle;
            }
            catch (Exception e)
            {
                sucess = false;
                return Rectangle.Empty;
            }
        }

        //RETURNS NAME ASSOCIATED WITH FACE
        public string GetName()
        {
            return name;
        }
    }
}
