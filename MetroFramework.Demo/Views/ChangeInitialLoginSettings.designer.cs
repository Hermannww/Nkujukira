namespace MetroFramework.Demo
{
    partial class ChangeInitialLoginSettings
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
            this.confirmNewPassWord = new System.Windows.Forms.Label();
            this.newPassWord = new System.Windows.Forms.Label();
            this.newUserName = new System.Windows.Forms.Label();
            this.new_UserName = new System.Windows.Forms.TextBox();
            this.new_PassWord = new System.Windows.Forms.TextBox();
            this.new_ConfirmPassWord = new System.Windows.Forms.TextBox();
            this.changeInitialCredentials = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // confirmNewPassWord
            // 
            this.confirmNewPassWord.AutoSize = true;
            this.confirmNewPassWord.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmNewPassWord.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.confirmNewPassWord.Location = new System.Drawing.Point(27, 174);
            this.confirmNewPassWord.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.confirmNewPassWord.Name = "confirmNewPassWord";
            this.confirmNewPassWord.Size = new System.Drawing.Size(165, 20);
            this.confirmNewPassWord.TabIndex = 3;
            this.confirmNewPassWord.Text = "Confirm New PassWord";
            // 
            // newPassWord
            // 
            this.newPassWord.AutoSize = true;
            this.newPassWord.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassWord.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.newPassWord.Location = new System.Drawing.Point(94, 122);
            this.newPassWord.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.newPassWord.Name = "newPassWord";
            this.newPassWord.Size = new System.Drawing.Size(106, 20);
            this.newPassWord.TabIndex = 4;
            this.newPassWord.Text = "New PassWord";
            // 
            // newUserName
            // 
            this.newUserName.AutoSize = true;
            this.newUserName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.newUserName.Location = new System.Drawing.Point(91, 75);
            this.newUserName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.newUserName.Name = "newUserName";
            this.newUserName.Size = new System.Drawing.Size(112, 20);
            this.newUserName.TabIndex = 5;
            this.newUserName.Text = "New UserName";
            this.newUserName.Click += new System.EventHandler(this.newUserName_Click);
            // 
            // new_UserName
            // 
            this.new_UserName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_UserName.Location = new System.Drawing.Point(213, 75);
            this.new_UserName.Margin = new System.Windows.Forms.Padding(5);
            this.new_UserName.Name = "new_UserName";
            this.new_UserName.Size = new System.Drawing.Size(192, 25);
            this.new_UserName.TabIndex = 6;
            // 
            // new_PassWord
            // 
            this.new_PassWord.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_PassWord.Location = new System.Drawing.Point(213, 119);
            this.new_PassWord.Margin = new System.Windows.Forms.Padding(5);
            this.new_PassWord.Name = "new_PassWord";
            this.new_PassWord.PasswordChar = '*';
            this.new_PassWord.Size = new System.Drawing.Size(192, 25);
            this.new_PassWord.TabIndex = 7;
            // 
            // new_ConfirmPassWord
            // 
            this.new_ConfirmPassWord.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_ConfirmPassWord.Location = new System.Drawing.Point(213, 171);
            this.new_ConfirmPassWord.Margin = new System.Windows.Forms.Padding(5);
            this.new_ConfirmPassWord.Name = "new_ConfirmPassWord";
            this.new_ConfirmPassWord.PasswordChar = '*';
            this.new_ConfirmPassWord.Size = new System.Drawing.Size(192, 25);
            this.new_ConfirmPassWord.TabIndex = 8;
            // 
            // changeInitialCredentials
            // 
            this.changeInitialCredentials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeInitialCredentials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeInitialCredentials.Location = new System.Drawing.Point(213, 220);
            this.changeInitialCredentials.Name = "changeInitialCredentials";
            this.changeInitialCredentials.Size = new System.Drawing.Size(192, 32);
            this.changeInitialCredentials.TabIndex = 17;
            this.changeInitialCredentials.Text = "Change";
            this.changeInitialCredentials.UseSelectable = true;
            this.changeInitialCredentials.Click += new System.EventHandler(this.changeInitialCredentials_Click);
            // 
            // ChangeInitialLoginSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 307);
            this.Controls.Add(this.changeInitialCredentials);
            this.Controls.Add(this.new_ConfirmPassWord);
            this.Controls.Add(this.new_PassWord);
            this.Controls.Add(this.new_UserName);
            this.Controls.Add(this.newUserName);
            this.Controls.Add(this.newPassWord);
            this.Controls.Add(this.confirmNewPassWord);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChangeInitialLoginSettings";
            this.Padding = new System.Windows.Forms.Padding(33, 92, 33, 31);
            this.Text = "Change Login Credentials";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ChangeInitialLoginSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label confirmNewPassWord;
        private System.Windows.Forms.Label newPassWord;
        private System.Windows.Forms.Label newUserName;
        private System.Windows.Forms.TextBox new_UserName;
        private System.Windows.Forms.TextBox new_PassWord;
        private System.Windows.Forms.TextBox new_ConfirmPassWord;
        private Controls.MetroButton changeInitialCredentials;
    }
}