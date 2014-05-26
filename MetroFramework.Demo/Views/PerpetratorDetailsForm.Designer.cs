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
            this.is_active_combo_box = new System.Windows.Forms.TextBox();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.is_a_student_combo_box = new System.Windows.Forms.ComboBox();
            this.perpetrator_name_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.perpetrator_picture_box = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.is_active_combo_box);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.is_a_student_combo_box);
            this.panel1.Controls.Add(this.perpetrator_name_textbox);
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
            // is_active_combo_box
            // 
            this.is_active_combo_box.Location = new System.Drawing.Point(298, 132);
            this.is_active_combo_box.Name = "is_active_combo_box";
            this.is_active_combo_box.Size = new System.Drawing.Size(208, 27);
            this.is_active_combo_box.TabIndex = 29;
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(157, 202);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(204, 48);
            this.done_button.TabIndex = 27;
            this.done_button.Text = "Save";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // is_a_student_combo_box
            // 
            this.is_a_student_combo_box.FormattingEnabled = true;
            this.is_a_student_combo_box.Location = new System.Drawing.Point(298, 84);
            this.is_a_student_combo_box.Name = "is_a_student_combo_box";
            this.is_a_student_combo_box.Size = new System.Drawing.Size(208, 27);
            this.is_a_student_combo_box.TabIndex = 12;
            // 
            // perpetrator_name_textbox
            // 
            this.perpetrator_name_textbox.Location = new System.Drawing.Point(298, 29);
            this.perpetrator_name_textbox.Name = "perpetrator_name_textbox";
            this.perpetrator_name_textbox.Size = new System.Drawing.Size(208, 27);
            this.perpetrator_name_textbox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(191, 139);
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
            this.label2.Location = new System.Drawing.Point(191, 84);
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
            this.label1.Location = new System.Drawing.Point(191, 29);
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
            // PerpetratorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 359);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "PerpetratorDetails";
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
        private System.Windows.Forms.ComboBox is_a_student_combo_box;
        private System.Windows.Forms.TextBox perpetrator_name_textbox;
        private Controls.MetroButton done_button;
        private System.Windows.Forms.TextBox is_active_combo_box;
    }
}