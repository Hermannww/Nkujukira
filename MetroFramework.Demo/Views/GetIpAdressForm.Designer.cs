namespace Nkujukira.Demo.Views
{
    partial class GetIpAdressForm
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
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maskedTextBox2);
            this.panel1.Location = new System.Drawing.Point(10, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 117);
            this.panel1.TabIndex = 0;
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(191, 61);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(88, 41);
            this.done_button.TabIndex = 29;
            this.done_button.Text = "Done";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.done_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter Ip Address";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox2.Location = new System.Drawing.Point(161, 28);
            this.maskedTextBox2.Mask = "http://000.000.00.0:0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(174, 27);
            this.maskedTextBox2.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(0, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(385, 2);
            this.label12.TabIndex = 31;
            // 
            // GetIpAdressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(382, 190);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.Name = "GetIpAdressForm";
            this.Resizable = false;
            this.Text = "Ip Address";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private MetroFramework.Controls.MetroButton done_button;
        private System.Windows.Forms.Label label12;


    }
}