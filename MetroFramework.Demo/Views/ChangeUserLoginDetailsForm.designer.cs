namespace Nkujukira.Demo
{
    partial class ChangeUserLoginDetailsForm
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
            this.old_user_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.old_password = new System.Windows.Forms.TextBox();
            this.new_user_name = new System.Windows.Forms.TextBox();
            this.new_pass_word = new System.Windows.Forms.TextBox();
            this.confirm_new_pass_word = new System.Windows.Forms.TextBox();
            this.changeloginCredentials = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // old_user_name
            // 
            this.old_user_name.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.old_user_name.Location = new System.Drawing.Point(185, 81);
            this.old_user_name.Name = "old_user_name";
            this.old_user_name.Size = new System.Drawing.Size(211, 26);
            this.old_user_name.TabIndex = 0;
            this.old_user_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(86, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(97, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PassWord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(57, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "New UserName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(63, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "New PassWord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(4, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Confirm New PassWord";
            // 
            // old_password
            // 
            this.old_password.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.old_password.Location = new System.Drawing.Point(185, 120);
            this.old_password.Name = "old_password";
            this.old_password.PasswordChar = '*';
            this.old_password.Size = new System.Drawing.Size(211, 26);
            this.old_password.TabIndex = 6;
            this.old_password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // new_user_name
            // 
            this.new_user_name.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_user_name.Location = new System.Drawing.Point(185, 162);
            this.new_user_name.Name = "new_user_name";
            this.new_user_name.Size = new System.Drawing.Size(211, 26);
            this.new_user_name.TabIndex = 7;
            // 
            // new_pass_word
            // 
            this.new_pass_word.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_pass_word.Location = new System.Drawing.Point(185, 195);
            this.new_pass_word.Name = "new_pass_word";
            this.new_pass_word.PasswordChar = '*';
            this.new_pass_word.Size = new System.Drawing.Size(211, 26);
            this.new_pass_word.TabIndex = 8;
            // 
            // confirm_new_pass_word
            // 
            this.confirm_new_pass_word.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_new_pass_word.Location = new System.Drawing.Point(185, 233);
            this.confirm_new_pass_word.Name = "confirm_new_pass_word";
            this.confirm_new_pass_word.PasswordChar = '*';
            this.confirm_new_pass_word.Size = new System.Drawing.Size(211, 26);
            this.confirm_new_pass_word.TabIndex = 9;
            // 
            // changeloginCredentials
            // 
            this.changeloginCredentials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeloginCredentials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeloginCredentials.Location = new System.Drawing.Point(220, 271);
            this.changeloginCredentials.Name = "changeloginCredentials";
            this.changeloginCredentials.Size = new System.Drawing.Size(123, 32);
            this.changeloginCredentials.TabIndex = 18;
            this.changeloginCredentials.Text = "Change";
            this.changeloginCredentials.UseSelectable = true;
            this.changeloginCredentials.Click += new System.EventHandler(this.changeloginCredentials_Click);
            // 
            // ChangeUserLoginDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 326);
            this.Controls.Add(this.changeloginCredentials);
            this.Controls.Add(this.confirm_new_pass_word);
            this.Controls.Add(this.new_pass_word);
            this.Controls.Add(this.new_user_name);
            this.Controls.Add(this.old_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.old_user_name);
            this.Name = "ChangeUserLoginDetails";
            this.Text = "Change Login Details";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ChangeUserLoginDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox old_user_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox old_password;
        private System.Windows.Forms.TextBox new_user_name;
        private System.Windows.Forms.TextBox new_pass_word;
        private System.Windows.Forms.TextBox confirm_new_pass_word;
        private MetroFramework.Controls.MetroButton changeloginCredentials;
    }
}