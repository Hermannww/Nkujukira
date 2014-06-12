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
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class StudentRecognitionThread : FaceRecognitionThread
    {
        private Student[] students = null;

        //class variables that handle positioning of above controls
        private static volatile int x = 15;
        private static volatile int y = 50;

        public StudentRecognitionThread(Image<Gray, byte> face_to_recognize)
            : base(face_to_recognize)
        {
            students = StudentsManager.GetAllStudents();
            LoadPreviousTrainedFaces();
        }


        protected override void LoadPreviousTrainedFaces()
        {
            try
            {

                //Load of previus trainned faces and labels for each image
                string[] labels = GetNamesOfStudents(students);

                //get the number of labels
                num_labels = Convert.ToInt32(labels.Length);

                maximum_iteration = num_labels;


                for (int i = 0; i < students.Length; i++)
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
                    Label progress_label = new Label();
                    progress_label.Location = new Point(x + 133, y + 50);
                    progress_label.ForeColor = Color.Green;
                    progress_label.Text = "0%";

                    //create separator label
                    Label separator = new Label();
                    separator.Location = new Point(5, y + 132);
                    separator.AutoSize = false;
                    separator.Height = 2;
                    separator.Width = 335;
                    separator.BorderStyle = BorderStyle.Fixed3D;

                    //add picture boxes to panel in a thread safe way
                    Panel panel = (Panel)Singleton.MAIN_WINDOW.GetControl("review_footage_panel");
                    panel.Controls.Add(unknown_face_pictureBox);
                    panel.Controls.Add(perpetrators_pictureBox);
                    panel.Controls.Add(progress_label);
                    panel.Controls.Add(separator);

                    //create a new progress thread to show face recog progress
                    FaceRecognitionProgress progress = new FaceRecognitionProgress(this, perpetrators_pictureBox, progress_label);
                    progress.StartWorking();


                    y += 145;

                }
            }
        }
    }
}
