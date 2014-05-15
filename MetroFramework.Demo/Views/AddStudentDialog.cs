using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using MetroFramework.Demo.Managers;
using MetroFramework.Demo.Entitities;
using System.Collections;

namespace MetroFramework.Demo.Views
{
    public partial class AddStudentDialog : MetroForm
    {
        public AddStudentDialog()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
        }

        private void AddStudentDialog_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String file_name = null;
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                //dialog.Filter = FILE_FILTER;
                //dialog.Title = SELECT_VIDEO_MESSAGE;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    file_name = dialog.FileName;
                    photos.Items.Add(file_name);


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "Error from ADDIMAGEFILE");
            }
        }

        private void image_file_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addStudent_Click(object sender, EventArgs e)
        {

            // String[] photo_paths = new String[photos.Items.Count];

            try
            {

                String first_name = this.firstName.Text;
                String last_name = this.lastName.Text;
                String middle_name = this.middleName.Text;
                String student_no = this.studentNo.Text;
                String reg_no = this.regNo.Text;
                String course = this.course.Text;
                String dob = this.DOB.Text;
                String gender = this.gender.Text;
                StudentManager.createImageFolder(student_no);
                String path = StudentManager.IMAGES_FOLDER + student_no + @"\";
                bool savedToDB = new DatabaseManager().addStudent(new Student(first_name, middle_name, last_name, student_no, reg_no, course, dob, gender, path));
                if (savedToDB)
                {
                    int i = 0;
                    bool success = false;
                    foreach (String file_name in photos.Items)
                    {
                        i++;
                        success = false;
                        Image image = StudentManager.getImageFromFile(file_name);
                        bool savedToFile = StudentManager.saveImageToFile(image, path + i + ".JPG");
                        success = true;
                    }
                    if (success == true)
                    {
                        MetroMessageBox.Show(this, "Student Added Successfully", "CONGRATULATIONS");
                    }
                    else {
                        MetroMessageBox.Show(this, "Operation Not Successfully\n Please try again", "ERROR");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
