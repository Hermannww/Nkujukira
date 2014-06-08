using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using Nkujukira.Entities;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class AlertGenerationThread:AbstractThread
    {
        private Perpetrator identified_perpetrator;
        
        public AlertGenerationThread(Perpetrator identified_perpetrator) :base()
        {
            this.identified_perpetrator=identified_perpetrator;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DisplayDetails();
            try
            {
                while (running)
                {
                    if (!paused)
                    {
                        SoundManager.PlaySound();    
                    }
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool IsAboutSamePerpetrator(Perpetrator perpetrator) 
        {
            return this.identified_perpetrator.id == perpetrator.id;
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisplayDetails();
        }

        public void DisplayDetails() 
        {
            Singletons.Singleton.MAIN_WINDOW.Invoke(new DisplayAlert(Singletons.Singleton.MAIN_WINDOW.DisplayAlertDetails), new Object[] { identified_perpetrator });
        }

        public delegate void DisplayAlert(Perpetrator perp);

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }
    }
}
