using System.Windows.Forms;

namespace MetroFramework.Demo.Views
{
    partial class SplashScreen : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_separator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblStatus.Location = new System.Drawing.Point(12, 273);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(279, 14);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "LOADING. PLEASE WAIT...";
            this.lblStatus.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Location = new System.Drawing.Point(12, 230);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(567, 24);
            this.pnlStatus.TabIndex = 1;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatus_Paint);
            this.pnlStatus.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.Silver;
            this.lblTimeRemaining.Location = new System.Drawing.Point(9, 201);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(279, 16);
            this.lblTimeRemaining.TabIndex = 2;
            this.lblTimeRemaining.Text = "Time remaining";
            this.lblTimeRemaining.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Niagara Solid", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 68);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nkujukira";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(-252, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 29;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // label_separator
            // 
            this.label_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_separator.Location = new System.Drawing.Point(12, 217);
            this.label_separator.Name = "label_separator";
            this.label_separator.Size = new System.Drawing.Size(150, 1);
            this.label_separator.TabIndex = 30;
            // 
            // SplashScreen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(591, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_separator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Panel pnlStatus;
        private Label label1;
        private Label label3;
        private Timer timer1;
        private Label label_separator;
    }
}