namespace MetroFramework.Demo.Views
{
    partial class CrimeDetailsForm
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
            this.textfield_crime_location = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_crimeCommited = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_getVictims = new MetroFramework.Controls.MetroButton();
            this.button_save = new MetroFramework.Controls.MetroButton();
            this.textfield_details_of_crime = new System.Windows.Forms.RichTextBox();
            this.comboBox_type_of_crime = new System.Windows.Forms.ComboBox();
            this.comboBox_minutes = new System.Windows.Forms.ComboBox();
            this.comboBox_hours = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_dateOfCrime = new System.Windows.Forms.DateTimePicker();
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
            this.panel1.Controls.Add(this.textfield_crime_location);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox_crimeCommited);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_getVictims);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.textfield_details_of_crime);
            this.panel1.Controls.Add(this.comboBox_type_of_crime);
            this.panel1.Controls.Add(this.comboBox_minutes);
            this.panel1.Controls.Add(this.comboBox_hours);
            this.panel1.Controls.Add(this.dateTimePicker_dateOfCrime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 419);
            this.panel1.TabIndex = 0;
            // 
            // textfield_crime_location
            // 
            this.textfield_crime_location.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textfield_crime_location.Location = new System.Drawing.Point(174, 192);
            this.textfield_crime_location.Name = "textfield_crime_location";
            this.textfield_crime_location.Size = new System.Drawing.Size(344, 27);
            this.textfield_crime_location.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(24, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 19);
            this.label7.TabIndex = 46;
            this.label7.Text = "Location of Crime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(234, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 19);
            this.label6.TabIndex = 45;
            this.label6.Text = ":";
            // 
            // comboBox_crimeCommited
            // 
            this.comboBox_crimeCommited.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_crimeCommited.Enabled = false;
            this.comboBox_crimeCommited.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_crimeCommited.FormattingEnabled = true;
            this.comboBox_crimeCommited.Location = new System.Drawing.Point(174, 140);
            this.comboBox_crimeCommited.Name = "comboBox_crimeCommited";
            this.comboBox_crimeCommited.Size = new System.Drawing.Size(344, 27);
            this.comboBox_crimeCommited.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(24, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Crime Commited";
            // 
            // button_getVictims
            // 
            this.button_getVictims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_getVictims.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_getVictims.Location = new System.Drawing.Point(366, 370);
            this.button_getVictims.Name = "button_getVictims";
            this.button_getVictims.Size = new System.Drawing.Size(152, 37);
            this.button_getVictims.TabIndex = 42;
            this.button_getVictims.Text = "Get Victims";
            this.button_getVictims.UseSelectable = true;
            this.button_getVictims.Click += new System.EventHandler(this.button_getVictims_Click);
            // 
            // button_save
            // 
            this.button_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.Location = new System.Drawing.Point(174, 370);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(150, 37);
            this.button_save.TabIndex = 41;
            this.button_save.Text = "Save";
            this.button_save.UseSelectable = true;
            this.button_save.Click += new System.EventHandler(this.save_button_Click);
            // 
            // textfield_details_of_crime
            // 
            this.textfield_details_of_crime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textfield_details_of_crime.Location = new System.Drawing.Point(174, 240);
            this.textfield_details_of_crime.Name = "textfield_details_of_crime";
            this.textfield_details_of_crime.Size = new System.Drawing.Size(344, 115);
            this.textfield_details_of_crime.TabIndex = 8;
            this.textfield_details_of_crime.Text = "";
            // 
            // comboBox_type_of_crime
            // 
            this.comboBox_type_of_crime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type_of_crime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_type_of_crime.FormattingEnabled = true;
            this.comboBox_type_of_crime.Items.AddRange(new object[] {
            "Crime againist Person",
            "Crime againist Property",
            "Crime againist Morality",
            "White-collar crime"});
            this.comboBox_type_of_crime.Location = new System.Drawing.Point(174, 98);
            this.comboBox_type_of_crime.Name = "comboBox_type_of_crime";
            this.comboBox_type_of_crime.Size = new System.Drawing.Size(344, 27);
            this.comboBox_type_of_crime.TabIndex = 7;
            this.comboBox_type_of_crime.SelectedIndexChanged += new System.EventHandler(this.type_of_crime_comboBox_SelectedIndexChanged);
            // 
            // comboBox_minutes
            // 
            this.comboBox_minutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_minutes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_minutes.FormattingEnabled = true;
            this.comboBox_minutes.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.comboBox_minutes.Location = new System.Drawing.Point(258, 60);
            this.comboBox_minutes.Name = "comboBox_minutes";
            this.comboBox_minutes.Size = new System.Drawing.Size(66, 27);
            this.comboBox_minutes.TabIndex = 6;
            // 
            // comboBox_hours
            // 
            this.comboBox_hours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hours.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_hours.FormattingEnabled = true;
            this.comboBox_hours.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            "24"});
            this.comboBox_hours.Location = new System.Drawing.Point(174, 60);
            this.comboBox_hours.Name = "comboBox_hours";
            this.comboBox_hours.Size = new System.Drawing.Size(54, 27);
            this.comboBox_hours.TabIndex = 5;
            // 
            // dateTimePicker_dateOfCrime
            // 
            this.dateTimePicker_dateOfCrime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_dateOfCrime.Location = new System.Drawing.Point(174, 25);
            this.dateTimePicker_dateOfCrime.Name = "dateTimePicker_dateOfCrime";
            this.dateTimePicker_dateOfCrime.Size = new System.Drawing.Size(344, 27);
            this.dateTimePicker_dateOfCrime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(23, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Details Of The Crime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(24, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type Of Crime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time (Around)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Of Crime";
            // 
            // CrimeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(555, 494);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrimeDetailsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Crime Details Form";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrimeDetailsForm_FormClosing);
            this.Load += new System.EventHandler(this.CrimeDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox textfield_details_of_crime;
        private System.Windows.Forms.ComboBox comboBox_type_of_crime;
        private System.Windows.Forms.ComboBox comboBox_minutes;
        private System.Windows.Forms.ComboBox comboBox_hours;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateOfCrime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.MetroButton button_save;
        private Controls.MetroButton button_getVictims;
        private System.Windows.Forms.ComboBox comboBox_crimeCommited;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textfield_crime_location;
        private System.Windows.Forms.Label label7;
    }
}