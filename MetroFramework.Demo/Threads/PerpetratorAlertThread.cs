using MetroFramework.Demo.Custom_Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class PerpetratorAlertThread:AlertGenerationThread
    {
        private Perpetrator identified_perpetrator = null;
        private List<int> ids_of_perps             = null;
        public static bool WORK_DONE               = false;

        public PerpetratorAlertThread() 
        {
            ids_of_perps                           = new List<int>();
            WORK_DONE                              = false;
        }

        protected override bool TerminateThread()
        {
            if (PerpetratorRecognitionThread.WORK_DONE && LiveStreamFaceDetectingThread.WORK_DONE) 
            {
                return true;
            }
            return false;
        }

        protected override bool ThereIsSimilarAlert()
        {
            if (identified_perpetrator != null)
            {

                if (ids_of_perps.Contains(identified_perpetrator.id)) 
                {
                    return true;
                }
            }
            play_sound = true;
            return false;
        }

        protected override bool GetIdentifiedIndividual()
        {
            //IF THE ATTEMPT TO DEQUEUE FROM 1 OF THE SHARED DATASTORES RETURNS TRUE THEN PROCEED ELSE FALSE
            return Singleton.IDENTIFIED_PERPETRATORS.TryDequeue(out identified_perpetrator);
        }

        protected override void DisplayDetails()
        {
            //IF THIS ALERT IS BECOZ A PERP HAS BEEN IDENTIFIED
            if (identified_perpetrator != null)
            {
               
                //ADD THE ID OF THE PERP SO WE CAN TRACK IT FOR LATER
                ids_of_perps.Add(identified_perpetrator.id);

                //DISPLAY VISUAL CUES ON THE MAIN GUI THAT AN ALERT HAS BEEN TRIGGERED
                ((MyImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).EnableAlertMode();

                //create form
                PerpetratorDetailsForm form        = new PerpetratorDetailsForm(identified_perpetrator, true);

                //show details form
                form.ShowDialog();

                return;
            }

            identified_perpetrator                 = null;
        }
    }
}
