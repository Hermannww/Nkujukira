using System;
namespace MetroFramework.Demo
{
    partial class Login
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

        private void TestSplashScreen_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                m_dt = DateTime.Now;
                this.Activate();
                SplashScreen.CloseForm();
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.user_name = new System.Windows.Forms.TextBox();
            this.pass_word = new System.Windows.Forms.TextBox();
            this.user_login = new MetroFramework.Controls.MetroButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(102, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(102, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "PassWord";
            // 
            // user_name
            // 
            this.user_name.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.user_name.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.Location = new System.Drawing.Point(189, 85);
            this.user_name.Multiline = true;
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(192, 27);
            this.user_name.TabIndex = 2;
            this.user_name.TextChanged += new System.EventHandler(this.user_name_TextChanged);
            // 
            // pass_word
            // 
            this.pass_word.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pass_word.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_word.Location = new System.Drawing.Point(189, 126);
            this.pass_word.Name = "pass_word";
            this.pass_word.PasswordChar = '*';
            this.pass_word.Size = new System.Drawing.Size(192, 30);
            this.pass_word.TabIndex = 3;
            // 
            // user_login
            // 
            this.user_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.user_login.Location = new System.Drawing.Point(241, 173);
            this.user_login.Name = "user_login";
            this.user_login.Size = new System.Drawing.Size(67, 32);
            this.user_login.TabIndex = 16;
            this.user_login.Text = "Login";
            this.user_login.UseSelectable = true;
            this.user_login.Click += new System.EventHandler(this.user_login_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 199);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(179, 235);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(202, 12);
            this.progressBar.Style = MetroFramework.MetroColorStyle.Red;
            this.progressBar.TabIndex = 17;
            this.progressBar.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(186, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 18;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 293);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.user_login);
            this.Controls.Add(this.pass_word);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.Text = "Login";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Login_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.TestSplashScreen_Layout);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.TextBox pass_word;
        private Controls.MetroButton user_login;
        private Controls.MetroProgressBar progressBar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}