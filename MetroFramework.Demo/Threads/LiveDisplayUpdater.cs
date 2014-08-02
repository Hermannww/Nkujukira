using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Nkujukira.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Threads
{
    public class LiveDisplayUpdater : DisplayUpdaterThread
    {

        //FLAG THAT SIGNALS TO OTHER THREADS THAT THIS THREAD IS DONE
        public static bool WORK_DONE;

        //CONSTRUCTOR
        public LiveDisplayUpdater(ImageBox video_display)
        : base(video_display)
        {
            Debug.WriteLine("display updater starting");

            this.video_display      = video_display;
            WORK_DONE               = false;


        }

        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            try
            {

                Debug.WriteLine("Live Display Thread Running");
                //IF THREAD IS ALIVE
                while (running)
                {
                    //AND NOT PAUSED
                    if (!paused)
                    {

                        //DISPLAY THE NEXT FRAME
                        DisplayNextFrame();

                    }
                    //Thread.Sleep(50);
                }

                MakeBackGroundBlack();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "In VIDEO UPDATER");
            }
        }

        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public override bool DisplayNextFrame()
        {
            //TRY DEQUEUEING
            successfull             = Singleton.LIVE_FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);

            if (successfull)
            {
                //SET THE IMAGE BOX'S IMAGE [IMAGE BOX'S ARE THREAD SAFE]
                video_display.Image = current_frame;
                return true;
            }

            //NO FRAMES FOUND
            else
            {
                //IF OUTPUT GRABBER THREAD AND FACE DETECTOR ARE DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if ((CameraOutputGrabberThread.WORK_DONE) && (LiveStreamFaceDetectingThread.WORK_DONE))
                {
                    Debug.WriteLine("Terminating display updater");

                    //SIGNAL TO OTHER THREADS THAT THIS THREAD IS DONE
                    WORK_DONE       = true;

                    //SET RUNNING TO FALSE
                    running         = false;

                    return true;
                }
            }
            return false;

        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS
        public override bool RequestStop()
        {
            running                 = false;
            WORK_DONE               = true;
            return true;
        }

     
    }
}
