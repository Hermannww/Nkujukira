﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Collections.Concurrent;
using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Entities;
using System.Diagnostics;
using Emgu.CV.UI;
using MB.Controls;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Views;
using MetroFramework.Demo.Threads;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Interfaces;

namespace MetroFramework.Demo
{
    public partial class MainWindow : MetroForm
    {
        private const string SELECT_VIDEO_MESSAGE        = "Please Select a Video file";
        private const string LOAD_CAMERA_FOOTAGE_MESSAGE = "You Are Loading Footage From Your camera!!";
        private const string FILE_FILTER                 = "All files (*.*)|*.*";
        private const string MESSAGE_BOX_TITLE           = "Message!!";
        private const string PAUSE_BUTTON_TEXT           = "Pause";
        private const string PLAY_BUTTON_TEXT            = "Play";

       /* public static String THEMECOLOR = null;
        public static bool REMOVE_LOGIN_COMPONENT;
        public void InterpretSettings(String[] settings)
        {
            try
            {
                if (settings.Length > 0)
                {
                    THEMECOLOR = settings[0];
                    if (settings[1].Equals("yes"))
                    {
                        REMOVE_LOGIN_COMPONENT = true;
                    }
                    else
                    {
                        REMOVE_LOGIN_COMPONENT = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\n\nERROR form InterpretSettings MainWindow");
            }
        }
        public String[] GetSettingsList(String settings_from_file)
        {
            String[] settings = null;
            try
            {
                Debug.WriteLine("String from File=" + settings_from_file);
                if (settings_from_file != null)
                {
                    settings = settings_from_file.Split(',');
                    return settings;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\n\nERROR from getSettingsList method MainWindow class");
            }
            return null;
        }*/
         

        public MainWindow()
        {
            InitializeComponent();
           /* if (THEMECOLOR != null)
            {
                if (THEMECOLOR.Equals("Light"))
                {
                    this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Light;
                }
                else if (THEMECOLOR.Equals("Dark"))
                {
                    this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
                }
            }
            FileFactory file_factory = new FileFactory();
            FileInterface text_file = file_factory.GetFile("TEXTFILE");
            this.InterpretSettings(this.GetSettingsList(text_file.readFromFile(@"dashBoard.txt")));*/
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            Singleton.MAIN_WINDOW = this;

            metroStyleManager.Style = MetroColorStyle.Red;

            this.MaximizeBox = false;

            DisableControls();
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            MetroTaskWindow.ShowTaskWindow(this, "SubControl in TaskWindow", new TaskWindowControl(), 10);
        }


        

        

     

        //THIS DISPLAYS A DIALOG ALLOWING A USER TO LOAD A VIDEO
        //IT THEN STARTS THREADS TO LOAD AND PROCESS VIDEO FRAME BY FRAME
        private void pick_video_button_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadManager.StopAllThreads();
                Singleton.ClearDataStores();
                ThreadManager.ReleaseAllThreadResources();

                String file_name = LoadVideoFromFile();

                if (file_name != null)
                {
                    InitializeStuff();
                    StartReviewFootageThreads(file_name);
                    EnableControls();
                    return;
                }
                else
                {

                    MetroMessageBox.Show(this, SELECT_VIDEO_MESSAGE, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in Pick Video" + ex.Message);
            }
        }

        //PAUSES THE RUNNING VIDEO UPON CALL
        private void pause_button_Click(object sender, EventArgs e)
        {
            if (pause_button.Text == PAUSE_BUTTON_TEXT)
            {
                PauseVideo();
            }
            else
            {
                ResumeVideo();
            }
        }

