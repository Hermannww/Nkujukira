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
            this.comboBox_crimeCommited = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.details_of_crime_textfield = new System.Windows.Forms.RichTextBox();
            this.type_of_crime_comboBox = new System.Windows.Forms.ComboBox();
            this.comboBox_minutes = new System.Windows.Forms.ComboBox();
            this.comboBox_hours = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox_crimeCommited);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.details_of_crime_textfield);
            this.panel1.Controls.Add(this.type_of_crime_comboBox);
            this.panel1.Controls.Add(this.comboBox_minutes);
            this.panel1.Controls.Add(this.comboBox_hours);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 394);
            this.panel1.TabIndex = 0;
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
            // metroButton1
            // 
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(366, 332);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(152, 37);
            this.metroButton1.TabIndex = 42;
            this.metroButton1.Text = "Cancel";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(174, 332);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(150, 37);
            this.done_button.TabIndex = 41;
            this.done_button.Text = "Save";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // details_of_crime_textfield
            // 
            this.details_of_crime_textfield.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details_of_crime_textfield.Location = new System.Drawing.Point(174, 196);
            this.details_of_crime_textfield.Name = "details_of_crime_textfield";
            this.details_of_crime_textfield.Size = new System.Drawing.Size(344, 115);
            this.details_of_crime_textfield.TabIndex = 8;
            this.details_of_crime_textfield.Text = "";
            this.details_of_crime_textfield.MouseDown += new System.Windows.Forms.MouseEventHandler(this.details_of_crime_textfield_MouseDown);
            // 
            // type_of_crime_comboBox
            // 
            this.type_of_crime_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_of_crime_comboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type_of_crime_comboBox.FormattingEnabled = true;
            this.type_of_crime_comboBox.Items.AddRange(new object[] {
            "Crime againist Person",
            "Crime againist Property",
            "Crime againist Morality",
            "White-collar crime"});
            this.type_of_crime_comboBox.Location = new System.Drawing.Point(174, 98);
            this.type_of_crime_comboBox.Name = "type_of_crime_comboBox";
            this.type_of_crime_comboBox.Size = new System.Drawing.Size(344, 27);
            this.type_of_crime_comboBox.TabIndex = 7;
            this.type_of_crime_comboBox.SelectedIndexChanged += new System.EventHandler(this.type_of_crime_comboBox_SelectedIndexChanged);
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(344, 27);
            this.dateTimePicker1.TabIndex = 4;
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
            // CrimeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 469);
            this.Controls.Add(this.panel1);
            this.Name = "CrimeDetailsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Crime Details Form";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.CrimeDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox details_of_crime_textfield;
        private System.Windows.Forms.ComboBox type_of_crime_comboBox;
        private System.Windows.Forms.ComboBox comboBox_minutes;
        private System.Windows.Forms.ComboBox comboBox_hours;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.MetroButton done_button;
        private Controls.MetroButton metroButton1;
        private System.Windows.Forms.ComboBox comboBox_crimeCommited;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}