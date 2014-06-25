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
    public partial class StudentDetailsForm : MetroForm
    {
        List<Image<Gray, byte>> photos        = new List<Image<Gray, byte>>();
        private const string FILE_FILTER      = "Image Files (*.bmp, *.jpg, *.png,*.jpeg)|*.bmp;*.jpg;*.png;*.jpeg";
        private string SELECT_PICTURES_MESSAGE= "Please Select 5 pictures of the student";

        //constructor called when u want to gather student details
        public StudentDetailsForm()
        {
            InitializeComponent();
            label_status.Visible = false;
            combobox_gender.SelectedIndex = 0;
            combobox_day.SelectedIndex = 0;
            combobox_month.SelectedIndex = 0;
           
        }

        //constructor called when u want to display student details
        public StudentDetailsForm(Student student) 
        {
            InitializeComponent();
            SetStudentDetails(student);
            DisableControls();
        }

        private void DisableControls()
        {
            label_photos.Visible       = false;
            button_addphotos.Visible   = false;
            button_addStudent.Visible  = false;
            textbox_firstname.Enabled  = false;
            textbox_lastname.Enabled   = false;
            textbox_middlename.Enabled = false;
            textbox_studentno.Enabled  = false;
            textbox_regno.Enabled      = false;
            textbox_course.Enabled     = false;
            combobox_gender.Enabled    = false;
        }

        private void SetStudentDetails(Student student)
        {
            textbox_firstname.Text            = student.firstName;
            textbox_lastname.Text             = student.lastName;
            textbox_middlename.Text           = student.middleName;
            textbox_studentno.Text            = student.studentNo;
            textbox_regno.Text                = student.regNo;
            textbox_course.Text               = student.course;
            picturebox_studentPic.Image       = student.photos[0].ToBitmap();
            combobox_gender.SelectedIndex     = student.gender.Equals("Male") ? 0 : 1;
            label_status.Text                 = "Perpetrator has been identified as a student".ToUpper();

        }

       
        private void metroButton1_Click(object sender, EventArgs e)
        {
            String[] file_names       = null;
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter         = FILE_FILTER;
                dialog.Title          = SELECT_PICTURES_MESSAGE;
                dialog.Multiselect    = true;
                DialogResult result   = dialog.ShowDialog();

                if (result            == DialogResult.OK)
                {
                    file_names        = dialog.FileNames;

                    foreach (var file_name in file_names) 
                    {
                        photos.Add(new Image<Gray, byte>(file_name));
                    }


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "Error from ADDIMAGEFILE");
            }
        }



        private void addStudent_Click(object sender, EventArgs e)
        {

            try
            {

                String first_name  = this.textbox_firstname.Text;
                String last_name   = this.textbox_lastname.Text;
                String middle_name = this.textbox_middlename.Text;
                String student_no  = this.textbox_studentno.Text;
                String reg_no      = this.textbox_regno.Text;
                String course      = this.textbox_course.Text;
                String dob         = this.combobox_day.Text + "/" + this.combobox_month.Text + "/" +this.combobox_year.Text;
                String gender      = this.combobox_gender.Text; 

                if (String.IsNullOrEmpty(first_name) || String.IsNullOrEmpty(last_name) || String.IsNullOrEmpty(student_no) || String.IsNullOrEmpty(reg_no) || String.IsNullOrEmpty(course)||photos.Count<3)
                {

                    label_status.Visible   = true;
                    label_status.Text      = "Please fill in all the fields and pick atleast 5 pictures of the student:"+photos.Count();
                    return;
                }

                Student student            = new Student(first_name, middle_name, last_name, student_no, reg_no, course, dob, gender, photos.ToArray());

                if (StudentsManager.Save(student))
                {
                    label_status.Visible   = true;
                    label_status.Text      ="Student Added Successfully";
                }
                else
                {
                    label_status.Visible   = true;
                    label_status.Text      ="Operation Not Successfully\n Please try again";
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
