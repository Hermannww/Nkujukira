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
using MetroFramework.Demo.Factories;
using Emgu.CV;
using Emgu.CV.Structure;

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

            try
            {

                String first_name = this.firstName.Text;
                String last_name = this.lastName.Text;
                String middle_name = this.middleName.Text;
                String student_no = this.studentNo.Text;
                String reg_no = this.regNo.Text;
                String course = this.course.Text;
                String dob = this.date.Text + "/" + this.month.Text + "/" + year.Text;
                String gender = this.gender.Text;
                Image<Gray,byte>[] photos = null;
                Student student = new Student(first_name, middle_name, last_name, student_no, reg_no, course, dob, gender, photos);

                if(first_name.Length<=0){
                    MetroMessageBox.Show(this, "Please Enter Your First Name", "ERROR");
                }else if(last_name.Length<=0){
                    MetroMessageBox.Show(this, "Please Enter Your Last Name", "ERROR");
                }else if(student_no.Length<=0){
                    MetroMessageBox.Show(this, "Please Enter Your Student Number", "ERROR");
                }else if(reg_no.Length<=0){
                    MetroMessageBox.Show(this, "Please Enter Your Registration Number", "ERROR");
                }
                else if (course.Length <= 0)
                {
                }
                else {

                    if (StudentsManager.Save(student))
                    {

                        MetroMessageBox.Show(this, "Student Added Successfully", "CONGRATULATIONS");
                    }
                    else
                    {
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
