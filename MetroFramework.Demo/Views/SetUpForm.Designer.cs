using MetroFramework;
using MetroFramework.Controls;
namespace Nkujukira.Demo.Views
{
    partial class SetUpForm
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
            this.phone_textbox = new System.Windows.Forms.TextBox();
            this.email_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.user_login = new MetroFramework.Controls.MetroButton();
            this.txtbox_saveImagesPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_confirmedPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_password = new System.Windows.Forms.TextBox();
            this.txtbox_username = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.phone_textbox);
            this.panel1.Controls.Add(this.email_textbox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.user_login);
            this.panel1.Controls.Add(this.txtbox_saveImagesPath);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtbox_confirmedPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtbox_password);
            this.panel1.Controls.Add(this.txtbox_username);
            this.panel1.Location = new System.Drawing.Point(23, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 393);
            this.panel1.TabIndex = 0;
            // 
            // phone_textbox
            // 
            this.phone_textbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_textbox.Location = new System.Drawing.Point(224, 99);
            this.phone_textbox.Name = "phone_textbox";
            this.phone_textbox.Size = new System.Drawing.Size(161, 27);
            this.phone_textbox.TabIndex = 23;
            // 
            // email_textbox
            // 
            this.email_textbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_textbox.Location = new System.Drawing.Point(224, 61);
            this.email_textbox.Name = "email_textbox";
            this.email_textbox.Size = new System.Drawing.Size(161, 27);
            this.email_textbox.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(67, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "Enter a Phone Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(67, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Enter your email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(93, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(18, 357);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 10);
            this.progressBar.Style = MetroFramework.MetroColorStyle.Red;
            this.progressBar.TabIndex = 18;
            this.progressBar.Visible = false;
            // 
            // user_login
            // 
            this.user_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.user_login.Location = new System.Drawing.Point(149, 289);
            this.user_login.Name = "user_login";
            this.user_login.Size = new System.Drawing.Size(161, 32);
            this.user_login.TabIndex = 17;
            this.user_login.Text = "Nkujukira!!!";
            this.user_login.UseSelectable = true;
            this.user_login.Click += new System.EventHandler(this.user_login_Click);
            // 
            // txtbox_saveImagesPath
            // 
            this.txtbox_saveImagesPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_saveImagesPath.Location = new System.Drawing.Point(224, 225);
            this.txtbox_saveImagesPath.Name = "txtbox_saveImagesPath";
            this.txtbox_saveImagesPath.Size = new System.Drawing.Size(161, 27);
            this.txtbox_saveImagesPath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(64, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Save Images Here";
            // 
            // txtbox_confirmedPassword
            // 
            this.txtbox_confirmedPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_confirmedPassword.Location = new System.Drawing.Point(224, 177);
            this.txtbox_confirmedPassword.Name = "txtbox_confirmedPassword";
            this.txtbox_confirmedPassword.Size = new System.Drawing.Size(161, 27);
            this.txtbox_confirmedPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(66, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(67, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter a Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(67, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter a Username";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_password.Location = new System.Drawing.Point(224, 136);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.Size = new System.Drawing.Size(161, 27);
            this.txtbox_password.TabIndex = 1;
            // 
            // txtbox_username
            // 
            this.txtbox_username.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_username.Location = new System.Drawing.Point(224, 17);
            this.txtbox_username.Name = "txtbox_username";
            this.txtbox_username.Size = new System.Drawing.Size(161, 27);
            this.txtbox_username.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SetUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 487);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SetUpForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Set Up Options";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SetUpForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtbox_confirmedPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_password;
        private System.Windows.Forms.TextBox txtbox_username;
        private System.Windows.Forms.TextBox txtbox_saveImagesPath;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton user_login;
        private MetroProgressBar progressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox phone_textbox;
        private System.Windows.Forms.TextBox email_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}