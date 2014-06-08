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
            DisplayDetails();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int i = 0;
            try
            {
                while (running)
                {
                    if (!paused)
                    {
                        SoundManager.PlaySound();
                        background_worker.ReportProgress(i);
                        i++;
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


       

        public void DisplayDetails() 
        {
            Debug.WriteLine("Displaying details NOW");
            //Singletons.Singleton.MAIN_WINDOW.Invoke(new DisplayAlert(Singletons.Singleton.MAIN_WINDOW.DisplayAlertDetails), new Object[] { identified_perpetrator });
            PerpetratorDetailsForm form = new PerpetratorDetailsForm(identified_perpetrator, true);
            form.Show();
        }

        public delegate void DisplayAlert(Perpetrator perp);

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }
    }
}
