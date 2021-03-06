﻿using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Threads;
using Nkujukira.Demo.Views;
using Nkujukira.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nkujukira.Demo.Singletons
{
    public class Singleton
    {
        //THIS STORES INFORMATION ABOUT THE CURRENTLY LOGGED IN ADMIN
        public static Admin ADMIN { get; set; }

        //USER DOCUMENTS FOLDER
        public static String DOCUMENTS_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //FOLDER WHERE RESOURCES ARE BEING STORED
        public static String NKUJUKIRAZ_DIRECTORY = DOCUMENTS_FOLDER + @"\Nkujukiraz";

        //FOLDER WHERE RESOURCES ARE BEING STORED
        public static String VIDEOS_DIRECTORY = NKUJUKIRAZ_DIRECTORY + @"\Videos\";

        //FOLDER WHERE RESOURCES ARE BEING STORED
        public static String IMAGES_DIRECTORY = NKUJUKIRAZ_DIRECTORY + @"\Images\";

        //REFERENCE TO THE MAIN WINDOW
        public static MainWindow MAIN_WINDOW { get; set; }

        private static List<Perpetrator> active_perpetrators = new List<Perpetrator>();

        public static Perpetrator[] ACTIVE_PERPETRATORS { get { return active_perpetrators.ToArray(); } set { ACTIVE_PERPETRATORS = value; } }


        //A REFERENCE TO THE SELECT PERPETRATOR FORM
        public static SelectPerpetratorFacesForm SELECT_PERP_FACES { get; set; }

        //THE FILENAME OF THE VIDEO CURRENTLY PLAYING IF A VIDEO IS PLAYING
        public static VideoFile CURRENT_VIDEO_FILE { get; set; }
       

        //THIS HOLDS FRAMES AWAITING FACE DETECTION
        private static ConcurrentQueue<Image<Bgr, byte>> live_frames_to_be_processed = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS FRAMES AWAITING FACE DETECTION
        public static ConcurrentQueue<Image<Bgr, byte>> LIVE_FRAMES_TO_BE_PROCESSED
        {
            get
            {
                return Singleton.live_frames_to_be_processed;
            }
            set
            {
                Singleton.live_frames_to_be_processed = value;
            }
        }

        //THIS HOLDS FRAMES AWAITING FACE DETECTION
        private static ConcurrentQueue<Image<Bgr, byte>> review_frames_to_be_processed = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS FRAMES AWAITING FACE DETECTION
        public static ConcurrentQueue<Image<Bgr, byte>> REVIEW_FRAMES_TO_BE_PROCESSED
        {
            get
            {
                return Singleton.review_frames_to_be_processed;
            }
            set
            {
                Singleton.review_frames_to_be_processed = value;
            }
        }

        //THIS HOLDS PERPETRATORS WHO HAVE BEEN IDENTIFIED AS STUDENTS
        private static ConcurrentQueue<FaceRecognitionResult> identified_students = new ConcurrentQueue<FaceRecognitionResult>();

        //THIS HOLDS PERPETRATORS WHO HAVE BEEN IDENTIFIED AS STUDENTS
        public static ConcurrentQueue<FaceRecognitionResult> IDENTIFIED_STUDENTS
        {
            get { return identified_students; }
            set { identified_students = value; }
        }

        //THIS HOLDS PERPETRATORS WHO HAVE BEEN IDENTIFIED 
        private static ConcurrentQueue<FaceRecognitionResult> identified_perpetrators = new ConcurrentQueue<FaceRecognitionResult>();

        //THIS HOLDS PERPETRATORS WHO HAVE BEEN IDENTIFIED 
        public static ConcurrentQueue<FaceRecognitionResult> IDENTIFIED_PERPETRATORS
        {
            get { return identified_perpetrators; }
            set { identified_perpetrators = value; }
        }

        //THIS HOLDS FRAMES WAITING TO BE DISPLAYED
        private static ConcurrentQueue<Image<Bgr, byte>> live_frames_to_be_displayed = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS FRAMES WAITING TO BE DISPLAYED
        public static ConcurrentQueue<Image<Bgr, byte>> LIVE_FRAMES_TO_BE_DISPLAYED
        {
            get
            {

                return Singleton.live_frames_to_be_displayed;
            }
            set
            {
                Singleton.live_frames_to_be_displayed = value;
            }
        }

        //THIS HOLDS FRAMES WAITING TO BE DISPLAYED
        private static ConcurrentQueue<Image<Bgr, byte>> review_frames_to_be_displayed = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS FRAMES WAITING TO BE DISPLAYED
        public static ConcurrentQueue<Image<Bgr, byte>> REVIEW_FRAMES_TO_BE_DISPLAYED
        {
            get
            {

                return Singleton.review_frames_to_be_displayed;
            }
            set
            {
                Singleton.review_frames_to_be_displayed = value;
            }
        }

        //THIS HOLDS IMAGES OF FACES TO BE RECOGNIZED
        public static ConcurrentQueue<Image<Bgr, byte>> faces_to_recognize = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS IMAGES OF FACES TO BE RECOGNIZED
        public static ConcurrentQueue<Image<Bgr, byte>> FACES_TO_RECOGNIZE
        {
            get
            {
                return Singleton.faces_to_recognize;
            }
            set
            {
                Singleton.faces_to_recognize = value;
            }
        }

        //THIS HOLDS IMAGES OF FACES TO BE RECOGNIZED
        public static ConcurrentQueue<FaceRecognitionResult> face_recognition_results = new ConcurrentQueue<FaceRecognitionResult>();

        //THIS HOLDS IMAGES OF FACES TO BE RECOGNIZED
        public static ConcurrentQueue<FaceRecognitionResult> FACE_RECOGNITION_RESULTS
        {
            get
            {
                return Singleton.face_recognition_results;
            }
            set
            {
                Singleton.face_recognition_results = value;
            }
        }

        //THIS HOLDS FRAMES AWAITING STORAGE IN A VIDEO FILE ON THE HDD
        private static ConcurrentQueue<Image<Bgr, byte>> frames_to_be_stored = new ConcurrentQueue<Image<Bgr, byte>>();

        //THIS HOLDS FRAMES AWAITING STORAGE IN A VIDEO FILE ON THE HDD
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_STORED
        {
            get
            {
                return Singleton.frames_to_be_stored;
            }
            set { Singleton.frames_to_be_stored = value; }
        }

        //THIS HOLDS IMAGES OF FACES DETECTED IN FRAMES
        private static ConcurrentDictionary<int, Face> live_detected_faces_datastore = new ConcurrentDictionary<int, Face>();

        //THIS HOLDS IMAGES OF FACES DETECTED IN FRAMES
        public static ConcurrentDictionary<int, Face> LIVE_DETECTED_FACES_DATASTORE
        {
            get
            {
                return Singleton.live_detected_faces_datastore;
            }
            set
            {
                Singleton.live_detected_faces_datastore = value;
            }
        }

        //THIS HOLDS IMAGES OF FACES DETECTED IN FRAMES
        private static ConcurrentDictionary<int, Face> review_detected_faces_datastore = new ConcurrentDictionary<int, Face>();

        public static string HAARCASCADE_FILE_PATH = Application.StartupPath + @"\Resources\Haarcascades\haarcascade_frontalface_default.xml";


        //THIS HOLDS IMAGES OF FACES DETECTED IN FRAMES
        public static ConcurrentDictionary<int, Face> REVIEW_DETECTED_FACES_DATASTORE
        {
            get
            {
                return Singleton.review_detected_faces_datastore;
            }
            set
            {
                Singleton.review_detected_faces_datastore = value;
            }
        }

        //THIS EMPTIES ALL DATASTORES
        public static void ClearLiveStreamDataStores()
        {
            Image<Bgr, byte> color_image;
            FaceRecognitionResult result;
            Perpetrator perp;

            while (Singleton.LIVE_FRAMES_TO_BE_PROCESSED.TryDequeue(out color_image)) ;
            while (Singleton.LIVE_FRAMES_TO_BE_DISPLAYED.TryDequeue(out color_image)) ;
            while (Singleton.FACES_TO_RECOGNIZE.TryDequeue(out color_image)) ;
            while (Singleton.identified_perpetrators.TryDequeue(out result)) ;
            while (Singleton.FACE_RECOGNITION_RESULTS.TryDequeue(out result)) ;
            while (Singleton.FRAMES_TO_BE_STORED.TryDequeue(out color_image)) ;
            Singleton.LIVE_DETECTED_FACES_DATASTORE.Clear() ;

            color_image= null;
            result     = null;
            perp       = null;


        }

        public static void ClearReviewFootageDataStores()
        {
            Image<Bgr, byte> image;
            while (Singleton.REVIEW_FRAMES_TO_BE_PROCESSED.TryDequeue(out image)) ;
            while (Singleton.REVIEW_FRAMES_TO_BE_DISPLAYED.TryDequeue(out image)) ;
            Singleton.REVIEW_DETECTED_FACES_DATASTORE.Clear();
            image = null;

        }

        public static void InitializeStuff()
        {
            Perpetrator[] perps = PerpetratorsManager.GetAllActivePerpetrators();
            foreach (var perp in perps)
            {
                active_perpetrators.Add(perp);
            }
        }

        //THIS UPDATES A PERP FROM THE ACTIVE_PERPETRATORS ARRAY
        public static void Update(Perpetrator perp)
        {
            if (active_perpetrators.Contains(perp))
            {
                int index = active_perpetrators.IndexOf(perp);
                active_perpetrators[index] = perp;
            }
        }

        //THIS DELETES A PERP FROM THE ACTIVE_PERPETRATORS ARRAY
        public static void Delete(Perpetrator perp)
        {
            active_perpetrators.Remove(perp);
            PerpetratorRecognitionThread.enroll_again = true;
        }


    }
}
