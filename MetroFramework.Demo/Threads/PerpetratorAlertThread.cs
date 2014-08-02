using Nkujukira.Demo.Custom_Controls;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Views;

namespace Nkujukira.Demo.Threads
{
    public class PerpetratorAlertThread:AlertGenerationThread
    {
        private FaceRecognitionResult face_recog_result = null;
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
            if (face_recog_result != null)
            {

                if (ids_of_perps.Contains(face_recog_result.identified_perpetrator.id)) 
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
            return Singleton.IDENTIFIED_PERPETRATORS.TryDequeue(out face_recog_result);
        }

        protected override void DisplayDetails()
        {
            //IF THIS ALERT IS BECOZ A PERP HAS BEEN IDENTIFIED
            if (face_recog_result != null)
            {
               
                //ADD THE ID OF THE PERP SO WE CAN TRACK IT FOR LATER
                ids_of_perps.Add(face_recog_result.identified_perpetrator.id);

                //DISPLAY VISUAL CUES ON THE MAIN GUI THAT AN ALERT HAS BEEN TRIGGERED
                MyImageBox alert_image_box=(MyImageBox)Singleton.MAIN_WINDOW.GetControl(MainWindow.MainWindowControls.live_stream_image_box1);
                
                alert_image_box.EnableAlertMode();

                //create form
                PerpetratorAertForm form = new PerpetratorAertForm(face_recog_result);

                //show details form
                form.ShowDialog();

                return;
            }

            face_recog_result                 = null;
        }
    }
}
