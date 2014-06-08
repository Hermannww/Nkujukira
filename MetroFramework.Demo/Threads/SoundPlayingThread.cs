using MetroFramework.Demo.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class SoundPlayingThread : AbstractThread
    {
        public SoundPlayingThread()
        {

        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (running)
            {
                if (!paused)
                {
                    SoundManager.PlaySound();
                }
            }
        }

        public override bool RequestStop()
        {
            SoundManager.StopPlayingSound();
            return base.RequestStop();
        }

    }
}
