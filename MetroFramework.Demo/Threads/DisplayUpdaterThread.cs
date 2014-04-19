using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using Nkujukira.Entities;
using System.Threading.Tasks;
using System.Drawing;
using MetroFramework.Demo;
namespace Nkujukira.Threads
{
    class DisplayUpdaterThread : ThreadSuperClass
    {
        public ImageBox video_display;
        public Image<Bgr, byte> current_frame;
        bool successfull;
        private static bool video_paused = false;
        public static bool show_deteted_faces_is_checked = false;


        public DisplayUpdaterThread(ImageBox video_display)
            : base()
        {
            this.video_display = video_display;
            running = true;
        }

        public override void DoWork()
        {
            while (running)
            {
                try
                {

                    if (!paused)
                    {
                        successfull = MainWindow.FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);

                        if (successfull)
                        {
                            
                            DisplayNextFrame();
                        }
                        Thread.Sleep(30);
                    }
                    

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + "In VIDEO UPDATER");
                }
            }
        }


        


        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public bool DisplayNextFrame()
        {
            Debug.WriteLine("Drawing video frame");
            if (running)
            {
                video_display.Image = this.current_frame;
            }
            this.current_frame = null;
            return true;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS
        public override bool RequestStop()
        {
            running = false;
            return true;
        }

       


    }
}
