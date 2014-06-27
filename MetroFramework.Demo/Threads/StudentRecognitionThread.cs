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
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    public class StudentRecognitionThread : FaceRecognitionThread
    {
        //STUDENTS TO BE COMPARED AGAINIST
        private Student[] students                           = null;

        //CLASS VARIABLES THAT HANDLE POSITIONING OF CONTROLS
        private static volatile int x                        = 15;
        private static volatile int y                        = 50;


        //CONSTRUCTOR
        public StudentRecognitionThread(Image<Gray, byte> face_to_recognize)
            : base(face_to_recognize)
        {
            students                                         = StudentsManager.GetAllStudents();
            LoadPreviousTrainedFaces();
        }


        protected override void LoadPreviousTrainedFaces()
        {
            try
            {

                //LOAD OF PREVIUS TRAINNED FACES AND LABELS FOR EACH IMAGE
                string[] labels                              = GetNamesOfStudents(students);

                //GET THE NUMBER OF LABELS
                num_labels                                   = Convert.ToInt32(labels.Length);

                maximum_iteration                            = num_labels;


                for (int i                                   = 0; i < students.Length; i++)
                {
                    //ADD THE FACE
                    known_faces.AddRange(students[i].photos);

                    foreach (var face in students[i].photos)
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

        private string[] GetNamesOfStudents(Student[] stuents)
        {
            //CREATE NAMES LIST
            List<String> names_list                          = new List<String>();

            //FOR EACH STUDENT ADD THEIR NAME AND ID TO NAME LABLES
            foreach (var student in students)
            {
                names_list.Add(student.firstName + " " + student.id);
            }

            //RETURN NAMES AS ARRAY
            return names_list.ToArray();
        }

        public override void ThreadIsDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisplayFaceRecognitionProgress(x, y);
            y                                                = y + 145;
        }

        protected override void GenerateAlarm()
        {
            //IF FACE RECOGNITION RETURNS A RESULT
            if (name_of_recognized_face != null && name_of_recognized_face.Length >= 3)
            {
                //GET THE STUDENT WHO HAS BEEN IDENTIFIED
                Student student                              = GetStudentIdentified(name_of_recognized_face);

                //IF THERE IS NO ALERT ALREADY ABOUT THE SAME STUDENT
                if (!ThereIsSimilarAlert(student))
                {
                    //ADD THE ALERT TO THE GLOBALS WATCH LIST
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
            //SPLIT THE NAME RETURNED UP USING THE SPACE CHAR
            String[] parts                                   = name_of_recognized_face.Split(' ');

            //GET THE SECOND ITEM IN THE ARRAY THIS SHOULD BE THE ID
            int id                                           = Convert.ToInt32(parts[1]);

            //GET THE STUDENT WITH THE ID
            return StudentsManager.GetStudent(id);
        }

        public override void DisplayFaceRecognitionProgress(int x_pos,int y_pos)
        {
            {
                if (known_faces.Count() != 0)
                {

                    //CREATE PICTURE BOX FOR FACE TO BE RECOGNIZED
                    unknown_face_pictureBox                  = new PictureBox();
                    unknown_face_pictureBox.Location         = new Point(x_pos, y_pos);
                    unknown_face_pictureBox.Size             = known_faces.ToArray()[0].Size;
                    unknown_face_pictureBox.BorderStyle      = BorderStyle.Fixed3D;
                    unknown_face_pictureBox.Image            = face_to_recognize.ToBitmap();

                    //CREATE PICTURE BOX FOR PERPETRATORS
                    perpetrators_pictureBox                  = new PictureBox();
                    perpetrators_pictureBox.Location         = new Point(x_pos + 170, y_pos);
                    perpetrators_pictureBox.Size             = known_faces.ToArray()[0].Size;
                    perpetrators_pictureBox.BorderStyle      = BorderStyle.Fixed3D;

                    //CREATE PROGRESS LABEL
                    Label progress_label                     = new Label();
                    progress_label.Location                  = new Point(x_pos + 133, y_pos + 50);
                    progress_label.ForeColor                 = Color.Green;
                    progress_label.Text                      = "0%";

                    //CREATE SEPARATOR LABEL
                    Label separator                          = new Label();
                    separator.Location                       = new Point(5, y_pos + 132);
                    separator.AutoSize                       = false;
                    separator.Height                         = 2;
                    separator.Width                          = 335;
                    separator.BorderStyle                    = BorderStyle.Fixed3D;

                    //ADD CONTROLS TO PANEL IN A THREAD SAFE WAY
                    Panel panel                              = (Panel)Singleton.MAIN_WINDOW.GetControl("review_footage_panel");
                    panel.Controls.Add(unknown_face_pictureBox);
                    panel.Controls.Add(perpetrators_pictureBox);
                    panel.Controls.Add(progress_label);
                    panel.Controls.Add(separator);

                    //CREATE A NEW PROGRESS THREAD TO SHOW FACE RECOG PROGRESS
                    FaceRecognitionProgress progress         = new FaceRecognitionProgress(this, perpetrators_pictureBox, progress_label);
                    progress.StartWorking();

                }
            }
        }

        public class FaceRecognitionProgress : AbstractThread
        {

            private List<Image<Gray, byte>> known_faces;
            private PictureBox students_picturebox;
            private Label progress_label;
            private Image<Gray, byte> current_face;
            private StudentRecognitionThread thread;

            public FaceRecognitionProgress(StudentRecognitionThread thread, PictureBox perp_picturebox, Label progress_label)
            {
                //INITIALIZE SOME VARIABLES
                this.known_faces                             = thread.known_faces;
                this.students_picturebox                         = perp_picturebox;
                this.progress_label                          = progress_label;
                this.thread                                  = thread;

                //INITIALIZE BACKGROUND WORKER
                background_worker                            = new BackgroundWorker();
                background_worker.WorkerReportsProgress      = true;
                background_worker.WorkerSupportsCancellation = true;

                //SET EVENT HANDLERS
                background_worker.DoWork += new DoWorkEventHandler(DoWork);
                background_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                background_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ThreadIsDone);


            }

            public override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                //THIS KEEPS TRACK OF PROGRESS
                double progress_decimal                                     = 1;

                //DISPLAY EACH OF HIS FACES IN THE PERPETRATORS PICTURE BOX FOR A FLEETING MOMEMNT;REPEAT TILL FACES ARE DONE
                foreach (var face in known_faces.ToArray())
                {
                    //GET THE AMOUNT OF WORK DONE
                    int percentage_completed                 = (int)(((progress_decimal / (known_faces.Count())) * 100));

                    //MAKE THE CURRENT FACE GLOBAL ACCESS
                    current_face                             = face;

                    //REPORT PROGRESS
                    background_worker.ReportProgress(percentage_completed);

                    //LET THE THREAD SLEEP
                    Thread.Sleep(SLEEP_TIME);

                    progress_decimal++;
                }
            }

            public override void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                //GET PERCENTAGE COMPLETED
                int percentage_completed                     = e.ProgressPercentage;


                if (percentage_completed >= 100)
                {
                    if ((name_of_recognized_face != null && name_of_recognized_face.Length >= 3))
                    {
                        //UPDATE PROGRESS LABEL
                        progress_label.ForeColor             = Color.Purple;
                        SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");
                    }
                    else
                    {
                        //UPDATE PROGRESS LABEL
                        progress_label.ForeColor             = Color.Red;
                        SetControlPropertyThreadSafe(progress_label, "Text", "No\nMatch\nFound");
                    }
                }
                else
                {
                    //UPDATE PROGRESS LABEL
                    SetControlPropertyThreadSafe(progress_label, "Text", "" + percentage_completed + "%");
                }

                //DISPLAY PERP FACEE
                SetControlPropertyThreadSafe(students_picturebox, "Image", current_face.ToBitmap());




            }

            public override void ThreadIsDone(object sender, RunWorkerCompletedEventArgs e)
            {
                //GENERATE AN ALARM IF A PERP HAS BEEN IDENTIFIED
                thread.GenerateAlarm();
            }

        }
    }
}

