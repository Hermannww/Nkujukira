namespace MetroFramework.Demo.Views
{
    partial class AddStudentDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.year = new System.Windows.Forms.TextBox();
            this.month = new MetroFramework.Controls.MetroComboBox();
            this.date = new MetroFramework.Controls.MetroComboBox();
            this.photos = new MetroFramework.Controls.MetroComboBox();
            this.addImageFile = new MetroFramework.Controls.MetroButton();
            this.addStudent = new MetroFramework.Controls.MetroButton();
            this.lastName = new System.Windows.Forms.TextBox();
            this.gender = new MetroFramework.Controls.MetroComboBox();
            this.course = new System.Windows.Forms.TextBox();
            this.regNo = new System.Windows.Forms.TextBox();
            this.studentNo = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.year);
            this.panel1.Controls.Add(this.month);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.photos);
            this.panel1.Controls.Add(this.addImageFile);
            this.panel1.Controls.Add(this.addStudent);
            this.panel1.Controls.Add(this.lastName);
            this.panel1.Controls.Add(this.gender);
            this.panel1.Controls.Add(this.course);
            this.panel1.Controls.Add(this.regNo);
            this.panel1.Controls.Add(this.studentNo);
            this.panel1.Controls.Add(this.middleName);
            this.panel1.Controls.Add(this.firstName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 387);
            this.panel1.TabIndex = 0;
            // 
            // year
            // 
            this.year.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.Location = new System.Drawing.Point(325, 216);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(90, 30);
            this.year.TabIndex = 56;
            this.year.Text = "1990";
            // 
            // month
            // 
            this.month.FormattingEnabled = true;
            this.month.ItemHeight = 23;
            this.month.Items.AddRange(new object[] {
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
            this.month.Location = new System.Drawing.Point(256, 217);
            this.month.Name = "month";
            this.month.PromptText = "Jan";
            this.month.Size = new System.Drawing.Size(63, 29);
            this.month.TabIndex = 55;
            this.month.UseSelectable = true;
            // 
            // date
            // 
            this.date.FormattingEnabled = true;
            this.date.ItemHeight = 23;
            this.date.Items.AddRange(new object[] {
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
            this.date.Location = new System.Drawing.Point(171, 217);
            this.date.Name = "date";
            this.date.PromptText = "1";
            this.date.Size = new System.Drawing.Size(79, 29);
            this.date.TabIndex = 54;
            this.date.UseSelectable = true;
            // 
            // photos
            // 
            this.photos.AllowDrop = true;
            this.photos.FormattingEnabled = true;
            this.photos.ItemHeight = 23;
            this.photos.Location = new System.Drawing.Point(171, 283);
            this.photos.Name = "photos";
            this.photos.Size = new System.Drawing.Size(176, 29);
            this.photos.TabIndex = 53;
            this.photos.UseSelectable = true;
            // 
            // addImageFile
            // 
            this.addImageFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addImageFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addImageFile.Location = new System.Drawing.Point(348, 283);
            this.addImageFile.Name = "addImageFile";
            this.addImageFile.Size = new System.Drawing.Size(67, 29);
            this.addImageFile.TabIndex = 52;
            this.addImageFile.Text = "Add";
            this.addImageFile.UseSelectable = true;
            // 
            // addStudent
            // 
            this.addStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addStudent.Location = new System.Drawing.Point(225, 328);
            this.addStudent.Name = "addStudent";
            this.addStudent.Size = new System.Drawing.Size(122, 32);
            this.addStudent.TabIndex = 51;
            this.addStudent.Text = "Add";
            this.addStudent.UseSelectable = true;
            this.addStudent.Click += new System.EventHandler(this.addStudent_Click);
            // 
            // lastName
            // 
            this.lastName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName.Location = new System.Drawing.Point(171, 56);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(244, 26);
            this.lastName.TabIndex = 50;
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.ItemHeight = 23;
            this.gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gender.Location = new System.Drawing.Point(171, 248);
            this.gender.Name = "gender";
            this.gender.PromptText = "Male";
            this.gender.Size = new System.Drawing.Size(244, 29);
            this.gender.TabIndex = 49;
            this.gender.UseSelectable = true;
            // 
            // course
            // 
            this.course.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.Location = new System.Drawing.Point(171, 184);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(244, 26);
            this.course.TabIndex = 48;
            // 
            // regNo
            // 
            this.regNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regNo.Location = new System.Drawing.Point(171, 152);
            this.regNo.Name = "regNo";
            this.regNo.Size = new System.Drawing.Size(244, 26);
            this.regNo.TabIndex = 47;
            // 
            // studentNo
            // 
            this.studentNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNo.Location = new System.Drawing.Point(171, 122);
            this.studentNo.Name = "studentNo";
            this.studentNo.Size = new System.Drawing.Size(244, 26);
            this.studentNo.TabIndex = 46;
            // 
            // middleName
            // 
            this.middleName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleName.Location = new System.Drawing.Point(171, 90);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(244, 26);
            this.middleName.TabIndex = 45;
            // 
            // firstName
            // 
            this.firstName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName.Location = new System.Drawing.Point(171, 24);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(244, 26);
            this.firstName.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(65, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 43;
            this.label9.Text = "Photo (s)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(65, 249);
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
            this.label7.Location = new System.Drawing.Point(65, 220);
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
            this.label6.Location = new System.Drawing.Point(65, 191);
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
            this.label5.Location = new System.Drawing.Point(65, 159);
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
            this.label4.Location = new System.Drawing.Point(65, 129);
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
            this.label3.Location = new System.Drawing.Point(65, 95);
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
            this.label2.Location = new System.Drawing.Point(65, 63);
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
            this.label1.Location = new System.Drawing.Point(65, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "First Name";
            // 
            // AddStudentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 473);
            this.Controls.Add(this.panel1);
            this.Name = "AddStudentDialog";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Add Student";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.AddStudentDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox year;
        private Controls.MetroComboBox month;
        private Controls.MetroComboBox date;
        private Controls.MetroComboBox photos;
        private Controls.MetroButton addImageFile;
        private Controls.MetroButton addStudent;
        private System.Windows.Forms.TextBox lastName;
        private Controls.MetroComboBox gender;
        private System.Windows.Forms.TextBox course;
        private System.Windows.Forms.TextBox regNo;
        private System.Windows.Forms.TextBox studentNo;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}