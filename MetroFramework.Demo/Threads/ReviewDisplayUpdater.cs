using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using MB.Controls;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class ReviewDisplayUpdater : DisplayUpdaterThread
    {
        //THIS IS THE LABEL TEXT DISPLAYED BY A TIME LABEL
        public const string DEFAULT_TIME_LABEL_TEXT             = "00:00";

        //FLAG THAT SIGNALS TO OTHER THREADS THAT THIS THREAD IS DONE
        public static bool WORK_DONE;

        //VARIABLE CARRYING TIME ELAPSED IN CURRENLTY RUNNING VIDEO
        public static double time_elapsed;

        //INDICATES HOW MANY SECONDS MUST ELAPSE BEFORE TIMER IS FIRED
        private double seconds_btn_moving_slider;


        //TIMER FOR TIMING THE UPDATE OPERATIONS OF THE COLOR SLIDER AND THE TIME ELAPSED LABEL
        private System.Timers.Timer timer;

        //FLAG THAT INDICATES WHETHER THE TIMER INTERVAL HAS ELAPSED
        private bool time_interval_has_elapsed;

        //CONSTRUCTOR
        public ReviewDisplayUpdater(ImageBox video_display)
            : base(video_display)
        {
            Debug.WriteLine("Review display updater starting");
            WORK_DONE                                           = false;

            time_elapsed                                        = 0;
            double video_length_in_milliseconds                 = (VideoFromFileThread.VIDEO_LENGTH);
            double milliseconds_btn_moving_slider               = (((video_length_in_milliseconds)) / (double)100);
            seconds_btn_moving_slider                           = milliseconds_btn_moving_slider / 1000;
            timer                                               = new System.Timers.Timer(milliseconds_btn_moving_slider);

            time_interval_has_elapsed                           = false;

            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeExpired);

            Singleton.MAIN_WINDOW.GetControl("total_time").Text = GetVideoLengthTime();


        }


        //RETURNS THE LENGTH OF THE VIDEO AS A STRING
        private string GetVideoLengthTime()
        {
            if (VideoFromFileThread.VIDEO_LENGTH_STRING != null)
            {
                return VideoFromFileThread.VIDEO_LENGTH_STRING;
            }
            else
            {
                return DEFAULT_TIME_LABEL_TEXT;
            }
        }

        //THIS IS FIRED EVERYTIME THE TIMER INTERVAL ELAPSES
        private void OnTimeExpired(object sender, System.Timers.ElapsedEventArgs e)
        {
            //SET THE FLAG SO THE GUI IS UPDATED
            time_interval_has_elapsed                           = true;
        }

        //THIS UPDATES THE TIMER LABEL WITH THE ELAPSED TIME 
        public void UpdateTimerLabel(double elapsed_time_in_seconds)
        {
            try
            {
                //IF THE THREAD IS ALIVE
                if (running)
                {


                    elapsed_time_in_seconds += (seconds_btn_moving_slider);

                    time_elapsed                                = elapsed_time_in_seconds;

                    int hours                                   = (int)(time_elapsed / 3600);
                    int minutes                                 = (int)(time_elapsed / 60);
                    int seconds                                 = (int)(time_elapsed % 60);

                    String total_time                           = "" + ((hours < 10) ? "0" + hours : "" + hours) + ":" + ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" + ((seconds < 10) ? "0" + seconds : "" + seconds);
                    SetLabelText(total_time);
                    time_interval_has_elapsed                   = false;

                }

            }
            catch (Exception)
            {

            }

        }

        //CHANGE THE LABEL FOR TIME ELAPSED
        private void SetLabelText(String text)
        {
            //UPDATE THE LABEL IN A THREAD SAFE WAY
            SetControlPropertyThreadSafe(Singleton.MAIN_WINDOW.GetControl("time_elapsed"), "Text", text);
        }

        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            try
            {
                //ENABLE TIMER
                timer.Enabled                                   = true;

                Debug.WriteLine("Review Display Thread Running");
                //IF THREAD IS ALIVE
                while (running)
                {
                    //AND NOT PAUSED
                    if (!paused)
                    {

                        //DISPLAY THE NEXT FRAME
                        DisplayNextFrame();


                        if (time_interval_has_elapsed)
                        {
                            //UPDATE SLIDER 
                            MoveSlider();

                            //UPDATER TIME ELAPSED LABEL
                            UpdateTimerLabel(time_elapsed);
                        }

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

        //UPDATES UI THREAD
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            base.ThreadIsDone(sender, e);

            //DISABLE TIMER SO IT STOPS FIRING UNECESSARILY
            timer.Enabled                                       = false;

            //CHANGE TIMER LABELS
            SetLabelText(DEFAULT_TIME_LABEL_TEXT);

            //SET SLIDER VALUE TO 0
            Singleton.MAIN_WINDOW.GetColorSlider().Value        = 0;

        }


        //MOVES THE COLOR SLIDER BELOW THE VIDEO IN TIME WITH THE VIDEO
        private void MoveSlider()
        {

            try
            {
                //GET THE MAIN WINDOW COLOR SLIDER
                ColorSlider video_slide_bar                     = Singleton.MAIN_WINDOW.GetColorSlider();

                //IF AN INCREMENT OF THE VALUE OF THE SLIDER IS BEYOND 100
                if (video_slide_bar.Value + 1 > 100)
                {
                    //SET THE TIME ELAPSED TO 00:00
                    SetLabelText(DEFAULT_TIME_LABEL_TEXT);

                    //SET THE VALUE OF THE SLIDER TO 100
                    video_slide_bar.Value                       = 100;
                    WORK_DONE                                   = true;
                }
                else
                {
                    //ELSE INCREMENT SLIDER VALUE BY 1
                    video_slide_bar.Value++;
                }
            }
            catch (Exception)
            {

            }

        }

        //UPDATES THE TIME ELAPSED LABEL ON THE VIDEO
        public void SetTimeElapsed(double milliseconds)
        {

            double time_in_seconds                              = milliseconds / 1000;

            int hours                                           = (int)(time_in_seconds / 3600);
            int minutes                                         = (int)(time_in_seconds / 60);
            int seconds                                         = (int)(time_in_seconds % 60);

            String total_time                                   = "" + ((hours < 10) ? "0" + hours : "" + hours) + ":" + ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" + ((seconds < 10) ? "0" + seconds : "" + seconds);
            SetLabelText(total_time);
            time_elapsed                                        = time_in_seconds;

        }

        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public override bool DisplayNextFrame()
        {
            //TRY DEQUEUEING
            successfull                                         = Singleton.REVIEW_FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);
            if (successfull)
            {
                //SET THE IMAGE BOX'S IMAGE [IMAGE BOX'S ARE THREAD SAFE]
                video_display.Image                             = current_frame;
                return true;
            }
            //NO FRAMES FOUND
            else
            {
                //IF OUTPUT GRABBER THREAD AND FACE DETECTOR ARE DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if ((VideoFromFileThread.WORK_DONE) && (ReviewFaceDetectingThread.WORK_DONE))
                {
                    Debug.WriteLine("Terminating display updater");

                    //SIGNAL TO OTHER THREADS THAT THIS THREAD IS DONE
                    WORK_DONE                                   = true;

                    //SET RUNNING TO FALSE
                    running                                     = false;

                    return true;
                }
            }
            return false;

        }

        //THIS PAUSES THE THREAD AND DISABLES THE TIMER
        public override bool Pause()
        {
            paused                                              = true;


            timer.Enabled                                       = false;

            return paused;
        }

        //THIS RESUMES THE THREAD AND ENABLES THE TIMER
        public override bool Resume()
        {
            paused                                              = false;


            timer.Enabled                                       = true;

            return paused;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS
        public override bool RequestStop()
        {
            running                                             = false;


            timer.Enabled                                       = false;
            Singleton.MAIN_WINDOW.GetColorSlider().Value        = 0;
            SetLabelText(DEFAULT_TIME_LABEL_TEXT);

            return true;
        }

        public void Dispose()
        {
            timer.Dispose();
            this.RequestStop();
        }
    }
}
