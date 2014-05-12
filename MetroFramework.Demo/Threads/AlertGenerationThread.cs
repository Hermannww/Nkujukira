using MetroFramework.Demo.Managers;
using Nkujukira.Entities;
using System;

namespace Nkujukira.Threads
{
    public class AlertGenerationThread:AbstractThread
    {
        private Face criminal;
        
        public AlertGenerationThread(Face criminal) :base()
        {
            this.criminal=criminal;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
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
            catch (Exception) 
            {
            
            }
        }

        public void DisplayDetails() { }

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }
    }
}
