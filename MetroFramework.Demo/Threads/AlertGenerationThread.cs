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
    public abstract class AlertGenerationThread : AbstractThread
    {

        private bool sucess             = false;
        protected bool play_sound       = false;



        //CONSTRUCTOR
        public AlertGenerationThread()
            : base()
        {
        }


        //DOES SOME WORK IN THE BACKGROUND
        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (running)
                {

                    if (!paused)
                    {


                        //CHECK TO SEE IF AN ALERT HAS BEEN SIGNALED FOR
                        sucess          = GetIdentifiedIndividual();

                        //IF AN ALERT HAS BEEN SIGNALED
                        if (sucess && !ThereIsSimilarAlert())
                        {
                            Debug.WriteLine("NEW ALERT");

                            //PLAY THE ALARM SOUND
                            PlayAlarmSound();

                            //DISPLAY DETAILS OF THE ALERT
                            DisplayDetails();
                        }

                        //CHECK TO SEE IF THIS THREAD SHOULD TERMINATE
                        else
                        {
                            if (TerminateThread())
                            {
                                running = false;
                                break;
                            }
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

        protected abstract bool TerminateThread();

        protected abstract bool ThereIsSimilarAlert();


        //CHECKS THE SHARED DATASTORE TO SEE IF A STUDENT OR PERPETRATOR HAS BEEN IDENTIFIED
        protected abstract bool GetIdentifiedIndividual();


        //THIS STARTS A THREAD THAT PLAYS AN ALARM SOUND CONTINUOUSLY
        private void PlayAlarmSound()
        {
            Debug.WriteLine("Playing Alarm sound");
            if (play_sound)
            {
                SoundManager.PlaySound();
                play_sound              = false;
            }
        }

        //THIS DISPLAYS DETAILS PERTAINING TO THE ALERT GENERATED
        protected abstract void DisplayDetails();


        public override bool RequestStop()
        {

            SoundManager.StopPlayingSound();
            ((MyImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).DisableAlertMode();
            return base.RequestStop();
        }
    }
}
