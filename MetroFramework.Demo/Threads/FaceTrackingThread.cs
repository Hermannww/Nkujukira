using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using Nkujukira.Entities;
using System.Threading.Tasks;
using MetroFramework.Demo.Singletons;
using Nkujukira;

namespace MetroFramework.Demo.Threads
{
    class FaceTrackingThread : AbstractThread
    {
        private Image<Bgr, byte> current_frame;
        //REMEMBER TO CHANGE THESE DEPENDING ON THE COMPUTER
        private const String HAARCASCADE_PROFILE_FACE_FILE_PATH = "C:\\Emgu\\emgucv-windows-x86 2.2.1.1150\\opencv\\data\\haarcascades\\haarcascade_profileface.xml";
        private const String HAARCASCADE_FRONTAL_FACE_FILE_PATH = @"C:\downloads\libemgucv-windows-x64-2.2.1.1150\libemgucv-windows-x64-2.2.1.1150\opencv\data\haarcascades\haarcascade_frontalface_default.xml";

        private HaarCascade frontal_face_haarcascade;
        bool sucessfull;


        public FaceTrackingThread()
            : base()
        {
            frontal_face_haarcascade = new HaarCascade(HAARCASCADE_FRONTAL_FACE_FILE_PATH);
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs ex)
        {
            while (running)
            {
                try
                {
                    if (!paused)
                    {
                        sucessfull = Singleton.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);
                        if (sucessfull)
                        {
                            DetectFacesInFrame();
                            current_frame = null;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + "In FACE DETECTOR");
                }
            }

        }


        //DETECT THE FACES IN THE FRAME INORDER TO ADD THEM TO A BAL FACE DATASTORE
        private void DetectFacesInFrame()
        {

            Debug.WriteLine("Detecting Faces");
            Rectangle[] detected_faces = FramesManager.DetectFacesInFrame(current_frame, frontal_face_haarcascade);
            if (detected_faces != null)
            {
                if (detected_faces.Length != 0)
                {
                    //CHANGE THE DICTIONARY INTO AN ARRAY
                    KeyValuePair<int, Face>[] hashmap = Singleton.DETECTED_FACES_DATASTORE.ToArray();
                    int k = 0;
                    Face[] faces_array = new Face[hashmap.Length];
                    foreach (var key_value_pair in hashmap)
                    {
                        faces_array[k] = key_value_pair.Value;
                        k++;
                    }

                    bool sucess;
                    //FOR EACH FACE DETECTED WE WILL ONLY ADD IT TO THE DATASTORE IF ITS NOT 
                    //AMONG THE FACES ALREADY BEING TRACKED
                    Parallel.For(0, detected_faces.Length, i =>
                    {
                        bool face_is_found = false;

                        for (int j = 0; j < faces_array.Length; j++)
                        {
                            if (faces_array[j].GetCurrentPositionOfFace(current_frame, out sucess).IntersectsWith(detected_faces[i]))
                            {
                                //UPDATE POSITION OF THAT FACE PLUS TRACKER
                                //faces_array[j].UpdateFaceAndTracker(current_frame, detected_faces[i]);
                                Debug.WriteLine("OLD FACE FOUND");
                                face_is_found = true;
                                break;
                            }
                        }

                        if (!face_is_found)
                        {
                            Debug.WriteLine("NEW FACE FOUND");
                            Face a_face = new Face("No Name", detected_faces[i], current_frame);
                            Singleton.DETECTED_FACES_DATASTORE.TryAdd(a_face.GetId(), a_face);
                        }

                    });
                }
            }
            else
            {
                Debug.Write("No face found");
            }
        }

    }
}
