using MetroFramework.Demo.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetroFramework.Demo.Threads
{
    public class SoundPlayingThread 
    {
        private bool running;
        private bool paused;
        private Thread thread;

        //CONSTRUCTOR
        public SoundPlayingThread()
        {
            running             = false;
            paused              = false;
            thread              = new Thread(this.DoWork);
            thread.Priority     = ThreadPriority.AboveNormal;
            thread.IsBackground = true;
        }

        //CALL THIS INORDER FOR THE THREAD TO START WORKING
        public void StartWorking() 
        {
            running = true;
            thread.Start();
        }

        //DOES WORK IN THE BACK GROUND
        public  void DoWork()
        {
            while (running)
            {
                if (!paused)
                {
                    //PLAY SOUND IN A LOOP
                    SoundManager.PlaySound();

                    //SLEEP FOR A FEW SECONDS SO THE SOUND FINISHES PLAYING
                    Thread.Sleep(3000);
                }
            }
        }

        //CALL WHEN U WANT TO TERMINATE THIS THREAD
        public bool RequestStop()
        {

            running             = false;
            paused              = true;

            //ALSO STOP PLAYING THE SOUND IF ITS PLAYING
            SoundManager.StopPlayingSound();
            return true;
        }

        //USED TO CHECK IF THIS THREAD IS ALIVE
        public bool IsRunning()
        {
            return running;
        }
    }
}
