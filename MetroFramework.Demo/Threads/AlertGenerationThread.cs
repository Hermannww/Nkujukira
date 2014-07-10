using MetroFramework.Demo.Custom_Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Views;
using Nkujukira.Entities;
using System;
using System.Collections.Generic;
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
        private List<int> ids_of_perps = null;
        private List<int> ids_of_students = null;


        //CONSTRUCTOR
        public AlertGenerationThread()
            : base()
        {
            running = true;
            paused = false;
            ids_of_perps = new List<int>();
            ids_of_students = new List<int>();
        }


        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (running)
                {

                    if (!paused)
                    {
                        

                        //CHECK TO SEE IF AN ALERT HAS BEEN SIGNALED FOR
                        sucess = GetIdentifiedStudentOrPerpetrator();

                        //IF AN ALERT HAS BEEN SIGNALED
                        if (sucess&&!ThereIsSimilarAlert())
                        {
                            Debug.WriteLine("NEW ALERT");
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


        private bool ThereIsSimilarAlert()
        {
            if (identified_perpetrator != null)
            {
                return ids_of_perps.Contains(identified_perpetrator.id);
            }
            else if (identified_student != null) 
            {
                return ids_of_students.Contains(identified_student.id);
            }
            return false;
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
            if (identified_perpetrator != null || identified_student != null)
            {
                SoundManager.PlaySound();
            }
        }

        //THIS DISPLAYS DETAILS PERTAINING TO THE ALERT GENERATED
        public void DisplayDetails()
        {

            //IF THIS ALERT IS BECOZ A PERP HAS BEEN IDENTIFIED
            if (identified_perpetrator != null)
            {
                Debug.WriteLine("ALERT IS FOR PERP WITH ID=" + identified_perpetrator.id);
                //ADD THE ID OF THE PERP SO WE CAN TRACK IT FOR LATER
                ids_of_perps.Add(identified_perpetrator.id);

                //DISPLAY VISUAL CUES ON THE MAIN GUI THAT AN ALERT HAS BEEN TRIGGERED
                ((MyImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).EnableAlertMode();

                //create form
                PerpetratorDetailsForm form = new PerpetratorDetailsForm(identified_perpetrator, true);

                //show details form
                form.ShowDialog();

                return;
            }

            //IF ITS BECOZ A STUDENT HAS BEEN IDENTIFIED
            if (identified_student != null)
            {
                Debug.WriteLine("ALERT IS FOR STUDENT WITH ID=" + identified_student.id);
                //ADD THE ID OF THE STUDENT SO WE CAN TRACK IT FOR LATER
                ids_of_students.Add(identified_student.id);

                //create form
                StudentDetailsForm form     = new StudentDetailsForm(identified_student);

                //show details form
                form.ShowDialog();

                return;
            }

            identified_perpetrator = null;
            identified_student     = null;

        }

        public override bool RequestStop()
        {
            
            SoundManager.StopPlayingSound();
            ((MyImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).DisableAlertMode();
            return base.RequestStop();
        }
    }
}
