using System;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using MetroFramework.Demo;
using MB.Controls;
using System.Windows.Forms;
namespace Nkujukira.Threads
{
    public class DisplayUpdaterThread : ThreadSuperClass
    {
        public ImageBox video_display;
        public Image<Bgr, byte> current_frame;
        bool successfull;
        public static bool show_deteted_faces_is_checked = false;
        public static bool WORK_DONE = false;
        private ColorSlider slider;
        private double seconds_btn_moves;
        private double video_length_in_milliseconds;
        private System.Timers.Timer timer;
        private Label time_elapsed_label;
        private Label total_time_label;
        public static double time_elapsed;
        public const string DEFAULT_TIME_LABEL_TEXT = "00:00";



        public DisplayUpdaterThread(ImageBox video_display, ColorSlider slider, Label time_elapsed_label, Label total_time_label)
            : base()
        {
            this.video_display = video_display;

            this.slider = slider;

            WORK_DONE = false;

            video_length_in_milliseconds = (VideoFromFileThread.VIDEO_LENGTH);

            time_elapsed = 0;

            double milliseconds_btn_moves = (((video_length_in_milliseconds)) / (double)100);

            seconds_btn_moves = milliseconds_btn_moves / 1000;

            timer = new System.Timers.Timer(milliseconds_btn_moves);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeExpired);

            this.time_elapsed_label = time_elapsed_label;
            this.total_time_label = total_time_label;

            total_time_label.Text = GetVideoLengthTime();

            running = true;
        }

        private string GetVideoLengthTime()
        {

            return VideoFromFileThread.VIDEO_LENGTH_STRING;
        }

        private void OnTimeExpired(object sender, System.Timers.ElapsedEventArgs e)
        {
            MoveSlider();
            UpdateTimerLabel(time_elapsed);
        }

        //THIS UPDATES THE TIMER LABEL WITH THE ELAPSED TIME 
        public void UpdateTimerLabel(double elapsed_time_in_seconds)
        {
            try
            {
                if (!WORK_DONE)
                {
                    //
                    elapsed_time_in_seconds += (seconds_btn_moves);
                    time_elapsed = elapsed_time_in_seconds;

                    int hours = (int)(time_elapsed / 3600);
                    int minutes = (int)(time_elapsed / 60);
                    int seconds = (int)(time_elapsed % 60);

                    String total_time = "" + ((hours < 10) ? "0" + hours : "" + hours) + ":" + ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" + ((seconds < 10) ? "0" + seconds : "" + seconds);
                    Debug.WriteLine("Time Elapsed=".ToUpper() + total_time);
                    SetLabelText(total_time);
                }

            }
            catch (Exception)
            {

            }
        }

        private void SetLabelText(String text)
        {
            try
            {
                if (this.time_elapsed_label.InvokeRequired)
                {
                    this.time_elapsed_label.Invoke((MethodInvoker)delegate
                    {
                        this.time_elapsed_label.Text = text;
                    });
                }
                else
                {
                    this.time_elapsed_label.Text = text;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public override void DoWork()
        {
            try
            {
                timer.Enabled = true;
                while (running)
                {
                    if (!paused)
                    {
                        if (!running) break;
                        successfull = MainWindow.FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);
                        if (!running) break;
                        if (successfull)
                        {
                            if (!running) break;
                            DisplayNextFrame();
                            if (!running) break;
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
                                break;
                            }
                        }
                        if (!running) break;
                        //Thread.Sleep(30);
                        if (!running) break;
                    }

                }
                MakeBackGroundBlack();
                return;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "In VIDEO UPDATER");
            }
        }

        private void MakeBackGroundBlack()
        {
            int width = video_display.Width;
            int height = video_display.Height;
            Image<Bgr, byte> black_image = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0));
            video_display.Image = black_image;
        }


        private void MoveSlider()
        {
            try
            {
                if (slider.Value + 1 > 100)
                {
                    timer.Enabled = false;
                    SetLabelText(DEFAULT_TIME_LABEL_TEXT);
                    if (slider.InvokeRequired)
                    {
                        slider.Invoke((MethodInvoker)delegate
                        {
                            slider.Value = 100;
                        });
                    }

                    WORK_DONE = true;
                }
                else
                {
                    Debug.WriteLine("VIDEO_LENGTH=" + video_length_in_milliseconds);
                    Debug.WriteLine("VALUE_TO_MOVE=" + seconds_btn_moves);
                    if (slider.InvokeRequired)
                    {
                        slider.Invoke((MethodInvoker)delegate
                        {
                            slider.Value++;
                        });
                    }
                    
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
            Debug.WriteLine("Time Elapsed=".ToUpper() + total_time);
            SetLabelText(total_time);
            time_elapsed = time_in_seconds;
        }

        //THIS UPDATES THE DISPLAY(IMAGE BOX) 
        //WITH THE NEXT FRAME TO BE DISPLAYED
        public bool DisplayNextFrame()
        {

            if (current_frame != null)
            {
                using (current_frame)
                {
                    if (!running) return false;
                    Debug.WriteLine("Drawing video frame");
                    video_display.Image = current_frame;
                    this.current_frame = null;
                }
                return true;
            }
            return false;
        }

        //THIS PAUSES THE THREAD AND DISABLES THE TIMER
        public override void Pause()
        {
            paused = true;
            timer.Enabled = false;
        }

        //THIS RESUMES THE THREAD AND ENABLES THE TIMER
        public override void Resume()
        {
            paused = false;
            timer.Enabled = true;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL OBJECTS
        public override bool RequestStop(Thread thread)
        {
            running = false;
            timer.Enabled = false;
            slider.Value = 0;
            SetLabelText(DEFAULT_TIME_LABEL_TEXT);
            return true;
        }
    }
}
