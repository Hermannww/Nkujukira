using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MetroFramework.Demo;
using MetroFramework.Demo.Threads;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    public class FaceDetectingThread : ThreadSuperClass
    {
        public Image<Bgr, byte> current_frame;
        public static string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";
        private HaarCascade haarcascade;
        public Rectangle[] detected_faces;
        public static int frame_width;
        public static int frame_height;
        private bool sucessfull;
        public static volatile int previous_id = 0;
        private int counter = 0;
        public static bool WORK_DONE;
        public static bool draw_detected_faces = false;
        private Panel detected_faces_panel;
        private Point location;

        public FaceDetectingThread(ImageBox image_box, Panel a_panel)
            : base()
        {
            haarcascade = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            frame_width = image_box.Width;
            frame_height = image_box.Height;
            this.detected_faces_panel = a_panel;
            WORK_DONE = false;
            location = new Point(2, 2);
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
                        using (current_frame)
                        {
                            Image<Bgr, byte> clone = current_frame.Clone();
                            Debug.WriteLine("Detecting Faces");
                            DetectFacesInFrame(clone);
                            AddDetectedFacesToListViewPanel(clone);
                            if (draw_detected_faces)
                            {
                                Debug.WriteLine("Drawing faces");
                                DrawShapeAroundDetectedfaces(clone);
                            }
                            else
                            {
                                Debug.WriteLine("Enqueing Faces");
                                AddFrameToQueueForDisplay(clone);
                            }
                            clone = null;
                        }
                    }
                    //IF NO FRAMES IN DATA STORE
                    else
                    {
                        //IF OUTPUT GRABBER THREAD IS DONE THEN IT MEANS THE FRAMES ARE DONE
                        //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                        if (VideoFromFileThread.WORK_DONE)
                        {
                            WORK_DONE = true;
                            Debug.WriteLine("Terminating face detector");
                            break;
                        }
                    }
                }
            }
        }
        volatile int x = 2;
        volatile int y = 2;

        private void AddDetectedFacesToListViewPanel(Image<Bgr, byte> frame)
        {
            try
            {
                if (detected_faces != null)
                {
                    if (this.detected_faces_panel.InvokeRequired)
                    {
                        this.detected_faces_panel.Invoke((MethodInvoker)delegate
                        {
                            detected_faces_panel.Controls.Clear();
                        });
                    }
                    x = 2;
                    y = 2;
                    Parallel.ForEach(detected_faces, detected_face =>
                     {
                         Bitmap face = FramesManager.CropSelectedFace(detected_face, frame);
                         PictureBox a_picture_box = new PictureBox();
                         a_picture_box.Width = face.Width;
                         a_picture_box.Height = face.Height;
                         a_picture_box.Image = face;
                         //a_picture_box.Location = new Point(x, y);
                         if (this.detected_faces_panel.InvokeRequired)
                         {
                             this.detected_faces_panel.Invoke((MethodInvoker)delegate
                             {
                                 detected_faces_panel.Controls.Add(a_picture_box);
                             });

                         }
                     });
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public void AddFrameToQueueForDisplay(Image<Bgr, byte> clone)
        {
            MainWindow.FRAMES_TO_BE_DISPLAYED.Enqueue(clone);
        }

        public bool DrawShapeAroundDetectedfaces(Image<Bgr, byte> clone)
        {
            try
            {
                counter++;
                FaceDrawingThread face_drawer = new FaceDrawingThread(clone, detected_faces, counter, previous_id);
                ThreadPool.QueueUserWorkItem(face_drawer.DoWork);

                if (counter == 250)
                {
                    counter = 0;
                    previous_id = 0;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void DetectFacesInFrame(Image<Bgr, byte> clone)
        {
            detected_faces = FramesManager.DetectFacesInFrame(clone.Clone(), haarcascade);

        }

        public override bool RequestStop(Thread thread)
        {
            running = false;
            //thread.Join();
            return true;
        }

    }
}
