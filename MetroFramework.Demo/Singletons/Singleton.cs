using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Threads;
using MetroFramework.Demo.Views;
using Nkujukira.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetroFramework.Demo.Singletons
{
    class Singleton
    {
        public static Admin ADMIN { get; set; }

        public static String START_UP_FOLDER                                    = Application.StartupPath;

        public static String RESOURCES_DIRECTORY                                = START_UP_FOLDER + @"\Resources\";


        public static MainWindow MAIN_WINDOW { get; set; }

        public static SelectPerpetratorFacesForm SELECT_PERP_FACES { get; set; }

        private static String current_file_name                                 = "";

        public static String CURRENT_FILE_NAME
        {
            get
            {
                return Singleton.current_file_name;
            }
            set
            {
                Singleton.current_file_name                                     = value;
            }
        }

        private static ConcurrentQueue<Image<Bgr, byte>> frames_to_be_processed = new ConcurrentQueue<Image<Bgr, byte>>();

        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_PROCESSED
        {
            get
            {
                return Singleton.frames_to_be_processed;
            }
            set
            {
                Singleton.frames_to_be_processed                                = value;
            }
        }

        private static ConcurrentDictionary<int, AlertGenerationThread> all_alerts = new ConcurrentDictionary<int, AlertGenerationThread>();

        public static ConcurrentDictionary<int, AlertGenerationThread> ALL_ALERTS 
        {
            get { return all_alerts; }
            set { all_alerts = value; }
        }

        private static ConcurrentQueue<Image<Bgr, byte>> frames_to_be_displayed = new ConcurrentQueue<Image<Bgr, byte>>();

        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_DISPLAYED
        {
            get
            {

                return Singleton.frames_to_be_displayed;
            }
            set
            {
                Singleton.frames_to_be_displayed                                = value;
            }
        }

        private static ConcurrentQueue<Image<Bgr, byte>> frames_to_be_stored    = new ConcurrentQueue<Image<Bgr, byte>>();

        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_STORED
        {
            get
            {
                return Singleton.frames_to_be_stored;
            }
            set { Singleton.frames_to_be_stored                                 = value; }
        }

        private static ConcurrentDictionary<int, Face> detected_faces_datastore = new ConcurrentDictionary<int, Face>();

        public static ConcurrentDictionary<int, Face> DETECTED_FACES_DATASTORE
        {
            get
            {
                return Singleton.detected_faces_datastore;
            }
            set
            {
                Singleton.detected_faces_datastore                              = value;
            }
        }

        //THIS EMPTIES ALL DATASTORES
        public static void ClearDataStores()
        {
            Image<Bgr, byte> image;
            while (Singleton.FRAMES_TO_BE_PROCESSED.TryDequeue(out image)) ;
            while (Singleton.FRAMES_TO_BE_DISPLAYED.TryDequeue(out image)) ;
            Singleton.DETECTED_FACES_DATASTORE.Clear();
            image                                                               = null;

        }
    }
}
