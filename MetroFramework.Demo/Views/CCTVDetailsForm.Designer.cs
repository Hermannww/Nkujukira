using MetroFramework.Controls;
namespace MetroFramework.Demo.Views
{
    partial class CCTVDetailsForm
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
            this.textbox_camera_location = new System.Windows.Forms.TextBox();
            this.textbox_camera_name = new System.Windows.Forms.TextBox();
            this.label_video_file_name = new MetroFramework.Controls.MetroLabel();
            this.label_recording_since = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.turn_on_button = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textbox_camera_location);
            this.panel1.Controls.Add(this.textbox_camera_name);
            this.panel1.Controls.Add(this.label_video_file_name);
            this.panel1.Controls.Add(this.label_recording_since);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 256);
            this.panel1.TabIndex = 0;
            // 
            // textbox_camera_location
            // 
            this.textbox_camera_location.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_camera_location.Location = new System.Drawing.Point(237, 83);
            this.textbox_camera_location.Name = "textbox_camera_location";
            this.textbox_camera_location.Size = new System.Drawing.Size(253, 27);
            this.textbox_camera_location.TabIndex = 9;
            // 
            // textbox_camera_name
            // 
            this.textbox_camera_name.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_camera_name.Location = new System.Drawing.Point(237, 24);
            this.textbox_camera_name.Name = "textbox_camera_name";
            this.textbox_camera_name.Size = new System.Drawing.Size(253, 27);
            this.textbox_camera_name.TabIndex = 8;
            // 
            // label_video_file_name
            // 
            this.label_video_file_name.AutoSize = true;
            this.label_video_file_name.Location = new System.Drawing.Point(237, 202);
            this.label_video_file_name.Name = "label_video_file_name";
            this.label_video_file_name.Size = new System.Drawing.Size(72, 19);
            this.label_video_file_name.TabIndex = 7;
            this.label_video_file_name.Text = "CAMERA 1";
            this.label_video_file_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_recording_since
            // 
            this.label_recording_since.AutoSize = true;
            this.label_recording_since.Location = new System.Drawing.Point(237, 147);
            this.label_recording_since.Name = "label_recording_since";
            this.label_recording_since.Size = new System.Drawing.Size(61, 19);
            this.label_recording_since.TabIndex = 6;
            this.label_recording_since.Text = "8:00 A.M";
            this.label_recording_since.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(41, 202);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(116, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "VIDEO FILE NAME";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(41, 147);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(123, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "RECORDING SINCE";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(41, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "CAMERA LOCATION";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "CAMERA NAME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // turn_on_button
            // 
            this.turn_on_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turn_on_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turn_on_button.Location = new System.Drawing.Point(159, 338);
            this.turn_on_button.Name = "turn_on_button";
            this.turn_on_button.Size = new System.Drawing.Size(231, 44);
            this.turn_on_button.TabIndex = 34;
            this.turn_on_button.Text = "Save";
            this.turn_on_button.UseSelectable = true;
            // 
            // CCTVDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 400);
            this.Controls.Add(this.turn_on_button);
            this.Controls.Add(this.panel1);
            this.Name = "CCTVDetailsForm";
            this.Resizable = false;
            this.Text = "CCTV Display ";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroLabel label2;
        private MetroLabel metroLabel3;
        private MetroLabel metroLabel2;
        private MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox textbox_camera_location;
        private System.Windows.Forms.TextBox textbox_camera_name;
        private MetroLabel label_video_file_name;
        private MetroLabel label_recording_since;
        private MetroButton turn_on_button;
    }
}