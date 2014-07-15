using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Custom_Controls;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Singletons;
using Nkujukira;
using ProgressControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.Demo.Threads
{
    //THIS THREAD ATTEMPTS TO RECOGNIZE A PERPETRATOR OF A CRIME FROM THE STUDENTS REG DATABASE
    public class StudentRecognitionThread : FaceRecognitionThread
    {
        //CONTROLS FOR DISPLAYING RESULTS
        protected MyPictureBox perpetrators_pictureBox = null;
        protected MyPictureBox unknown_face_pictureBox = null;

        protected Label separator = null;
        protected Label progress_label = null;

        //ADD CONTROLS TO PANEL IN A THREAD SAFE WAY
        Panel panel_review_stream = (Panel)Singleton.MAIN_WINDOW.GetControl("review_footage_panel");

        //STUDENTS TO BE COMPARED AGAINIST
        private Student[] students = null;

        //CLASS VARIABLES THAT HANDLE POSITIONING OF CONTROLS
        private int x = 15;
        private int y = 40;

        //RESULT OF FACE RECOGNITION OPERATION
        private FaceRecognitionResult face_recognition_result = null;

        private List<Image<Gray, byte>> faces_to_recognize = new List<Image<Gray, byte>>();

        private FacesManager faces_manager;
        public static bool WORK_DONE=false;

        //CONSTRUCTOR
        public StudentRecognitionThread(Image<Gray, byte>[] faces_to_recognize)
            : base(null)
        {
            running            = true;
            paused             = false;
            WORK_DONE = false;
            this.faces_manager = new FacesManager();

            this.faces_to_recognize.AddRange(faces_to_recognize);

            //GET ALL STUDENTS
            students           = StudentsManager.GetAllStudents();

            //ENROLL STUDENT FACES
            EnrollFacesToBeComparedAgainst();

        }

        //THIS ENROLS STUDENT FACES FOR LATER COMPARISON 
        protected override void EnrollFacesToBeComparedAgainst()
        {
            //FOR EACH ACTIVE PERPETRATOR ENROLL HIS FACE SO IT CAN BE USED FOR COMPARISON
            foreach (var student in students)
            {
                faces_manager.EnrollFaces(student);
            }
        }

        protected override void RecognizeFace(Image<Gray, byte> face)
        {

            if (students.Length != 0)
            {

                //RESIZE THE FACE TO RECOGNIZE SO ITS EQUAL TO THE FACES ALREADY IN THE TRAINING SET
                int width               = 120;
                int height              = 120;

                face                    = FramesManager.ResizeGrayImage(face, new Size(width, height));

                //ATTEMPT TO RECOGNIZE THE PERPETRATOR
                face_recognition_result = faces_manager.MatchFace(face);

                //IF A VALID ID IS RETURMED
                if (face_recognition_result.match_was_found)
                {
                    //GET STUDENT ASSOCIATED WITH ID
                    foreach (var student in students)
                    {
                        if (student.id == face_recognition_result.id)
                        {
                            face_recognition_result.identified_student = student;
                            break;
                        }
                    }
                }

                return;
            }
        }

        //THIS  THREAD RECOGNIZES A FACE IN THE BACKGROUND
        public override void DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("Student Recognition Thread Starting");

            Debug.WriteLine("Count = " + faces_to_recognize.Count);
            if (!paused)
            {
                //STOP SHOWING THE PROGRESS INDICATOR 
                DisableSpinningProgressIndicator();

                //GET ALL FACES TO BE RECOGNIZED
                List<Image<Gray, byte>>.Enumerator enumerator = faces_to_recognize.GetEnumerator();

                //LOOP THRU ALL FACES TO RECOGNIZE
                while (enumerator.MoveNext())
                {
                    Debug.WriteLine("Student Recognition Thread running");
                    face_to_recognize = enumerator.Current;

                    //RECOGNIZE THE FACE
                    RecognizeFace(face_to_recognize);

                    //DISPLAY PROGRESS OF THE RECOGNITION OPERATION
                    DisplayFaceRecognitionProgress();

                    //GENERATE AN ALARM IF RECOGNITION IS SUCESSFUL
                    GenerateAlarm();

                    //TURN ON ALERT THREAD
                    ThreadFactory.GetThread(ThreadFactory.STUDENT_ALERT_THREAD).Resume();
                }
               
            }

            CleanUp();


        }

        private void CleanUp()
        {
            WORK_DONE = true;
            faces_manager.ClearEnrolledFaces();
            faces_manager = null;

        }

        private void DisableSpinningProgressIndicator()
        {
            Singleton.MAIN_WINDOW.EnableReviewControls();
        }



        //GENERATES AN ALARM IF FACE RECOGNITION IS SUCESSFULL
        protected void GenerateAlarm()
        {
            //IF FACE RECOGNITION RETURNS A RESULT
            if (face_recognition_result.match_was_found)
            {
                //IF THERE IS NO ALERT ALREADY ABOUT THE SAME STUDENT
                
                //ADD THE ALERT TO THE GLOBALS WATCH LIST
                Singleton.IDENTIFIED_STUDENTS.Enqueue(face_recognition_result.identified_student);
            }
        }


        private void ShowFaceRecognitionProgress()
        {
            //THIS KEEPS TRACK OF PROGRESS
            double progress_decimal                  = 1;

            //DISPLAY EACH OF PERPETRATORS' FACES IN THE PERPETRATORS PICTURE BOX FOR A FLEETING MOMEMNT;REPEAT TILL ALL FACES ARE DONE
            foreach (var student in students)
            {
                for (int i                           = 0; i < student.photos.Length; i++)
                {
                    //GET THE AMOUNT OF WORK DONE                           PERPS.LENGTH*5 COZ EACH PERP HAS A MINIMUM OF 5 FACES
                    int percentage_completed         = (int)(((progress_decimal / (students.Length * 5) * 100)));

                    //RESIZE THE FACE TO RECOGNIZE SO ITS EQUAL TO THE FACES ALREADY IN THE TRAINING SET
                    int width                        = 120;
                    int height                       = 120;

                    student.photos[i]                = FramesManager.ResizeGrayImage(student.photos[i], new Size(width, height));

                    //DISPLAY STUDENT FACE
                    SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", student.photos[i].ToBitmap());

                    if (percentage_completed >= 100)
                    {
                        if (face_recognition_result.match_was_found)
                        {
                            //UPDATE PROGRESS LABEL
                            progress_label.ForeColor = Color.Purple;
                            SetControlPropertyThreadSafe(progress_label, "Text", "Match\nFound");

                            //DISPLAY IDENTIFIED STUDENT FACE
                            SetControlPropertyThreadSafe(perpetrators_pictureBox, "Image", face_recognition_result.identified_student.photos[0].ToBitmap());
                      
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

      


        protected void DisplayFaceRecognitionProgress()
        {
            {
                if (students.Length != 0)
                {

                    //CREATE PICTURE BOX FOR FACE TO BE RECOGNIZED
                    unknown_face_pictureBox             = new MyPictureBox();
                    unknown_face_pictureBox.Location    = new Point(10, 10);
                    unknown_face_pictureBox.Size        = new Size(120, 120);
                    unknown_face_pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    unknown_face_pictureBox.Image       = face_to_recognize.ToBitmap();

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
                    if (panel_review_stream.InvokeRequired)
                    {
                        //ADD GUI CONTROLS USING INVOKES
                        Action action = () => panel_review_stream.Controls.Add(panel);
                        panel_review_stream.Invoke(action);
                    }

                    //IF NO INVOKES ARE NEEDED THEN
                    else
                    {
                        //JUST ADD THE CONTROLS
                        panel_review_stream.Controls.Add(panel);
                    }



                    ShowFaceRecognitionProgress();

                    y += 145;
                }
            }
        }

    }
}

