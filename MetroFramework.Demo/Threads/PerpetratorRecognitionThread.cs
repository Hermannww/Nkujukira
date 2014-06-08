using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class PerpetratorRecognitionThread:FaceRecognitionThread
    {
        //all active perpetrators
        private Perpetrator[] perpetrators = null;

        //global count of all alerts raised
        private static int count=0;

        //constructor
        public PerpetratorRecognitionThread(Image<Gray, byte> face_to_recognize) : base(face_to_recognize) 
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
            if (name_of_recognized_face != null)
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
            //split the name up using the ' ' char
            String[] items = name_of_recognized_face.Split(' ');

            //get the second item in the array which is the id of the perpetrator
            String id = items[1];

            //return the perpetrator associated with that id
            return PerpetratorsManager.GetPerpetrator(Convert.ToInt32(id));
        }
    }
}
