using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            //for each student add their name and id to name lables
            foreach (var student in students)
            {
                names_list.Add(student.firstName + " " + student.id);
            }

            //return array of names
            return names_list.ToArray();
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisplayFaceRecognitionProgress(x, y);
            y = y + 145;
        }

        protected override void GenerateAlarm()
        {
            //if face recognition returns a result
            if (name_of_recognized_face != null && name_of_recognized_face.Length >= 3)
            {
                //get the student who has been identified
                Student student = GetStudentIdentified(name_of_recognized_face);

                //if there is no alert already about the same student
                if (!ThereIsSimilarAlert(student))
                {
                    //add the alert to the globals watch list
                    Singleton.IDENTIFIED_STUDENTS.Enqueue(student);
                }
            }
        }


        private bool ThereIsSimilarAlert(Student student)
        {

            //else return false
            return false;
        }

        private Student GetStudentIdentified(string name_of_recognized_face)
        {
            //split the name returned up using the space char
            String[] parts = name_of_recognized_face.Split(' ');

            //get the second item in the array this should be the id
            int id = Convert.ToInt32(parts[1]);

            //get the student with the id
            return StudentsManager.GetStudent(id);
        }

        public override void DisplayFaceRecognitionProgress(int x_pos,int y_pos)
        {
            {
                if (known_faces.Count() != 0)
                {

                    //create picture box for face to be recognized
                    unknown_face_pictureBox = new PictureBox();
                    unknown_face_pictureBox.Location = new Point(x_pos, y_pos);
                    unknown_face_pictureBox.Size = known_faces.ToArray()[0].Size;
                    unknown_face_pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    unknown_face_pictureBox.Image = face_to_recognize.ToBitmap();

                    //create picture box for perpetrators
                    perpetrators_pictureBox = new PictureBox();
                    perpetrators_pictureBox.Location = new Point(x_pos + 170, y_pos);
                    perpetrators_pictureBox.Size = known_faces.ToArray()[0].Size;
                    perpetrators_pictureBox.BorderStyle = BorderStyle.Fixed3D;

                    //create Progress Label
                    Label progress_label = new Label();
                    progress_label.Location = new Point(x_pos + 133, y_pos + 50);
                    progress_label.ForeColor = Color.Green;
                    progress_label.Text = "0%";

                    //create separator label
                    Label separator = new Label();
                    separator.Location = new Point(5, y_pos + 132);
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

                }
            }
        }

        public class FaceRecognitionProgress : AbstractThread
        {

            private List<Image<Gray, byte>> known_faces;
            private PictureBox perp_picturebox;
            private Label progress_label;
            private Image<Gray, byte> current_face;
            private StudentRecognitionThread thread;

            public FaceRecognitionProgress(StudentRecognitionThread thread, PictureBox perp_picturebox, Label progress_label)
            {
                //initialize some variables
                this.known_faces = thread.known_faces;
                this.perp_picturebox = perp_picturebox;
                this.progress_label = progress_label;
                this.thread = thread;

                //initialize back ground worker
                background_worker = new BackgroundWorker();
                background_worker.WorkerReportsProgress = true;
                background_worker.WorkerSupportsCancellation = true;

                //set event handlers
                background_worker.DoWork += new DoWorkEventHandler(DoWork);
                background_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ThreadIsDone);


            }

            public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                //this keeps track of progress
                double i = 1;

                //display each of his faces in the perpetrators picture box for a fleeting momemnt;repeat till faces are done
                foreach (var face in known_faces.ToArray())
                {
                    //get the amount of work done
                    int percentage_completed = (int)(((i / (known_faces.Count())) * 100));

                    //make the current face global access
                    current_face = face;

                    //report progress
                    background_worker.ReportProgress(percentage_completed);

                    //let the thread sleep
                    Thread.Sleep(SLEEP_TIME);

                    i++;
                }
            }

            public override void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                //get percentage completed
                int percentage_completed = e.ProgressPercentage;


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
                //display perp facee
                SetControlPropertyThreadSafe(perp_picturebox, "Image", current_face.ToBitmap());




            }

            public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
            {
                thread.GenerateAlarm();
            }

        }
    }
}

