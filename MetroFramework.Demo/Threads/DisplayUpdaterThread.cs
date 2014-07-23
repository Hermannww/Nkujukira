using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using Nkujukira.Demo.Singletons;
using MB.Controls;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using Emgu.CV.UI;
using System.Threading;

namespace Nkujukira.Demo.Threads
{
    public abstract class DisplayUpdaterThread : AbstractThread, IDisposable
    {
        //THE FRAME CURRENTLY BEING DISPLAYED
        protected Image<Bgr, byte> current_frame;

        protected bool successfull;

        protected ImageBox video_display;



        //CONSTRUCTOR
        public DisplayUpdaterThread(ImageBox video_display)
            : base()
        {
            Debug.WriteLine("display updater starting");

            this.video_display           = video_display;


        }

        //UPDATES UI THREAD WHEN THIS THREAD HAS TERMINATED
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //MAKE BG BLACK
            MakeBackGroundBlack();
        }


        //DISPLAYS A BLACK FRAME IN THE REVIEW FOOTAGE IMAGE BOX
        protected void MakeBackGroundBlack()
        {
            //GET WIDTH AND HEIGHT OF PROPOSED FRAME
            int width                    = video_display.Width;
            int height                   = video_display.Height;

            //CREATE BLACK FRAME
            Image<Bgr, byte> black_image = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0));

            //DISPLAY FRAME
            video_display.Image          = black_image;
        }

        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public abstract bool DisplayNextFrame();

    }
}
