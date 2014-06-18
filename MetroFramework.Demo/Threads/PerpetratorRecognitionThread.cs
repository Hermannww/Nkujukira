using Emgu.CV;
using Emgu.CV.Structure;
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
    public class PerpetratorRecognitionThread:FaceRecognitionThread
    {
        //all active perpetrators
        private Perpetrator[] perpetrators = null;

        //class variables that handle positioning of above controls
        private static volatile int x = 15;
        private static volatile int y = 50;

        //global count of all alerts raised
        private static int count=0;

        

        //constructor
        public PerpetratorRecognitionThread():base(null)
        {
            
            //get all active perpetrators
            perpetrators           = PerpetratorsManager.GetAllActivePerpetrators();

            //load faces of perpetrators
            LoadPreviousTrainedFaces();
        }

        //loads faces of perpetrators for training of the neural network
        protected override void LoadPreviousTrainedFaces()
        {
            try
            {

                //Load of previus trainned faces and labels for each image
                string[] labels    = GetNamesOfPerpetrators();

                //get the number of labels
                num_labels         = Convert.ToInt32(labels.Length);

                maximum_iteration  = num_labels;


                for (int i= 0; i < perpetrators.Length; i++)
                {
                    //add the face
                    known_faces.AddRange(perpetrators[i].faces);

                    foreach (var face in perpetrators[i].faces)
                    {
                        //add the name of the face
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
                    Debug.WriteLine("Dequeueing datastore");
                    //try dequeueing a frame from shared datastore
                    bool sucessfull = Singleton.FACES_TO_RECOGNIZE.TryDequeue(out face_to_recognize);

                    //if dequeue is ok
                    if (sucessfull)
                    {
                        Debug.WriteLine("Recognizing face");
                        //try to recognize the face
                        RecognizeFace(face_to_recognize);

                        Debug.WriteLine("Displaying progress");
                        //display the recognition progress
                        DisplayFaceRecognitionProgress();

                        Debug.WriteLine("Generating Alarm");
                        //Generate Alarm
                        GenerateAlarm();
                    }
                }
            }
        }

        //gets the names of all active perpetrators as stored in the database
        private string[] GetNamesOfPerpetrators()
        {
            List<String> names     = new List<string>();

            //for each perpetrator add their names to the list
            foreach (var perpetrator in perpetrators)
            {
                foreach (var face in perpetrator.faces)
                {
                    //add the perpetrators name and id to the labels list
                    names.Add(perpetrator.name +" "+ perpetrator.id);
                }
            }

            //return array
            return names.ToArray();
        }


        //generates an alarm if recognition is sucessfull
        protected override void GenerateAlarm()
        {
            //if the recognition returns a name
            if (name_of_recognized_face != null && name_of_recognized_face.Length >= 3)
            {
                //get the perpetrator associated with the name
                Perpetrator identified_perp = GetIdentifiedPerp(name_of_recognized_face);

                if (!ThereIsSimilarAlert(identified_perp)) 
                {
                    //generate new alarm
                    AlertGenerationThread alert = new AlertGenerationThread(identified_perp);

                    //add the alert to the globals watch list
                    Singleton.ALL_ALERTS.TryAdd(count, alert);

                    //sound alarm
                    alert.StartWorking();

                    //increment the number of alerts
                    count++;
                }   
                
            }
        }

        private bool ThereIsSimilarAlert(Perpetrator perp)
        {
            //for each key value pair in the concurrent dictionary
            foreach (var key_value_pair in Singleton.ALL_ALERTS) 
            {
                //get the alert associated with the key
                AlertGenerationThread alert = key_value_pair.Value;

                //if the perpetrators in the alerts are the same then alerts are the same
                if (alert.IsAboutSamePerpetrator(perp)) 
                {
                    //return true
                    return true;
                }
            }

            //else return false
            return false;
        }

        

        //returns the perpetraor associated with given name
        private Perpetrator GetIdentifiedPerp(string name_of_recognized_face)
        {
            if (name_of_recognized_face!=null&&name_of_recognized_face.Length>=3)
            {
                //split the name up using the ' ' char
                String[] items = name_of_recognized_face.Split(' ');

                //get the second item in the array which is the id of the perpetrator
                String id = items[1];

                //return the perpetrator associated with that id
                return PerpetratorsManager.GetPerpetrator(Convert.ToInt32(id));
            }
            return null;
        }

        public override void DisplayFaceRecognitionProgress()
        {
            {
                if (known_faces.Count() != 0)
                {

                    //create picture box for face to be recognized
                    unknown_face_pictureBox = new PictureBox();
                    unknown_face_pictureBox.Location = new Point(x, y);
                    unknown_face_pictureBox.Size = known_faces.ToArray()[0].Size;
                    unknown_face_pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    unknown_face_pictureBox.Image = face_to_recognize.ToBitmap();

                    //create picture box for perpetrators
                    perpetrators_pictureBox = new PictureBox();
                    perpetrators_pictureBox.Location = new Point(x + 170, y);
                    perpetrators_pictureBox.Size = known_faces.ToArray()[0].Size;
                    perpetrators_pictureBox.BorderStyle = BorderStyle.Fixed3D;

                    //create Progress Label
                    progress_label = new Label();
                    progress_label.Location = new Point(x + 133, y + 50);
                    progress_label.ForeColor = Color.Green;
                    progress_label.Text = "0%";

                    //create separator label
                    separator = new Label();
                    separator.Location = new Point(5, y + 132);
                    separator.AutoSize = false;
                    separator.Height = 2;
                    separator.Width = 335;
                    separator.BorderStyle = BorderStyle.Fixed3D;

                    //add picture boxes to panel in a thread safe way
                    Panel panel = (Panel) Singleton.MAIN_WINDOW.GetControl("live_stream_panel");

                    //since this thread is started off the gui thread then invokes may be required
                    if (panel.InvokeRequired)
                    {
                        //add gui controls using invokes
                        Action action = () => panel.Controls.Add(unknown_face_pictureBox);
                        panel.Invoke(action);
                        action = () => panel.Controls.Add(perpetrators_pictureBox);
                        panel.Invoke(action);
                        action = () => panel.Controls.Add(progress_label);
                        panel.Invoke(action);
                        action = () => panel.Controls.Add(separator);
                        panel.Invoke(action);
                    }

                    //if no invokes are needed then
                    else
                    {
                        //just add the controls
                        panel.Controls.Add(unknown_face_pictureBox);
                        panel.Controls.Add(perpetrators_pictureBox);
                        panel.Controls.Add(progress_label);
                        panel.Controls.Add(separator);
                    }

                    //create a new progress thread to show face recog progress
                    ShowFaceRecognitionProgress(null);

                    y += 145;

                }
            }    
        }

        private void ShowFaceRecognitionProgress(object state)
        {
            //this keeps track of progress
            double i = 1;

            //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
            foreach (var face in known_faces.ToArray())
            {
                //get the amount of work done
                int percentage_completed = (int)(((i / (known_faces.Count())) * 100));


                //display perp facee
                SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face.ToBitmap());

                if (percentage_completed >= 100)
                {
                    if ((name_of_recognized_face != null && name_of_recognized_face.Length >= 3))
                    {
                        //update progress label
                        progress_label.ForeColor = Color.Purple;
                        SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");
                    }
                    else
                    {
                        //update progress label
                        progress_label.ForeColor = Color.Red;
                        SetControlPropertyThreadSafe(progress_label, "Text", "No\nMatch\nFound");
                    }
                }
                else 
                {        
                        //update progress label
                        SetControlPropertyThreadSafe(progress_label, "Text", "" + percentage_completed + "%");
                }

                //let the thread sleep
                Thread.Sleep(SLEEP_TIME);

                i++;
            }
        }


             
    }
}
