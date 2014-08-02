using Nkujukira.Demo.Custom_Controls;
namespace Nkujukira.Demo
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
            this.button_is_apprehended = new MetroFramework.Controls.MetroButton();
            this.button_getCrimes = new MetroFramework.Controls.MetroButton();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_is_active = new System.Windows.Forms.TextBox();
            this.button_save = new MetroFramework.Controls.MetroButton();
            this.comboBox_is_a_student = new System.Windows.Forms.ComboBox();
            this.textBox_perpetrator_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.perpetrator_picture_box = new Nkujukira.Demo.Custom_Controls.MyPictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_is_apprehended);
            this.panel1.Controls.Add(this.button_getCrimes);
            this.panel1.Controls.Add(this.comboBox_gender);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_is_active);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.comboBox_is_a_student);
            this.panel1.Controls.Add(this.textBox_perpetrator_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.perpetrator_picture_box);
            this.panel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(14, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 270);
            this.panel1.TabIndex = 0;
            // 
            // button_is_apprehended
            // 
            this.button_is_apprehended.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_is_apprehended.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_is_apprehended.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_is_apprehended.ForeColor = System.Drawing.Color.Black;
            this.button_is_apprehended.Location = new System.Drawing.Point(155, 205);
            this.button_is_apprehended.Name = "button_is_apprehended";
            this.button_is_apprehended.Size = new System.Drawing.Size(171, 48);
            this.button_is_apprehended.TabIndex = 33;
            this.button_is_apprehended.Text = "Has Been Apprehended";
            this.button_is_apprehended.UseSelectable = true;
            this.button_is_apprehended.Click += new System.EventHandler(this.is_apprehended_button_Click);
            // 
            // button_getCrimes
            // 
            this.button_getCrimes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_getCrimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_getCrimes.Location = new System.Drawing.Point(15, 205);
            this.button_getCrimes.Name = "button_getCrimes";
            this.button_getCrimes.Size = new System.Drawing.Size(134, 48);
            this.button_getCrimes.TabIndex = 32;
            this.button_getCrimes.Text = "Crimes Committed";
            this.button_getCrimes.UseSelectable = true;
            this.button_getCrimes.Click += new System.EventHandler(this.button_getCrimes_Click);
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
            this.label4.Location = new System.Drawing.Point(191, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Gender";
            // 
            // comboBox_is_active
            // 
            this.comboBox_is_active.Enabled = false;
            this.comboBox_is_active.Location = new System.Drawing.Point(293, 104);
            this.comboBox_is_active.Name = "comboBox_is_active";
            this.comboBox_is_active.Size = new System.Drawing.Size(208, 27);
            this.comboBox_is_active.TabIndex = 29;
            this.comboBox_is_active.Text = "Yes";
            // 
            // button_save
            // 
            this.button_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.Location = new System.Drawing.Point(332, 205);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(149, 48);
            this.button_save.TabIndex = 27;
            this.button_save.Text = "Save";
            this.button_save.UseSelectable = true;
            this.button_save.Click += new System.EventHandler(this.save_button_Click);
            // 
            // comboBox_is_a_student
            // 
            this.comboBox_is_a_student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_is_a_student.FormattingEnabled = true;
            this.comboBox_is_a_student.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox_is_a_student.Location = new System.Drawing.Point(293, 59);
            this.comboBox_is_a_student.Name = "comboBox_is_a_student";
            this.comboBox_is_a_student.Size = new System.Drawing.Size(208, 27);
            this.comboBox_is_a_student.TabIndex = 12;
            // 
            // textBox_perpetrator_name
            // 
            this.textBox_perpetrator_name.Location = new System.Drawing.Point(293, 13);
            this.textBox_perpetrator_name.Name = "textBox_perpetrator_name";
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
            this.perpetrator_picture_box.Location = new System.Drawing.Point(15, 13);
            this.perpetrator_picture_box.Name = "perpetrator_picture_box";
            this.perpetrator_picture_box.Size = new System.Drawing.Size(156, 156);
            this.perpetrator_picture_box.TabIndex = 0;
            this.perpetrator_picture_box.TabStop = false;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(0, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(545, 2);
            this.label12.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(-1, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(515, 2);
            this.label5.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(180, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(2, 190);
            this.label6.TabIndex = 35;
            // 
            // PerpetratorDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(543, 359);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "PerpetratorDetailsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Perpetrators Details";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PerpetratorDetailsForm_FormClosing);
            this.Load += new System.EventHandler(this.PerpetratorDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_picture_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MyPictureBox perpetrator_picture_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_is_a_student;
        private System.Windows.Forms.TextBox textBox_perpetrator_name;
        private MetroFramework.Controls.MetroButton button_save;
        private System.Windows.Forms.TextBox comboBox_is_active;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton button_getCrimes;
        private MetroFramework.Controls.MetroButton button_is_apprehended;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}