namespace MetroFramework.Demo
{
    partial class PerpetratorDetailsForm
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
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_is_active = new System.Windows.Forms.TextBox();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.comboBox_is_a_student = new System.Windows.Forms.ComboBox();
            this.textBox_perpetrator_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.perpetrator_picture_box = new System.Windows.Forms.PictureBox();
            this.button_getCrimes = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_getCrimes);
            this.panel1.Controls.Add(this.comboBox_gender);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_is_active);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.comboBox_is_a_student);
            this.panel1.Controls.Add(this.textBox_perpetrator_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.perpetrator_picture_box);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(18, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 270);
            this.panel1.TabIndex = 0;
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox_gender.Location = new System.Drawing.Point(293, 147);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(208, 27);
            this.comboBox_gender.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(200, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Gender";
            // 
            // is_active_combo_box
            // 
            this.comboBox_is_active.Enabled = false;
            this.comboBox_is_active.Location = new System.Drawing.Point(293, 104);
            this.comboBox_is_active.Name = "is_active_combo_box";
            this.comboBox_is_active.Size = new System.Drawing.Size(208, 27);
            this.comboBox_is_active.TabIndex = 29;
            this.comboBox_is_active.Text = "Yes";
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(310, 205);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(171, 48);
            this.done_button.TabIndex = 27;
            this.done_button.Text = "Save";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // is_a_student_combo_box
            // 
            this.comboBox_is_a_student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_is_a_student.FormattingEnabled = true;
            this.comboBox_is_a_student.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox_is_a_student.Location = new System.Drawing.Point(293, 59);
            this.comboBox_is_a_student.Name = "is_a_student_combo_box";
            this.comboBox_is_a_student.Size = new System.Drawing.Size(208, 27);
            this.comboBox_is_a_student.TabIndex = 12;
            // 
            // perpetrator_name_textbox
            // 
            this.textBox_perpetrator_name.Location = new System.Drawing.Point(293, 13);
            this.textBox_perpetrator_name.Name = "perpetrator_name_textbox";
            this.textBox_perpetrator_name.Size = new System.Drawing.Size(208, 27);
            this.textBox_perpetrator_name.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(191, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Is Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(191, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Is A Student";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(191, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // perpetrator_picture_box
            // 
            this.perpetrator_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.perpetrator_picture_box.Location = new System.Drawing.Point(15, 13);
            this.perpetrator_picture_box.Name = "perpetrator_picture_box";
            this.perpetrator_picture_box.Size = new System.Drawing.Size(156, 156);
            this.perpetrator_picture_box.TabIndex = 0;
            this.perpetrator_picture_box.TabStop = false;
            // 
            // button_getCrimes
            // 
            this.button_getCrimes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_getCrimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_getCrimes.Location = new System.Drawing.Point(39, 205);
            this.button_getCrimes.Name = "button_getCrimes";
            this.button_getCrimes.Size = new System.Drawing.Size(181, 48);
            this.button_getCrimes.TabIndex = 32;
            this.button_getCrimes.Text = "Get Crimes Committed";
            this.button_getCrimes.UseSelectable = true;
            // 
            // PerpetratorDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 359);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "PerpetratorDetailsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Perpetrators Details";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.PerpetratorDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_picture_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox perpetrator_picture_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_is_a_student;
        private System.Windows.Forms.TextBox textBox_perpetrator_name;
        private Controls.MetroButton done_button;
        private System.Windows.Forms.TextBox comboBox_is_active;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label4;
        private Controls.MetroButton button_getCrimes;
    }
}