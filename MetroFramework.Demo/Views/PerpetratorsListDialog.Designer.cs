using MetroFramework.Controls;
namespace Nkujukira.Demo.Views
{
    partial class PerpetratorsListDialog
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
            this.main_panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.AutoScroll = true;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_panel.Location = new System.Drawing.Point(10, 62);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(544, 607);
            this.main_panel.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(0, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(565, 2);
            this.label6.TabIndex = 36;
            // 
            // PerpetratorsListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(564, 677);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.main_panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerpetratorsListDialog";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Wanted DEAD or ALIVE";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.PerpetratorsListDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label label6;


        //private  role;
        
    }
}