namespace MetroFramework.Demo.Views
{
    partial class CCTVDisplayForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.image_box = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.image_box);
            this.panel1.Location = new System.Drawing.Point(13, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 375);
            this.panel1.TabIndex = 0;
            // 
            // image_box
            // 
            this.image_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_box.Location = new System.Drawing.Point(14, 12);
            this.image_box.Name = "image_box";
            this.image_box.Size = new System.Drawing.Size(344, 344);
            this.image_box.TabIndex = 29;
            this.image_box.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(-1, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 2);
            this.label1.TabIndex = 30;
            // 
            // CCTVDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "CCTVDisplayForm";
            this.Resizable = false;
            this.Text = "CCTV Display ";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.ImageBox image_box;
        private System.Windows.Forms.Label label1;
    }
}