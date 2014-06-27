using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
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
    //THIS CLASS REPRESENTS A THREAD POLLS A SHARED DATASTORE FOR DETECTED FACES FROM FRAMES FROM CCTV
    //TO COMPARE AGAINIST THE FACES OF PERPETRATORS
    //IF RECOGNITION IS SUCCESSFULL AN ALERT IS GENERATED
    public class PerpetratorRecognitionThread:FaceRecognitionThread
    {
        //ARRAY OF ALL ACTIVE PERPETRATORS
        private Perpetrator[] perpetrators  = null;

        //CLASS VARIABLES THAT HANDLE POSITIONING OF CONTROLS
        private int x ;
        private int y ;

        //REF TO MAIN PANEL TO WHICH WE ADD CONTROLS
        Panel panel_live_stream = (Panel)Singleton.MAIN_WINDOW.GetControl("live_stream_panel");

        //MAXIMUM NUMBER OF CONTROLS THAT CAN BE SHOWN ON ABOVE PANEL BEFORE SCROLL BARS APPEAR
        private const int MAX_NUM_OF_CONTROLS_ALLOWED=4;

        //CONSTRUCTOR
        public PerpetratorRecognitionThread():base(null)
        {

            //GET ALL ACTIVE PERPETRATORS
            perpetrators                    = PerpetratorsManager.GetAllActivePerpetrators();

            //LOAD FACES OF PERPETRATORS
            LoadPreviousTrainedFaces();

            //SET X AND Y
            ResetXAndY();
        }

        private void ResetXAndY()
        {
            x = 15;
            y = 50;
        }

        //LOADS FACES OF PERPETRATORS FOR TRAINING OF THE NEURAL NETWORK
        protected override void LoadPreviousTrainedFaces()
        {
            try
            {

                //LOAD OF PREVIUS TRAINNED FACES AND LABELS FOR EACH IMAGE
                string[] labels             = GetNamesOfPerpetrators();

                //GET THE NUMBER OF LABELS
                num_labels                  = Convert.ToInt32(labels.Length);

                maximum_iteration           = num_labels;


                for (int i= 0; i < perpetrators.Length; i++)
                {
                    //ADD THE FACE
                    known_faces.AddRange(perpetrators[i].faces);

                    foreach (var face in perpetrators[i].faces)
                    {
                        //ADD THE NAME OF THE FACE
                        known_faces_labels.Add(labels[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (running) 
            {
                if (!paused) 
                {
                    //TRY DEQUEUEING A FACE TO RECOGNIZE FROM SHARED DATASTORE
                    bool sucessfull         = Singleton.FACES_TO_RECOGNIZE.TryDequeue(out face_to_recognize);

                    //IF DEQUEUE IS OK
                    if (sucessfull)
                    {
                        //TRY TO RECOGNIZE THE FACE
                        RecognizeFace(face_to_recognize);

                        //DISPLAY THE RECOGNITION PROGRESS
                        DisplayFaceRecognitionProgress();

                        //GENERATE ALARM
                        GenerateAlarm();
                    }
                }
            }
        }

        //GETS THE NAMES OF ALL ACTIVE PERPETRATORS IN ORDER AS STORED IN THE ARRAY
        private string[] GetNamesOfPerpetrators()
        {
            List<String> names              = new List<string>();

            //FOR EACH PERPETRATOR ADD THEIR NAMES TO THE LIST
            foreach (var perpetrator in perpetrators)
            {
                foreach (var face in perpetrator.faces)
                {
                    //ADD THE PERPETRATORS NAME AND ID TO THE LABELS LIST
                    names.Add(perpetrator.name +" "+ perpetrator.id);
                }
            }

            //RETURN ARRAY
            return names.ToArray();
        }


        //GENERATES AN ALARM IF RECOGNITION IS SUCESSFULL
        protected override void GenerateAlarm()
        {
            //IF THE RECOGNITION RETURNS A VALID NAME
            if (name_of_recognized_face != null && name_of_recognized_face.Length >= 3)
            {
                //GET THE PERPETRATOR ASSOCIATED WITH THE NAME
                Perpetrator identified_perp = GetIdentifiedPerp(name_of_recognized_face);

                if (!ThereIsSimilarAlert(identified_perp)) 
                {

                    //ADD THE ALERT TO THE GLOBALS WATCH LIST
                    Singleton.IDENTIFIED_PERPETRATORS.Enqueue(identified_perp);

                }   
                
            }
        }

        private bool ThereIsSimilarAlert(Perpetrator identified_perp)
        {
            return false;
        }


        //RETURNS THE PERPETRAOR ASSOCIATED WITH GIVEN NAME
        private Perpetrator GetIdentifiedPerp(string name_of_recognized_face)
        {
            if (name_of_recognized_face!=null&&name_of_recognized_face.Length>=3)
            {
                //SPLIT THE NAME UP USING THE ' ' CHAR
                String[] items              = name_of_recognized_face.Split(' ');

                //GET THE SECOND ITEM IN THE ARRAY WHICH IS THE ID OF THE PERPETRATOR
                String id                   = items[1];

                //RETURN THE PERPETRATOR ASSOCIATED WITH THAT ID
                return PerpetratorsManager.GetPerpetrator(Convert.ToInt32(id));
            }
            return null;
        }

        public void DisplayFaceRecognitionProgress()
        {
            {
                if (known_faces.Count() != 0)
                {
                    Debug.WriteLine("Y_POS=" + y);

                    //CLEAR PANEL IF ITEMS ARE TOO MANY
                    ClearPanelIfItemsAreMany();

                    //CREATE PICTURE BOX FOR FACE TO BE RECOGNIZED
                    unknown_face_pictureBox             = new PictureBox();
                    unknown_face_pictureBox.Location    = new Point(10, 10);
                    unknown_face_pictureBox.Size        = known_faces.ToArray()[0].Size;
                    unknown_face_pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    unknown_face_pictureBox.Image       = face_to_recognize.ToBitmap();

                    //CREATE PICTURE BOX FOR PERPETRATORS
                    perpetrators_pictureBox             = new PictureBox();
                    perpetrators_pictureBox.Location    = new Point(185, 10);
                    perpetrators_pictureBox.Size        = known_faces.ToArray()[0].Size;
                    perpetrators_pictureBox.BorderStyle = BorderStyle.Fixed3D;

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
                    panel.Padding = new Padding(10);
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

                    Debug.WriteLine("Y=" + y);

                    //INCREASE THE GLOBAL Y SO NEXT PIC BOXES ARE DRAWN BELOW THIS ONE
                    y = y + 145;

                }
            }    
        }

        private void ClearPanelIfItemsAreMany()
        {  
            //IF THE NUMBER OF CONTROLS ON MAIN PANEL EXCEEDS THOSE THAT CAN BE DRAWN WITHOUT SCROLLBARS
            if (panel_live_stream.Controls.Count > MAX_NUM_OF_CONTROLS_ALLOWED)
            {

                //CREATE TITLE LABEL
                MetroLabel title_label = new MetroLabel();
                title_label.Theme = MetroThemeStyle.Dark;
                title_label.ForeColor = Color.White;
                title_label.AutoSize = true;
                title_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                title_label.Location = new System.Drawing.Point(68, 9);
                title_label.Name = "label6";
                title_label.Size = new System.Drawing.Size(212, 19);
                title_label.TabIndex = 0;
                title_label.Text = "FACE RECOGNITION PROGRESS";

                //CREATE LINE SEPARATOR 
                MetroLabel separator_label = new MetroLabel();
                separator_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                separator_label.Location = new System.Drawing.Point(-2, 28);
                separator_label.Name = "label8";
                separator_label.Size = new System.Drawing.Size(335, 2);
                separator_label.TabIndex = 3;
                

                //COZ THIS IS NOT ON THE UI THREAD
                if (panel_live_stream.InvokeRequired)
                {
                    //CLEAR THE PANEL
                    Action action = () => panel_live_stream.Controls.Clear();
                    panel_live_stream.Invoke(action);

                    //ADD TITLE AND SEPARATOR LINE TO PANEL
                    action = () => panel_live_stream.Controls.AddRange(new Control[] { title_label, separator_label });
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

            //DISPLAY EACH OF HIS FACES IN THE PERPETRATORS PICTURE BOX FOR A FLEETING MOMEMNT;REPEAT TILL FACES ARE DONE
            foreach (var face in known_faces.ToArray())
            {
                //GET THE AMOUNT OF WORK DONE
                int percentage_completed = (int)(((progress_decimal / (known_faces.Count())) * 100));


                //DISPLAY PERP FACE
                SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());

                if (percentage_completed >= 100)
                {
                    if ((name_of_recognized_face != null && name_of_recognized_face.Length >= 3))
                    {
                        //UPDATE PROGRESS LABEL
                        progress_label.ForeColor = Color.Purple;
                        SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");
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
}
