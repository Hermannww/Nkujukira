using System;
namespace MetroFramework.Demo
{
    partial class LoginForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status_label = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spining_progress_indicator = new ProgressControls.ProgressIndicator();
            this.button_login = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(-254, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.status_label);
            this.panel1.Controls.Add(this.textbox_password);
            this.panel1.Controls.Add(this.textbox_username);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 126);
            this.panel1.TabIndex = 20;
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_label.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.status_label.Location = new System.Drawing.Point(84, -1);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(336, 24);
            this.status_label.TabIndex = 27;
            this.status_label.Text = "Welcome. Please Enter Your Credentials Here";
            this.status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Location = new System.Drawing.Point(457, 23);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(30, 32);
            this.metroButton1.TabIndex = 26;
            this.metroButton1.Text = ">>";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.SetUpButton_Click);
            // 
            // textbox_password
            // 
            this.textbox_password.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textbox_password.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password.Location = new System.Drawing.Point(173, 80);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(247, 30);
            this.textbox_password.TabIndex = 23;
            // 
            // textbox_username
            // 
            this.textbox_username.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textbox_username.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_username.Location = new System.Drawing.Point(173, 39);
            this.textbox_username.Multiline = true;
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(247, 27);
            this.textbox_username.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(86, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(86, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Username";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.spining_progress_indicator);
            this.panel2.Controls.Add(this.metroButton1);
            this.panel2.Controls.Add(this.button_login);
            this.panel2.Location = new System.Drawing.Point(23, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 71);
            this.panel2.TabIndex = 21;
            // 
            // spining_progress_indicator
            // 
            this.spining_progress_indicator.BackColor = System.Drawing.Color.Transparent;
            this.spining_progress_indicator.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.spining_progress_indicator.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spining_progress_indicator.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.spining_progress_indicator.Location = new System.Drawing.Point(360, 5);
            this.spining_progress_indicator.Name = "spining_progress_indicator";
            this.spining_progress_indicator.Percentage = 0F;
            this.spining_progress_indicator.ShowText = true;
            this.spining_progress_indicator.Size = new System.Drawing.Size(60, 60);
            this.spining_progress_indicator.TabIndex = 22;
            this.spining_progress_indicator.Text = "Please Wait..";
            this.spining_progress_indicator.TextDisplay = ProgressControls.TextDisplayModes.Text;
            // 
            // user_login
            // 
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.Location = new System.Drawing.Point(173, 13);
            this.button_login.Name = "user_login";
            this.button_login.Size = new System.Drawing.Size(150, 42);
            this.button_login.TabIndex = 25;
            this.button_login.Text = "Login";
            this.button_login.UseSelectable = true;
            this.button_login.Click += new System.EventHandler(this.user_login_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(549, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.Text = "Login";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private Controls.MetroButton metroButton1;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Controls.MetroButton button_login;
        private System.Windows.Forms.Label status_label;
        private ProgressControls.ProgressIndicator spining_progress_indicator;
    }
}