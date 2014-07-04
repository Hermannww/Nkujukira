namespace MetroFramework.Demo
{
    partial class SelectPerpetratorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.perpetrator_frame_picture_box = new System.Windows.Forms.PictureBox();
            this.done_button = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_frame_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select The Face of the Perpetrator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // perpetrator_frame_picture_box
            // 
            this.perpetrator_frame_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.perpetrator_frame_picture_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.perpetrator_frame_picture_box.Location = new System.Drawing.Point(23, 61);
            this.perpetrator_frame_picture_box.Name = "perpetrator_frame_picture_box";
            this.perpetrator_frame_picture_box.Size = new System.Drawing.Size(379, 281);
            this.perpetrator_frame_picture_box.TabIndex = 4;
            this.perpetrator_frame_picture_box.TabStop = false;
            this.perpetrator_frame_picture_box.Paint += new System.Windows.Forms.PaintEventHandler(this.perpetrator_frame_picture_box_Paint);
            this.perpetrator_frame_picture_box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseDown);
            this.perpetrator_frame_picture_box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseMove);
            this.perpetrator_frame_picture_box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseUp);
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(161, 362);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(103, 37);
            this.done_button.TabIndex = 20;
            this.done_button.Text = "Done!!";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.done_button_Click);
            // 
            // SelectPerpetratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(425, 410);
            this.Controls.Add(this.done_button);
            this.Controls.Add(this.perpetrator_frame_picture_box);
            this.Controls.Add(this.label1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPerpetratorForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "SelectPerpetrator";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_frame_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox perpetrator_frame_picture_box;
        private Controls.MetroButton done_button;

    }
}