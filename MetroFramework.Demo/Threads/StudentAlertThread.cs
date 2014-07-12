using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class StudentAlertThread : AlertGenerationThread
    {
        private Student identified_student = null;
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
            if (identified_student != null)
            {
                if (ids_of_students.Contains(identified_student.id)) 
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
            return Singleton.IDENTIFIED_STUDENTS.TryDequeue(out identified_student);
        }

        protected override void DisplayDetails()
        {
            //IF ITS BECOZ A STUDENT HAS BEEN IDENTIFIED
            if (identified_student != null)
            {


                //ADD THE ID OF THE STUDENT SO WE CAN TRACK IT FOR LATER
                ids_of_students.Add(identified_student.id);

                //create form
                StudentDetailsForm form    = new StudentDetailsForm(identified_student);

                //show details form
                form.ShowDialog();

                return;
            }
            identified_student             = null;
        }
    }
}
