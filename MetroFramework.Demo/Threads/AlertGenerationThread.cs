using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using Nkujukira.Entities;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class AlertGenerationThread : AbstractThread
    {
        private Perpetrator identified_perpetrator = null;
        private Student identified_student         = null;
        private bool sucess                        = false;


        //CONSTRUCTOR
        public AlertGenerationThread()
            : base()
        {
            running = true;
            paused = false;
        }


        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (running)
                {
                    Debug.WriteLine("ALERT THREAD RUNNING");

                    if (!paused)
                    {
                        Debug.WriteLine("ALERT THREAD IS NOT PAUSED");

                        //CHECK TO SEE IF AN ALERT HAS BEEN SIGNALED FOR
                        sucess = GetIdentifiedStudentOrPerpetrator();

                        //IF AN ALERT HAS BEEN SIGNALED
                        if (sucess)
                        {
                            //PLAY THE ALARM SOUND
                            PlayAlarmSound();
                
                            //DISPLAY DETAILS OF THE ALERT
                            DisplayDetails();
                         }
                       
                    }
                    Thread.Sleep(200);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //CHECKS THE SHARED DATASTORE TO SEE IF A STUDENT OR PERPETRATOR HAS BEEN IDENTIFIED
        private bool GetIdentifiedStudentOrPerpetrator()
        {
            //IF THE ATTEMPT TO DEQUEUE FROM 1 OF THE SHARED DATASTORES RETURNS TRUE THEN PROCEED ELSE FALSE
            return Singleton.IDENTIFIED_STUDENTS.TryDequeue(out identified_student) || Singleton.IDENTIFIED_PERPETRATORS.TryDequeue(out identified_perpetrator);
        }

        //THIS STARTS A THREAD THAT PLAYS AN ALARM SOUND CONTINUOUSLY
        private void PlayAlarmSound()
        {
            Debug.WriteLine("Playing Alarm sound");
            SoundManager.PlaySound();
        }

        //THIS CHECKS IF THE CURRENT ALERT IS ABOUT THE SAME PERPETRATOR AS THAT GIVEN
        public bool AlertIsAboutSamePerpetrator(Perpetrator perpetrator)
        {
            if (identified_perpetrator != null)
            {
                return this.identified_perpetrator.id == perpetrator.id;
            }
            return false;
        }

        public bool AlertIsAboutSameStudent(Student student)
        {
            if (identified_student != null) 
            {
                return this.identified_student.id == student.id;
            }
            return false;
        }

        //THIS DISPLAYS DETAILS PERTAINING TO THE ALERT GENERATED
        public void DisplayDetails()
        {

            //IF THIS ALERT IS BECOZ A PERP HAS BEEN IDENTIFIED
            if (identified_perpetrator != null)
            {
                //create form
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(identified_perpetrator, true);

                //show details form
                form.ShowDialog();

                return;
            }

            //IF ITS BECOZ A STUDENT HAS BEEN IDENTIFIED
            if (identified_student != null)
            {
                //create form
                StudentDetailsForm form     = new StudentDetailsForm(identified_student);

                //show details form
                form.ShowDialog();

                return;
            }

            identified_perpetrator = null;
            identified_student     = null;

        }


    }
}
