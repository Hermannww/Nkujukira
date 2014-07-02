using Emgu.CV;
using Emgu.CV.Structure;
using Manina.Windows.Forms;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class FaceDetectingThread : AbstractThread
    {
        public static string FRONTAL_FACE_HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";
        
        public static bool WORK_DONE;
        public static bool draw_detected_faces;

        public static volatile int previous_id ;
        public static volatile bool its_time_to_pick_perpetrator_faces=false;
        
        private Image<Bgr, byte> current_frame;
        private HaarCascade haarcascade;
        public Rectangle[] detected_faces;
        private int frame_width;
        private int frame_height;
        private bool sucessfull;
        private Point location;

        private int counter ;

      
        public FaceDetectingThread(int frame_width, int frame_height)
            : base()
        {
            haarcascade                        = new HaarCascade(FRONTAL_FACE_HAARCASCADE_FILE_PATH);
            its_time_to_pick_perpetrator_faces = false;
            this.frame_width                   = frame_width;
            this.frame_height                  = frame_height;
            WORK_DONE                          = false;
            draw_detected_faces                = false;
            counter                            = 0;
            previous_id                        = 0;
            location                           = new Point(2, 2);
           

        }


        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            Debug.WriteLine("Face Detecting Thread Running");
            while (running)
            {
                if (!paused)
                {
                    //GET NEXT FRAME
                    //GET DETECTED FACES IN FRAME
                    
                    DetectFacesInFrame();

                    //IF OPTION IS ENABLED ADD DETECTED FACES TO PANEL
                    AddDetectedFacesToListViewPanel();

                    //FOR EACH FACE DRAW A RECTANGLE AROUND FACE IN PARALLEL
                    DrawShapeAroundDetectedfaces();

                    //ADD FRAME TO THE QUEUE FOR DISPLAY
                    AddFrameToQueueForDisplay();
                 }
                Thread.Sleep(SLEEP_TIME);
            }
        }
        int count = 0;
        private void AddDetectedFacesToListViewPanel()
        {
            try
            {
                if (its_time_to_pick_perpetrator_faces)
                {
                    if (detected_faces != null && current_frame != null)
                    {
                        ImageListView image_list_view = Singleton.SELECT_PERP_FACES.GetImageListView();

                        


                        for (int i = 0; i < detected_faces.Length; i++)
                        {
                            //get face
                            Image<Gray, byte> face = FramesManager.CropSelectedFace(detected_faces[i], current_frame.Clone());

                            //resize face
                            face = FramesManager.ResizeGrayImage(face, new Size(120, 120));

                            //add face to image list
                            Singleton.SELECT_PERP_FACES.suspect_faces.TryAdd(count, face);

                            //add face to image list view
                            image_list_view.Invoke(new AddImage(Singleton.SELECT_PERP_FACES.AddImage), new object[] { "face " + count, "face " + count, face.ToBitmap() });

                            //increment id counter
                            count++;

                        }
                        
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public delegate void AddImage(Object key,String txt,Image thumbnail);

        

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

        //ADDS A FRAME TO THE DATASTORE MEANT FOR FRAMES TO BE DISPLAYED
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


        //DRAWS A SHAPE AROUND THE FACE IF THE OPTION IS SELECTED
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
                            counter     = 0;
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

        //DETECTS FACES IN THE CURRENT FRAME
        public void DetectFacesInFrame()
        {
            //try to get a frame from the shared datastore for captured frames
            sucessfull = Singleton.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);
            
            
            //if ok
            if (sucessfull)
            {
                //detect faces in frame
                detected_faces = FramesManager.DetectFacesInFrame(current_frame.Clone(), haarcascade);

            }
            //IF NO FRAMES IN DATA STORE
            else
            {
                //IF OUTPUT GRABBER THREAD IS DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if (VideoFromFileThread.WORK_DONE)
                {
                    WORK_DONE = true;
                    running = false;     
                }
            }
        }


        
    }
}
