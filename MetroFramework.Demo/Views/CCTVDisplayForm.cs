using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Threads;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Views
{
    public partial class CCTVDisplayForm : MetroForm
    {
        private bool running;
        private bool paused;
        private Thread display_updater_thread;
        public CCTVDisplayForm()
        {
            InitializeComponent();
            InitializeThread();
        }

        private void InitializeThread()
        {
            display_updater_thread          = new Thread(this.DoWork);
            display_updater_thread.Priority = ThreadPriority.Normal;
            display_updater_thread.Name     = "CCTV Display Thread";
            paused = true;
        }

        //CALL THIS INORDER FOR THE THREAD TO START WORKING
        public void StartWorking()
        {
            running = true;
            paused = false;
            display_updater_thread.Start();
            while (!display_updater_thread.IsAlive) ;
            Show();
        }


        private void DoWork() 
        {
            while (running) 
            {
                if (!paused) 
                {
                   // image_box.Image = (IImage)((ImageBox)Singleton.MAIN_WINDOW.GetControl("live_stream_imagebox")).Image;
                }
            }
        }

        //USED TO CHECK IF THIS THREAD IS ALIVE
        public bool IsRunning()
        {
            return running;
        }

        public bool IsPaused()
        {
            return paused;
        }

        internal void PauseRefreshingDisplay()
        {
            paused = true;
            Hide();
        }

        internal void ResumeRefreshingDisplay()
        {
            paused = false;
            Show();
        }

        //CALL WHEN U WANT TO TERMINATE THIS THREAD
        public bool RequestStop()
        {

            running = false;
            paused = true;


            return true;
        }
    }
}