        //STOPS RUNNING VIDEO UPON CALL [CLICK OF STOP BUTTON]
        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Stopping Threads");
                ThreadManager.StopAllThreads();
                Debug.WriteLine("Disabling Buttons");
                //DisableButtons();
                Debug.WriteLine("Releasing Resources");
                Singleton.ClearDataStores();
                ThreadManager.ReleaseAllThreadResources();
            }
            catch (Exception)
            {


            }
        }

        
        //THIS HANDLES THE REVIEW FOOTAGE IMAGE BOX SLIDER SCROLL EVENT
        private void SlidersScroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (!DisplayUpdaterThread.WORK_DONE)
                {
                    //GET VALUE USER HAS SCROLLED TO
                    int value = (sender as ColorSlider).Value;

                    //GET THE PERCENTAGE REPRESENTING THAT VALUE
                    double ratio = ((((double)value) / ((double)100)));

                    //FORWARD TO THAT PART OF THE VIDEO
                    GoToThatPartOfTheVideo(ratio);

                }
                else
                {
                    slider_review_footage.Value = 0;
                    slider_review_footage.Enabled = false;
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

        }

        public void AddItemsToPanel(Control picture_box)
        {
            this.panel_for_detected_faces.Controls.Add(picture_box);
        }

        //STARTS ALL NECESSARY THREADS
        private void StartReviewFootageThreads(String file_name)
        {
            Singleton.CURRENT_FILE_NAME = file_name;
            ThreadManager.StartIntroThreads(true);
        }

        //STARTS ALL NECESSARY THREADS
        private void StartLiveFootageThreads()
        {
            ThreadManager.StartIntroThreads(false);
        }

        //ATTEMPTS TO PAUSE A RUNNING VIDEO
        public void PauseVideo()
        {
            ThreadManager.PauseAllThreads();
            AbstractThread.SetControlPropertyThreadSafe(pause_button, "Text", PLAY_BUTTON_TEXT);
        }

        //ATTEMPTS TO RESUME A PREVIOUSLY PAUSED VIDEO
        public void ResumeVideo()
        {
            ThreadManager.ResumeAllThreads();
            AbstractThread.SetControlPropertyThreadSafe(pause_button, "Text", PAUSE_BUTTON_TEXT);
           
        }

        //ENABLES DRAWING OF DETECTED FACES ON TO THE FRAMES
        private void show_detected_faces2_CheckedChanged(object sender, EventArgs e)
        {
            FaceDetectingThread.draw_detected_faces = !FaceDetectingThread.draw_detected_faces;
        }

        //FORWARDS TO A CERTAIN PART OF A VIDEO
        private void GoToThatPartOfTheVideo(double ratio)
        {
            //PAUSE THE VIDEO
            ThreadManager.PauseAllThreads();

            //CLEAR ALL THE DATA STORES 
            Singleton.ClearDataStores();

            //GET THE MILLESCONDS TO FORWARD TO
            double millescond_to_jump_to = ratio * VideoFromFileThread.VIDEO_LENGTH;

            //FORWARD THE VIDEO
            ((VideoFromFileThread)ThreadManager.GetThread(ThreadFactory.VIDEO_THREAD)).RewindOrForwardVideo(millescond_to_jump_to);

            //SET THE TIME ELAPSED ON THE VIDEO
            ((DisplayUpdaterThread)ThreadManager.GetThread(ThreadFactory.DISPLAY_UPDATER)).SetTimeElapsed(millescond_to_jump_to);
            
            //RESUME PLAYING THE VIDEO
            ThreadManager.ResumeAllThreads();
        }


        //THIS RETURNS A FILEPATH TO A GIVEN VIDEO 
        //AFTER PRESENTING A USER WITH A DIALOG
        private String LoadVideoFromFile()
        {
            String file_name = null;
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = FILE_FILTER;
                dialog.Title = SELECT_VIDEO_MESSAGE;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    file_name = dialog.FileName;
                    return file_name;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        //INITIALIZES ALL DATA STORES AND NECESSARY OBJECTS
        public void InitializeStuff()
        {
            Singleton.FRAMES_TO_BE_PROCESSED = new ConcurrentQueue<Image<Bgr, byte>>();
            Singleton.FRAMES_TO_BE_DISPLAYED = new ConcurrentQueue<Image<Bgr, byte>>();
            Singleton.DETECTED_FACES_DATASTORE = new ConcurrentDictionary<int, Face>();
            show_detected_faces2.Checked = false;
        }

        //THIS DISABLES UNECESSARY CONTROLS
        public void DisableControls()
        {
            if (pause_button != null)
            {
                pause_button.Enabled = false;
            }
            if (stop_button_1 != null)
            {
                stop_button_1.Enabled = false;
            }
            if (stop_button_2 != null)
            {
                stop_button_2.Enabled = false;
            }
            if (slider_review_footage != null)
            {
                slider_review_footage.Enabled = false;
            }
            ResetButtonText();
            //ENABLE THE PICK VIDEO BUTTON
            //SO THE USER HAS THE ABILITY TO PICK 
            //ANOTHER VIDEO
            pick_video_button.Enabled = true;

        }

        //THIS ENABLES THE NECESSARY CONTROLS
        public void EnableControls()
        {
            if (pause_button != null)
            {
                pause_button.Enabled = true;
            }
            if (stop_button_1 != null)
            {
                stop_button_1.Enabled = true;
            }
            if (stop_button_2 != null)
            {
                stop_button_2.Enabled = true;
            }
            if (slider_review_footage != null)
            {
                slider_review_footage.Enabled = true;
            }
            ResetButtonText();
            //DISABLE THE PICK VIDEO BUTTON
            //SO THE USER CAN NOT PICK ANOTHER VIDEO
            //WHILE THE CURRENT ONE IS STILL RUNNING
            pick_video_button.Enabled = true;
        }

        //RESETS NECESSARY BUTTON TEXTS TO DEFAULTS
        private void ResetButtonText()
        {
            pause_button.Text = "Pause";
        }

        //RETURNS THE REVIEW FOOTAGE IMAGE BOX
        public ImageBox GetReviewFootageImageBox()
        {
            return this.review_footage_image_box;
        }

        //RETURNS THE DETECTED FACES PANEL
        public Panel GetDetectedFacesPanel()
        {
            return panel_for_detected_faces;
        }

        public ColorSlider GetColorSlider() 
        {
            return review_footage_color_slider;
        }

        public Control GetControl(String name) 
        {
            switch (name)
            {
                case "time_elapsed":
                    return time_elapsed_label;
                case "total_time":
                    return total_time_label;
              
                case "review_image_box":
                    return review_footage_image_box;
                case "review_footage_imagebox":
                    return review_footage_image_box;
                case "live_stream_imagebox":
                    return imageBox4;
                case "detected_faces_panel":
                    return panel_for_detected_faces;
                
                   
            }
            return null;
        }

        public void DisplayAlertDetails(Perpetrator perp) 
        {
            PerpetratorDetailsForm form = new PerpetratorDetailsForm(perp,true);
            form.Show();
        }


        //HANDLES A CLICK EVENT IN THE REVIEW FOOTAGE BOX
        private void review_footage_image_box_Click(object sender, EventArgs e)
        {
            if (((DisplayUpdaterThread)ThreadManager.GetThread(ThreadFactory.DISPLAY_UPDATER)) != null)
            {
                if (review_footage_image_box.Image!=null)
                {
                    PauseVideo();
                    SelectPerpetratorForm form = new SelectPerpetratorForm((Image<Bgr, byte>)review_footage_image_box.Image);
                    form.Show();
                }
            }
        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog();
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            ChangeUserTypeDialog dialog = new ChangeUserTypeDialog();
            dialog.ShowDialog();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            AddStudentDialog dialog = new AddStudentDialog();
            dialog.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        // show add new user dialog on clicking addnew user dialog
        private void tile1_Click(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog(null);
        }
        // show dialog when add student tile is clicked
        private void metroTile2_Click(object sender, EventArgs e)
        {
            AddStudentDialog dialog = new AddStudentDialog();
            dialog.ShowDialog(null);
        }
        // show dialog when change user role tile is clicked
        private void metroTile4_Click(object sender, EventArgs e)
        {
            ChangeUserTypeDialog dialog = new ChangeUserTypeDialog();
            dialog.ShowDialog(null);
        }
        // show change login credentials dialog on clicking the change login credentials tile 
        private void metroTile1_Click(object sender, EventArgs e)
        {
            ChangeUserLoginDetailsForm form = new ChangeUserLoginDetailsForm();
            form.ShowDialog(null);
        }

        private void metroTabPage11_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            DashBoardDialog dashBoard = new DashBoardDialog();
            dashBoard.Visible = true;
            dashBoard.Show();
            
        }

        private void panel_for_detected_faces_Paint(object sender, PaintEventArgs e)
        {

        }

        private void turn_on_button_Click(object sender, EventArgs e)
        {
            ThreadManager.StopAllThreads();
            Singleton.ClearDataStores();
            ThreadManager.ReleaseAllThreadResources();
            StartLiveFootageThreads();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog(null);
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            PerpetratorsListDialog form = new PerpetratorsListDialog();
            form.ShowDialog(null);

        }




    }
}
