using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Singletons;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Nkujukira.Threads
{
    public class FaceDetectingThread : AbstractThread
    {
        public Image<Bgr, byte> current_frame;
        public static string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";
        private HaarCascade haarcascade;
        public Rectangle[] detected_faces;
        public int frame_width;
        public int frame_height;
        private bool sucessfull;
        public static volatile int previous_id = 0;
        private int counter                    = 0;
        public static bool WORK_DONE           = false;
        public static bool draw_detected_faces = false;
        private Point location;
        

        public FaceDetectingThread(int frame_width, int frame_height)
            : base()
        {
            haarcascade       = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            this.frame_width  = frame_width;
            this.frame_height = frame_height;
            location          = new Point(2, 2);

        }


        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            while (running)
            {
                if (!paused)
                {
                    //GET NEXT FRAME
                    //GET DETECTED FACES IN FRAME
                    //FOR EACH FACE DRAW A RECTANGLE AROUND FACE IN PARALLEL
                    DetectFacesInFrame();
                    AddDetectedFacesToListViewPanel();
                    DrawShapeAroundDetectedfaces();
                    AddFrameToQueueForDisplay();
                    


                }
            }
        }

        private void AddDetectedFacesToListViewPanel()
        {
            try
            {
                if (detected_faces!=null&&current_frame!=null)
                {
                    

                    foreach (var detected_face in detected_faces)
                    {
                        Bitmap face = FramesManager.CropSelectedFace(detected_face, current_frame.Clone());
                        PictureBox a_picture_box = new PictureBox();
                        a_picture_box.Width = face.Width;
                        a_picture_box.Height = face.Height;
                        a_picture_box.Image = face;

                        if (Singleton.MAIN_WINDOW.GetDetectedFacesPanel().InvokeRequired)
                        {
                            Singleton.MAIN_WINDOW.GetDetectedFacesPanel().Invoke((MethodInvoker)delegate
                            {
                                Singleton.MAIN_WINDOW.GetDetectedFacesPanel().Controls.Clear();
                                Singleton.MAIN_WINDOW.GetDetectedFacesPanel().Controls.Add(a_picture_box);
                            });
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        //CAN UPDATE UI THREAD
        public override void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AddDetectedFacesToListViewPanel();
        }


        //FIRED WHEN THREAD IS TERMINATING
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            WORK_DONE = true;
        }


        public void AddFrameToQueueForDisplay()
        {
            if (sucessfull)
            {
                if (!draw_detected_faces)
                {
                    Singleton.FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame.Clone());
                }
            }
        }



        public bool DrawShapeAroundDetectedfaces()
        {
            try
            {
                if (sucessfull)
                {
                    if (draw_detected_faces)
                    {
                        counter++;
                        FaceDrawingThread face_drawer = new FaceDrawingThread(current_frame.Clone(), detected_faces, counter, previous_id);
                        face_drawer.StartWorking();

                        if (counter == 250)
                        {
                            counter = 0;
                            previous_id = 0;
                        }
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }


        public void DetectFacesInFrame()
        {
            sucessfull = Singleton.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);
            if (sucessfull)
            {
                detected_faces = FramesManager.DetectFacesInFrame(current_frame.Clone(), haarcascade);

            }
            //IF NO FRAMES IN DATA STORE
            else
            {
                //IF OUTPUT GRABBER THREAD IS DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if (VideoFromFileThread.WORK_DONE)
                {   
                    running = false;     
                }
            }
        }



    }
}
