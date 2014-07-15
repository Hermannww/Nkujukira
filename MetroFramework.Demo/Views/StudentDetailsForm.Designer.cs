using MetroFramework.Demo.Custom_Controls;
namespace MetroFramework.Demo.Views
{
    partial class StudentDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDetailsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picturebox_studentPic = new MetroFramework.Demo.Custom_Controls.MyPictureBox();
            this.label_status = new System.Windows.Forms.Label();
            this.combobox_year = new System.Windows.Forms.TextBox();
            this.combobox_month = new MetroFramework.Controls.MetroComboBox();
            this.combobox_day = new MetroFramework.Controls.MetroComboBox();
            this.button_addphotos = new MetroFramework.Controls.MetroButton();
            this.button_addStudent = new MetroFramework.Controls.MetroButton();
            this.textbox_lastname = new System.Windows.Forms.TextBox();
            this.combobox_gender = new MetroFramework.Controls.MetroComboBox();
            this.textbox_course = new System.Windows.Forms.TextBox();
            this.textbox_regno = new System.Windows.Forms.TextBox();
            this.textbox_studentno = new System.Windows.Forms.TextBox();
            this.textbox_middlename = new System.Windows.Forms.TextBox();
            this.textbox_firstname = new System.Windows.Forms.TextBox();
            this.label_photos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_studentPic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picturebox_studentPic);
            this.panel1.Controls.Add(this.label_status);
            this.panel1.Controls.Add(this.combobox_year);
            this.panel1.Controls.Add(this.combobox_month);
            this.panel1.Controls.Add(this.combobox_day);
            this.panel1.Controls.Add(this.button_addphotos);
            this.panel1.Controls.Add(this.button_addStudent);
            this.panel1.Controls.Add(this.textbox_lastname);
            this.panel1.Controls.Add(this.combobox_gender);
            this.panel1.Controls.Add(this.textbox_course);
            this.panel1.Controls.Add(this.textbox_regno);
            this.panel1.Controls.Add(this.textbox_studentno);
            this.panel1.Controls.Add(this.textbox_middlename);
            this.panel1.Controls.Add(this.textbox_firstname);
            this.panel1.Controls.Add(this.label_photos);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 548);
            this.panel1.TabIndex = 0;
            // 
            // picturebox_studentPic
            // 
            this.picturebox_studentPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturebox_studentPic.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_studentPic.Image")));
            this.picturebox_studentPic.Location = new System.Drawing.Point(170, 8);
            this.picturebox_studentPic.Name = "picturebox_studentPic";
            this.picturebox_studentPic.Size = new System.Drawing.Size(132, 132);
            this.picturebox_studentPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_studentPic.TabIndex = 58;
            this.picturebox_studentPic.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_status.Location = new System.Drawing.Point(31, 148);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(57, 19);
            this.label_status.TabIndex = 57;
            this.label_status.Text = "label10";
            // 
            // combobox_year
            // 
            this.combobox_year.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_year.Location = new System.Drawing.Point(254, 373);
            this.combobox_year.Name = "combobox_year";
            this.combobox_year.Size = new System.Drawing.Size(58, 30);
            this.combobox_year.TabIndex = 56;
            this.combobox_year.Text = "1990";
            // 
            // combobox_month
            // 
            this.combobox_month.FormattingEnabled = true;
            this.combobox_month.ItemHeight = 23;
            this.combobox_month.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "April",
            "May",
            "June",
            "July",
            "Aug",
            "Sept",
            "Oct",
            "Nov",
            "Dec"});
            this.combobox_month.Location = new System.Drawing.Point(190, 374);
            this.combobox_month.Name = "combobox_month";
            this.combobox_month.PromptText = "Jan";
            this.combobox_month.Size = new System.Drawing.Size(58, 29);
            this.combobox_month.TabIndex = 55;
            this.combobox_month.UseSelectable = true;
            // 
            // combobox_day
            // 
            this.combobox_day.FormattingEnabled = true;
            this.combobox_day.ItemHeight = 23;
            this.combobox_day.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.combobox_day.Location = new System.Drawing.Point(127, 374);
            this.combobox_day.Name = "combobox_day";
            this.combobox_day.PromptText = "1";
            this.combobox_day.Size = new System.Drawing.Size(57, 29);
            this.combobox_day.TabIndex = 54;
            this.combobox_day.UseSelectable = true;
            // 
            // button_addphotos
            // 
            this.button_addphotos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_addphotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addphotos.Location = new System.Drawing.Point(127, 444);
            this.button_addphotos.Name = "button_addphotos";
            this.button_addphotos.Size = new System.Drawing.Size(185, 29);
            this.button_addphotos.TabIndex = 52;
            this.button_addphotos.Text = "Add Pictures";
            this.button_addphotos.UseSelectable = true;
            this.button_addphotos.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // button_addStudent
            // 
            this.button_addStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_addStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addStudent.Location = new System.Drawing.Point(127, 488);
            this.button_addStudent.Name = "button_addStudent";
            this.button_addStudent.Size = new System.Drawing.Size(331, 50);
            this.button_addStudent.TabIndex = 51;
            this.button_addStudent.Text = "Create Student";
            this.button_addStudent.UseSelectable = true;
            this.button_addStudent.Click += new System.EventHandler(this.addStudent_Click);
            // 
            // textbox_lastname
            // 
            this.textbox_lastname.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_lastname.Location = new System.Drawing.Point(127, 214);
            this.textbox_lastname.Name = "textbox_lastname";
            this.textbox_lastname.Size = new System.Drawing.Size(331, 26);
            this.textbox_lastname.TabIndex = 50;
            // 
            // combobox_gender
            // 
            this.combobox_gender.FormattingEnabled = true;
            this.combobox_gender.ItemHeight = 23;
            this.combobox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.combobox_gender.Location = new System.Drawing.Point(127, 409);
            this.combobox_gender.Name = "combobox_gender";
            this.combobox_gender.PromptText = "Male";
            this.combobox_gender.Size = new System.Drawing.Size(121, 29);
            this.combobox_gender.TabIndex = 49;
            this.combobox_gender.UseSelectable = true;
            // 
            // textbox_course
            // 
            this.textbox_course.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_course.Location = new System.Drawing.Point(127, 342);
            this.textbox_course.Name = "textbox_course";
            this.textbox_course.Size = new System.Drawing.Size(331, 26);
            this.textbox_course.TabIndex = 48;
            // 
            // textbox_regno
            // 
            this.textbox_regno.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_regno.Location = new System.Drawing.Point(127, 310);
            this.textbox_regno.Name = "textbox_regno";
            this.textbox_regno.Size = new System.Drawing.Size(331, 26);
            this.textbox_regno.TabIndex = 47;
            // 
            // textbox_studentno
            // 
            this.textbox_studentno.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_studentno.Location = new System.Drawing.Point(127, 278);
            this.textbox_studentno.Name = "textbox_studentno";
            this.textbox_studentno.Size = new System.Drawing.Size(331, 26);
            this.textbox_studentno.TabIndex = 46;
            // 
            // textbox_middlename
            // 
            this.textbox_middlename.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_middlename.Location = new System.Drawing.Point(127, 246);
            this.textbox_middlename.Name = "textbox_middlename";
            this.textbox_middlename.Size = new System.Drawing.Size(331, 26);
            this.textbox_middlename.TabIndex = 45;
            // 
            // textbox_firstname
            // 
            this.textbox_firstname.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_firstname.Location = new System.Drawing.Point(127, 182);
            this.textbox_firstname.Name = "textbox_firstname";
            this.textbox_firstname.Size = new System.Drawing.Size(331, 26);
            this.textbox_firstname.TabIndex = 44;
            // 
            // label_photos
            // 
            this.label_photos.AutoSize = true;
            this.label_photos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_photos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_photos.Location = new System.Drawing.Point(21, 445);
            this.label_photos.Name = "label_photos";
            this.label_photos.Size = new System.Drawing.Size(67, 19);
            this.label_photos.TabIndex = 43;
            this.label_photos.Text = "Photo (s)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(21, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(21, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "DOB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(21, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Course";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(21, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Reg No/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(21, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 38;
            this.label4.Text = "Student No/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(21, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 37;
            this.label3.Text = "Middle Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(21, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 36;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(21, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "First Name";
            // 
            // StudentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 615);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentDetailsForm";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Student";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentDetailsForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_studentPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox combobox_year;
        private Controls.MetroComboBox combobox_month;
        private Controls.MetroComboBox combobox_day;
        private Controls.MetroButton button_addphotos;
        private Controls.MetroButton button_addStudent;
        private System.Windows.Forms.TextBox textbox_lastname;
        private Controls.MetroComboBox combobox_gender;
        private System.Windows.Forms.TextBox textbox_course;
        private System.Windows.Forms.TextBox textbox_regno;
        private System.Windows.Forms.TextBox textbox_studentno;
        private System.Windows.Forms.TextBox textbox_middlename;
        private System.Windows.Forms.TextBox textbox_firstname;
        private System.Windows.Forms.Label label_photos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_status;
        private MyPictureBox picturebox_studentPic;

    }
}