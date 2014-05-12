using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Singletons
{
    public class Datastore
    {
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_PROCESSED = new ConcurrentQueue<Image<Bgr, byte>>();
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_DISPLAYED = new ConcurrentQueue<Image<Bgr, byte>>();
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_STORED = new ConcurrentQueue<Image<Bgr, byte>>();
        public static ConcurrentDictionary<int, Face> DETECTED_FACES_DATASTORE = new ConcurrentDictionary<int, Face>();

        public ConcurrentQueue<Image<Bgr, byte>> GetFrameToBeProcessed()
        {
            return FRAMES_TO_BE_PROCESSED;
        }

        public ConcurrentQueue<Image<Bgr, byte>> GetFrameToBeDisplayed()
        {
            return FRAMES_TO_BE_DISPLAYED;
        }

        public ConcurrentQueue<Image<Bgr, byte>> GetFrameToBeStored()
        {
            return FRAMES_TO_BE_STORED;
        }

        public ConcurrentDictionary<int, Face> GetDetectedFacesDataStore()
        {
            return DETECTED_FACES_DATASTORE;
        }

        public bool ClearAllDataStores()
        {
            return true;
        }
    }
}
