using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Threads
{
    public class StudentRecognitionThread : FaceRecognitionThread
    {
        private Student[] students  = null;

        public StudentRecognitionThread(Image<Gray, byte> face_to_recognize): base(face_to_recognize)
        {
            students                = StudentsManager.GetAllStudents();
            LoadPreviousTrainedFaces();
        }


        protected override void LoadPreviousTrainedFaces()
        {
            try
            {

                //Load of previus trainned faces and labels for each image
                string[] labels     = GetNamesOfStudents(students);

                //get the number of labels
                num_labels          = Convert.ToInt32(labels.Length);

                maximum_iteration   = num_labels;


                for (int i= 0; i < students.Length; i++)
                {
                    //add the face
                    known_faces.AddRange(students[i].photos);

                    foreach (var face in students[i].photos)
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

        private string[] GetNamesOfStudents(Student[] stuents)
        {
            //create names list
            List<String> names_list = new List<String>();

            //for each student add their name and std number to name lables
            foreach (var student in students)
            {
                names_list.Add(student.firstName + " " + student.lastName + " std_no: " + student.studentNo);
            }

            //return array of names
            return names_list.ToArray();
        }

        protected override void GenerateAlarm()
        {
            if (name_of_recognized_face != null)
            {
                //generate alarm
            }
        }
    }
}
