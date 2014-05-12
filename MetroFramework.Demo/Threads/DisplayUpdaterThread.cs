using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using MetroFramework.Demo.Singletons;
using MB.Controls;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;

namespace Nkujukira.Threads
{
    public class DisplayUpdaterThread : AbstractThread
    {

        private Image<Bgr, byte> current_frame;
        public const string DEFAULT_TIME_LABEL_TEXT = "00:00";

        bool successfull;

        public static bool show_deteted_faces_is_checked = false;
        public static bool WORK_DONE = false;
        public static double time_elapsed;

        private double seconds_btn_moving_slider;
        private double video_length_in_milliseconds;

        private System.Timers.Timer timer;
        private bool time_interval_has_elapsed=false;




        public DisplayUpdaterThread()
            : base()
        {

            video_length_in_milliseconds = (VideoFromFileThread.VIDEO_LENGTH);
            time_elapsed = 0;
            double milliseconds_btn_moving_slider = (((video_length_in_milliseconds)) / (double)100);
            seconds_btn_moving_slider = milliseconds_btn_moving_slider / 1000;
            timer = new System.Timers.Timer(milliseconds_btn_moving_slider);

            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeExpired);

            Singleton.MAIN_WINDOW.GetLabel("total_time").Text = GetVideoLengthTime();

        }

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

        //SET THE FLAG SO THE GUI IS UPDATED
        private void OnTimeExpired(object sender, System.Timers.ElapsedEventArgs e)
        {
            time_interval_has_elapsed = true;
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
                        time_elapsed = elapsed_time_in_seconds;

                        int hours = (int)(time_elapsed / 3600);
                        int minutes = (int)(time_elapsed / 60);
                        int seconds = (int)(time_elapsed % 60);

                        String total_time = "" + ((hours < 10) ? "0" + hours : "" + hours) + ":" + ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" + ((seconds < 10) ? "0" + seconds : "" + seconds);
                        SetLabelText(total_time);
                        time_interval_has_elapsed = false;
                   
                }

            }
            catch (Exception)
            {

            }
        }

        //CHANGE THE LABEL FOR TIME ELAPSED
        private void SetLabelText(String text)
        {

            SetControlPropertyThreadSafe(Singleton.MAIN_WINDOW.GetLabel("time_elapsed"),"Text", text);
        }

        public override void DoWork(object sender, DoWorkEventArgs ex)
        {
            try
            {
                //ENABLE TIMER
                timer.Enabled = true;
                while (running)
                {
                    if (!paused)
                    {
                        DisplayNextFrame();
                        if (time_interval_has_elapsed)
                        {
                            MoveSlider();
                            UpdateTimerLabel(time_elapsed);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "In VIDEO UPDATER");
            }
        }

        

        //UPDATES UI THREAD
        public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //MAKE BG BLACK
            MakeBackGroundBlack();

            //DISABLE TIMER SO IT STOPS FIRING UNECESSARILY
            timer.Enabled = false;

            //CHANGE TIMER LABELS
            SetLabelText(DEFAULT_TIME_LABEL_TEXT);

            //SET SLIDER VALUE TO 0
            Singleton.MAIN_WINDOW.GetColorSlider().Value = 0;
        }

        private void MakeBackGroundBlack()
        {
           
            int width = Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Width;
            int height = Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Height;
            Image<Bgr, byte> black_image = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0));
            Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Image = black_image;
        }


        private void MoveSlider()
        {
            try
            {
                ColorSlider video_slide_bar = Singleton.MAIN_WINDOW.GetColorSlider();
                if (video_slide_bar.Value + 1 > 100)
                {
                    SetLabelText(DEFAULT_TIME_LABEL_TEXT);
                    video_slide_bar.Value = 100;
                    WORK_DONE = true;
                }
                else
                {
                    video_slide_bar.Value++;          
                }
            }
            catch (Exception)
            {
                //IF OUTPUT GRABBER THREAD AND FACE DETECTOR ARE DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                //running = false;
            }
        }

        public void SetTimeElapsed(double milliseconds)
        {
            double time_in_seconds = milliseconds / 1000;

            int hours = (int)(time_in_seconds / 3600);
            int minutes = (int)(time_in_seconds / 60);
            int seconds = (int)(time_in_seconds % 60);

            String total_time = "" + ((hours < 10) ? "0" + hours : "" + hours) + ":" + ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" + ((seconds < 10) ? "0" + seconds : "" + seconds);
            SetLabelText(total_time);
            time_elapsed = time_in_seconds;
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public bool DisplayNextFrame()
        {
            successfull = Singleton.FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);
            if (successfull)
            {
               
                    Debug.WriteLine("Drawing video frame");
                    Singleton.MAIN_WINDOW.GetReviewFootageImageBox().Image = current_frame;
                    return true;
               
            }
            //NO FRAMES FOUND
            else
            {
                //IF OUTPUT GRABBER THREAD AND FACE DETECTOR ARE DONE THEN IT MEANS THE FRAMES ARE DONE
                //TERMINATE THIS THREAD AND SIGNAL TO OTHERS THAT IT IS DONE
                if (VideoFromFileThread.WORK_DONE && FaceDetectingThread.WORK_DONE)
                {
                    Debug.WriteLine("Terminating display updater");
                    DisplayUpdaterThread.WORK_DONE = true;
                    running = false;
                    return true;
                }
            }
            return false;

        }

        //THIS PAUSES THE THREAD AND DISABLES THE TIMER
        public override bool Pause()
        {
            paused = true;
            timer.Enabled = false;
            return paused;
        }

        //THIS RESUMES THE THREAD AND ENABLES THE TIMER
        public override bool Resume()
        {
            paused = false;
            timer.Enabled = true;
            return paused;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS
        public override bool RequestStop()
        {
            running = false;
            timer.Enabled = false;
            Singleton.MAIN_WINDOW.GetColorSlider().Value = 0;
            SetLabelText(DEFAULT_TIME_LABEL_TEXT);
            return true;
        }
    }
}
