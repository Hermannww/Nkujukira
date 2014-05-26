namespace MetroFramework.Demo.Views
{
    partial class VictimsDetailsForm
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.date_of_birth = new System.Windows.Forms.DateTimePicker();
            this.is_a_student_comboBox = new System.Windows.Forms.ComboBox();
            this.gender_comoboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.items_lost_textbox = new System.Windows.Forms.TextBox();
            this.name_text_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.date_of_birth);
            this.panel1.Controls.Add(this.is_a_student_comboBox);
            this.panel1.Controls.Add(this.gender_comoboBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.items_lost_textbox);
            this.panel1.Controls.Add(this.name_text_box);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(9, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 386);
            this.panel1.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(373, 311);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(163, 37);
            this.metroButton1.TabIndex = 41;
            this.metroButton1.Text = "Cancel";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(151, 311);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(178, 37);
            this.done_button.TabIndex = 40;
            this.done_button.Text = "Save";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // date_of_birth
            // 
            this.date_of_birth.Location = new System.Drawing.Point(151, 107);
            this.date_of_birth.Name = "date_of_birth";
            this.date_of_birth.Size = new System.Drawing.Size(385, 20);
            this.date_of_birth.TabIndex = 39;
            // 
            // is_a_student_comboBox
            // 
            this.is_a_student_comboBox.FormattingEnabled = true;
            this.is_a_student_comboBox.Location = new System.Drawing.Point(151, 208);
            this.is_a_student_comboBox.Name = "is_a_student_comboBox";
            this.is_a_student_comboBox.Size = new System.Drawing.Size(100, 21);
            this.is_a_student_comboBox.TabIndex = 37;
            // 
            // gender_comoboBox
            // 
            this.gender_comoboBox.FormattingEnabled = true;
            this.gender_comoboBox.Location = new System.Drawing.Point(151, 155);
            this.gender_comoboBox.Name = "gender_comoboBox";
            this.gender_comoboBox.Size = new System.Drawing.Size(100, 21);
            this.gender_comoboBox.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(32, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.TabIndex = 35;
            this.label12.Text = "Gender";
            // 
            // items_lost_textbox
            // 
            this.items_lost_textbox.Location = new System.Drawing.Point(151, 256);
            this.items_lost_textbox.Name = "items_lost_textbox";
            this.items_lost_textbox.Size = new System.Drawing.Size(385, 20);
            this.items_lost_textbox.TabIndex = 34;
            // 
            // name_text_box
            // 
            this.name_text_box.Location = new System.Drawing.Point(151, 57);
            this.name_text_box.Name = "name_text_box";
            this.name_text_box.Size = new System.Drawing.Size(385, 20);
            this.name_text_box.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(32, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 19);
            this.label10.TabIndex = 31;
            this.label10.Text = "Items Lost ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(32, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 19);
            this.label9.TabIndex = 30;
            this.label9.Text = "Is A Student";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(32, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "Date of Birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(32, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "Name";
            // 
            // VictimsDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 492);
            this.Controls.Add(this.panel1);
            this.Name = "VictimsDetailsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Victims Details";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.VictimsDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker date_of_birth;
        private System.Windows.Forms.ComboBox is_a_student_comboBox;
        private System.Windows.Forms.ComboBox gender_comoboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox items_lost_textbox;
        private System.Windows.Forms.TextBox name_text_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Controls.MetroButton done_button;
        private Controls.MetroButton metroButton1;
    }
}