using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Singletons;
using Nkujukira.Demo.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Threads
{
    public class StudentAlertThread : AlertGenerationThread
    {
        private FaceRecognitionResult face_recog_result = null;
        private List<int> ids_of_students  = null;
        public static bool WORK_DONE       = false;

        public StudentAlertThread()
        {
            ids_of_students                = new List<int>();
            WORK_DONE                      = false;
        }

        protected override bool TerminateThread()
        {
            if (StudentRecognitionThread.WORK_DONE && ReviewFaceDetectingThread.WORK_DONE)
            {
                return true;
            }
            return false;
        }

        protected override bool ThereIsSimilarAlert()
        {
            if (face_recog_result != null)
            {
                if (ids_of_students.Contains(face_recog_result.identified_student.id)) 
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
            return Singleton.IDENTIFIED_STUDENTS.TryDequeue(out face_recog_result);
        }

        protected override void DisplayDetails()
        {
            //IF ITS BECOZ A STUDENT HAS BEEN IDENTIFIED
            if (face_recog_result != null)
            {
                //ADD THE ID OF THE STUDENT SO WE CAN TRACK IT FOR LATER
                ids_of_students.Add(face_recog_result.id);

                //create form
                StudentAlertForm form = new StudentAlertForm(face_recog_result);

                //show details form
                form.ShowDialog();

                return;
            }
            face_recog_result             = null;
        }
    }
}
