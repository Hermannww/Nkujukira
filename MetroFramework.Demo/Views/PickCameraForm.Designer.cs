namespace Nkujukira.Demo.Views
{
    partial class PickCameraForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.ok_button = new MetroFramework.Controls.MetroButton();
            this.ComboBoxCameraList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ok_button);
            this.panel1.Controls.Add(this.ComboBoxCameraList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 123);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(0, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(477, 1);
            this.label7.TabIndex = 37;
            // 
            // ok_button
            // 
            this.ok_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ok_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_button.Location = new System.Drawing.Point(132, 66);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(177, 44);
            this.ok_button.TabIndex = 32;
            this.ok_button.Text = "OK";
            this.ok_button.UseSelectable = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // ComboBoxCameraList
            // 
            this.ComboBoxCameraList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxCameraList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCameraList.FormattingEnabled = true;
            this.ComboBoxCameraList.Location = new System.Drawing.Point(93, 14);
            this.ComboBoxCameraList.Name = "ComboBoxCameraList";
            this.ComboBoxCameraList.Size = new System.Drawing.Size(309, 21);
            this.ComboBoxCameraList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Camera Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(-32, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 1);
            this.label1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(-23, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(477, 2);
            this.label3.TabIndex = 39;
            // 
            // PickCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(429, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickCameraForm";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Pick a Camera From The List";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.PickCameraForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboBoxCameraList;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton ok_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}