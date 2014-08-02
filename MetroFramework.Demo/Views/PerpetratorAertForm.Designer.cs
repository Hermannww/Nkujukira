using Nkujukira.Demo.Custom_Controls;
namespace Nkujukira.Demo.Views
{
    partial class PerpetratorAertForm
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
            this.known_person_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.similarity_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_separator = new System.Windows.Forms.Label();
            this.vertical_separator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.known_person_pictureBox = new Nkujukira.Demo.Custom_Controls.MyPictureBox();
            this.unknown_person_pictureBox = new Nkujukira.Demo.Custom_Controls.MyPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.known_person_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unknown_person_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.vertical_separator);
            this.panel1.Controls.Add(this.known_person_label);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.similarity_label);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.known_person_pictureBox);
            this.panel1.Controls.Add(this.unknown_person_pictureBox);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(6, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 177);
            this.panel1.TabIndex = 0;
            // 
            // known_person_label
            // 
            this.known_person_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.known_person_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.known_person_label.Location = new System.Drawing.Point(305, 8);
            this.known_person_label.Name = "known_person_label";
            this.known_person_label.Size = new System.Drawing.Size(119, 19);
            this.known_person_label.TabIndex = 7;
            this.known_person_label.Text = "KNOWN PERSON";
            this.known_person_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(11, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "UNKNOWN PERSON";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(184, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Certainity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // similarity_label
            // 
            this.similarity_label.AutoSize = true;
            this.similarity_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.similarity_label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.similarity_label.Location = new System.Drawing.Point(202, 89);
            this.similarity_label.Name = "similarity_label";
            this.similarity_label.Size = new System.Drawing.Size(36, 19);
            this.similarity_label.TabIndex = 4;
            this.similarity_label.Text = "80%";
            this.similarity_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(202, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "With";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(170, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recognized as";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_separator
            // 
            this.label_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_separator.Location = new System.Drawing.Point(0, 55);
            this.label_separator.Name = "label_separator";
            this.label_separator.Size = new System.Drawing.Size(455, 2);
            this.label_separator.TabIndex = 30;
            // 
            // vertical_separator
            // 
            this.vertical_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vertical_separator.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.vertical_separator.Location = new System.Drawing.Point(275, 0);
            this.vertical_separator.Name = "vertical_separator";
            this.vertical_separator.Size = new System.Drawing.Size(1, 175);
            this.vertical_separator.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(165, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 175);
            this.label3.TabIndex = 9;
            // 
            // known_person_pictureBox
            // 
            this.known_person_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.known_person_pictureBox.Location = new System.Drawing.Point(304, 30);
            this.known_person_pictureBox.Name = "known_person_pictureBox";
            this.known_person_pictureBox.Size = new System.Drawing.Size(120, 120);
            this.known_person_pictureBox.TabIndex = 1;
            this.known_person_pictureBox.TabStop = false;
            this.known_person_pictureBox.Click += new System.EventHandler(this.known_person_pictureBox_Click);
            // 
            // unknown_person_pictureBox
            // 
            this.unknown_person_pictureBox.Location = new System.Drawing.Point(18, 30);
            this.unknown_person_pictureBox.Name = "unknown_person_pictureBox";
            this.unknown_person_pictureBox.Size = new System.Drawing.Size(120, 120);
            this.unknown_person_pictureBox.TabIndex = 0;
            this.unknown_person_pictureBox.TabStop = false;
            // 
            // PerpetratorAertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(455, 258);
            this.Controls.Add(this.label_separator);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerpetratorAertForm";
            this.Resizable = false;
            this.Text = "A Perpetrator Has Been Recognized";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PerpetratorAertForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.known_person_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unknown_person_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label known_person_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label similarity_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MyPictureBox known_person_pictureBox;
        private MyPictureBox unknown_person_pictureBox;
        private System.Windows.Forms.Label label_separator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vertical_separator;
    }
}