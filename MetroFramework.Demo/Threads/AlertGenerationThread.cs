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
        private SoundPlayingThread sound_player;
        
        public AlertGenerationThread(Perpetrator identified_perpetrator) :base()
        {
            this.identified_perpetrator=identified_perpetrator;
            this.sound_player = new SoundPlayingThread();
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                sound_player.StartWorking();               
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
            Debug.WriteLine("Displaying details NOW");
            PerpetratorDetailsForm form = new PerpetratorDetailsForm(identified_perpetrator, true);
            form.Show();
        }

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }
    }
}
