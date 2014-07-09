using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Controls;
using MetroFramework.Demo.Custom_Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class FaceRecognitionProgressThread : AbstractThread
    {
        //RESULT OF A FACE_RECOGNITION_RESULT
        FaceRecognitionResult face_recognition_result;

        //CONTROLS FOR DISPLAYING RESULTS
        protected MyPictureBox perpetrators_pictureBox  = null;
        protected MyPictureBox unknown_face_pictureBox  = null;

        protected Label separator                     = null;
        protected Label progress_label                = null;

        //CLASS VARIABLES THAT HANDLE POSITIONING OF CONTROLS
        private int x;
        private int y;

        //REF TO MAIN PANEL TO WHICH WE ADD CONTROLS
        Panel panel_live_stream                       = (Panel)Singleton.MAIN_WINDOW.GetControl("live_stream_panel");

        //MAXIMUM NUMBER OF CONTROLS THAT CAN BE SHOWN ON ABOVE PANEL BEFORE SCROLL BARS APPEAR
        private const int MAX_NUM_OF_CONTROLS_ALLOWED = 4;

        Perpetrator[] active_perpetrators;

        public static bool WORKDONE = false;

        public FaceRecognitionProgressThread()
            : base()
        {
            Debug.WriteLine("Progress Thread is starting");

            //GET ACTIVE PERPETRATORS
            active_perpetrators = Singleton.ACTIVE_PERPETRATORS;

            //SET X AND Y
            ResetXAndY();
        }

        private void ResetXAndY()
        {
            x = 15;
            y = 50;
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Progress Thread is running");
            while (running)
            {
                if (!paused)
                {

                    //DEQUEUE FACE RECOGNITION RESULT
                    //DISPLAY PROGRESS
                    //DISPLAY RESULTS OF RECOGNITIOM
                    //GENERATE ALARM IF RECOGNITION IS SUCESSFULL

                    bool sucessful = Singleton.FACE_RECOGNITION_RESULTS.TryDequeue(out face_recognition_result);

                    if (sucessful) 
                    {
                        active_perpetrators = Singleton.ACTIVE_PERPETRATORS;
                        DisplayFaceRecognitionProgress(face_recognition_result.original_detected_face);
                        GenerateAlarm();
                    }
                    else 
                    {
                        if (PerpetratorRecognitionThread.WORKDONE) 
                        {
                            running = false;
                            WORKDONE = true;
                            Debug.WriteLine("Terminating Progress thread");
                        }
                    }

                }
            }
        }

        public void DisplayFaceRecognitionProgress(Image<Gray, byte> face)
        {
            {
                //IF THERE ARE PERPETRATORS TO COMPARE AGAINIST
                if (active_perpetrators.Length != 0)
                {
                    //RESIZE THE FACE TO RECOGNIZE SO ITS EQUAL TO THE FACES ALREADY IN THE TRAINING SET
                    int width  = 120;
                    int height = 120;

                    face       = FramesManager.ResizeGrayImage(face, new Size(width, height));

                    //CLEAR PANEL IF ITEMS ARE TOO MANY
                    ClearPanelIfItemsAreMany();

                    //CREATE PICTURE BOX FOR FACE TO BE RECOGNIZED
                    unknown_face_pictureBox             = new MyPictureBox();
                    unknown_face_pictureBox.Location    = new Point(10, 10);
                    unknown_face_pictureBox.Size        = new Size(120, 120);
                    unknown_face_pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    unknown_face_pictureBox.Image       = face.ToBitmap();

                    //CREATE PICTURE BOX FOR PERPETRATORS
                    perpetrators_pictureBox             = new MyPictureBox();
                    perpetrators_pictureBox.Location    = new Point(185, 10);
                    perpetrators_pictureBox.Size        = new Size(120, 120);
                    perpetrators_pictureBox.BorderStyle = BorderStyle.FixedSingle;

                    //CREATE PROGRESS LABEL
                    progress_label                      = new Label();
                    progress_label.Location             = new Point(143, 60);
                    progress_label.ForeColor            = Color.Green;
                    progress_label.Text                 = "0%";

                    //CREATE PANEL CONTAINER FOR THE ABOVE CONTROLS
                    Panel panel                         = new Panel();
                    panel.AutoSize                      = true;
                    panel.Location                      = new Point(x, y);
                    panel.BorderStyle                   = BorderStyle.FixedSingle;
                    panel.Padding                       = new Padding(10);

                    panel.Controls.AddRange(new Control[] { unknown_face_pictureBox, perpetrators_pictureBox, progress_label });

                    //SINCE THIS THREAD IS STARTED OFF THE GUI THREAD THEN INVOKES MAY BE REQUIRED
                    if (panel_live_stream.InvokeRequired)
                    {
                        //ADD GUI CONTROLS USING INVOKES
                        Action action                   = () => panel_live_stream.Controls.Add(panel);
                        panel_live_stream.Invoke(action);
                    }

                    //IF NO INVOKES ARE NEEDED THEN
                    else
                    {
                        //JUST ADD THE CONTROLS
                        panel_live_stream.Controls.Add(panel);
                    }

                    //CREATE A NEW PROGRESS THREAD TO SHOW FACE RECOG PROGRESS
                    ShowFaceRecognitionProgress();

                    //INCREASE THE GLOBAL Y SO NEXT PIC BOXES ARE DRAWN BELOW THIS ONE
                    y += 145;

                }
            }
        }

        private void ClearPanelIfItemsAreMany()
        {
            //IF THE NUMBER OF CONTROLS ON MAIN PANEL EXCEEDS THOSE THAT CAN BE DRAWN WITHOUT SCROLLBARS
            if (panel_live_stream.Controls.Count > MAX_NUM_OF_CONTROLS_ALLOWED)
            {

                //CREATE TITLE LABEL
                MetroLabel title_label      = new MetroLabel();
                title_label.Theme           = MetroThemeStyle.Dark;
                title_label.ForeColor       = Color.White;
                title_label.AutoSize        = true;
                title_label.Font            = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                title_label.Location        = new System.Drawing.Point(68, 9);
                title_label.Name            = "label6";
                title_label.Size            = new System.Drawing.Size(212, 19);
                title_label.TabIndex        = 0;
                title_label.Text            = "FACE RECOGNITION PROGRESS";

                //CREATE LINE SEPARATOR 
                MetroLabel separator_label  = new MetroLabel();
                separator_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                separator_label.Location    = new System.Drawing.Point(-2, 28);
                separator_label.Name        = "label8";
                separator_label.Size        = new System.Drawing.Size(335, 2);
                separator_label.TabIndex    = 3;


                //COZ THIS IS NOT ON THE UI THREAD
                if (panel_live_stream.InvokeRequired)
                {
                    //CLEAR THE PANEL
                    Action action           = () => panel_live_stream.Controls.Clear();
                    panel_live_stream.Invoke(action);

                    //ADD TITLE AND SEPARATOR LINE TO PANEL
                    action                  = () => panel_live_stream.Controls.AddRange(new Control[] { title_label, separator_label });
                    panel_live_stream.Invoke(action);
                }

                //IF ON UI THREAD::HIGHLY UNLIKELY
                else
                {
                    //CLEAR THE PANEL
                    panel_live_stream.Controls.Clear();

                    //ADD TITLE AND SEPARATOR LINE TO PANEL
                    panel_live_stream.Controls.AddRange(new Control[] { title_label, separator_label });
                }

                //RESET THE X AND Y CODRDINATES FOR LOCATION OF CONTROLS
                ResetXAndY();
            }
        }

        private void ShowFaceRecognitionProgress()
        {
            //THIS KEEPS TRACK OF PROGRESS
            double progress_decimal = 1;

            //DISPLAY EACH OF PERPETRATORS' FACES IN THE PERPETRATORS PICTURE BOX FOR A FLEETING MOMEMNT;REPEAT TILL ALL FACES ARE DONE
            foreach (var perpetrator in active_perpetrators)
            {
                foreach (var face in perpetrator.faces)
                {
                    //GET THE AMOUNT OF WORK DONE                           PERPS.LENGTH*5 COZ EACH PERP HAS A MINIMUM OF 5 FACES
                    int percentage_completed = (int)(((progress_decimal / (active_perpetrators.Length * 5) * 100)));


                    //DISPLAY PERP FACE
                    SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());

                    if (percentage_completed >= 100)
                    {
                        if (face_recognition_result.match_was_found)
                        {
                            //UPDATE PROGRESS LABEL
                            progress_label.ForeColor = Color.Purple;
                            SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");

                            //DISPLAY IDENTIFIED PERPETRATORS FACE
                            SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face_recognition_result.identified_perpetrator.faces[0].ToBitmap());
                      
                        }
                        else
                        {
                            //UPDATE PROGRESS LABEL
                            progress_label.ForeColor = Color.Red;
                            SetControlPropertyThreadSafe(progress_label, "Text", "No\nMatch\nFound");
                        }

                       
                    }
                    else
                    {
                        //UPDATE PROGRESS LABEL
                        SetControlPropertyThreadSafe(progress_label, "Text", "" + percentage_completed + "%");
                    }

                    //LET THE THREAD SLEEP
                    Thread.Sleep(SLEEP_TIME);

                    progress_decimal++;
                }
            }
        }

        //GENERATES AN ALARM IF RECOGNITION IS SUCESSFULL
        protected void GenerateAlarm()
        {
            //IF THE RECOGNITION RETURNS A VALID NAME
            if (face_recognition_result.match_was_found)
            {              
                    //ADD THE ALERT TO THE GLOBALS WATCH LIST
                    Singleton.IDENTIFIED_PERPETRATORS.Enqueue(face_recognition_result.identified_perpetrator);
            }

        }

     
    }
}
