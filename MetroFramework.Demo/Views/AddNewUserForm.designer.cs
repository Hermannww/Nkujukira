using MetroFramework.Controls;
namespace Nkujukira.Demo
{
    partial class AddNewUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.user_name = new System.Windows.Forms.TextBox();
            this.pass_word = new System.Windows.Forms.TextBox();
            this.confirm_password = new System.Windows.Forms.TextBox();
            this.role = new MetroFramework.Controls.MetroComboBox();
            this.changeloginCredentials = new MetroFramework.Controls.MetroButton();
            this.email_textbox = new System.Windows.Forms.TextBox();
            this.phone_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(77, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(82, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(31, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(111, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Role";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // user_name
            // 
            this.user_name.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.Location = new System.Drawing.Point(181, 54);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(211, 26);
            this.user_name.TabIndex = 4;
            this.user_name.TextChanged += new System.EventHandler(this.user_name_TextChanged);
            // 
            // pass_word
            // 
            this.pass_word.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_word.Location = new System.Drawing.Point(181, 235);
            this.pass_word.Name = "pass_word";
            this.pass_word.PasswordChar = '*';
            this.pass_word.Size = new System.Drawing.Size(211, 26);
            this.pass_word.TabIndex = 5;
            // 
            // confirm_password
            // 
            this.confirm_password.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_password.Location = new System.Drawing.Point(181, 280);
            this.confirm_password.Name = "confirm_password";
            this.confirm_password.PasswordChar = '*';
            this.confirm_password.Size = new System.Drawing.Size(211, 26);
            this.confirm_password.TabIndex = 6;
            // 
            // role
            // 
            this.role.FormattingEnabled = true;
            this.role.ItemHeight = 23;
            this.role.Items.AddRange(new object[] {
            "Admin",
            "Normal User"});
            this.role.Location = new System.Drawing.Point(181, 194);
            this.role.Name = "role";
            this.role.PromptText = "Admin";
            this.role.Size = new System.Drawing.Size(212, 29);
            this.role.TabIndex = 7;
            this.role.UseSelectable = true;
            this.role.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // changeloginCredentials
            // 
            this.changeloginCredentials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeloginCredentials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeloginCredentials.Location = new System.Drawing.Point(216, 321);
            this.changeloginCredentials.Name = "changeloginCredentials";
            this.changeloginCredentials.Size = new System.Drawing.Size(132, 32);
            this.changeloginCredentials.TabIndex = 19;
            this.changeloginCredentials.Text = "Create";
            this.changeloginCredentials.UseSelectable = true;
            this.changeloginCredentials.Click += new System.EventHandler(this.changeloginCredentials_Click);
            // 
            // email_textbox
            // 
            this.email_textbox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_textbox.Location = new System.Drawing.Point(182, 97);
            this.email_textbox.Name = "email_textbox";
            this.email_textbox.Size = new System.Drawing.Size(211, 26);
            this.email_textbox.TabIndex = 20;
            // 
            // phone_textbox
            // 
            this.phone_textbox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_textbox.Location = new System.Drawing.Point(182, 149);
            this.phone_textbox.Name = "phone_textbox";
            this.phone_textbox.Size = new System.Drawing.Size(211, 26);
            this.phone_textbox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(103, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(52, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Phone Number";
            // 
            // AddNewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 362);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone_textbox);
            this.Controls.Add(this.email_textbox);
            this.Controls.Add(this.changeloginCredentials);
            this.Controls.Add(this.role);
            this.Controls.Add(this.confirm_password);
            this.Controls.Add(this.pass_word);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewUserForm";
            this.Text = "Add New User";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.AddNewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.TextBox pass_word;
        private System.Windows.Forms.TextBox confirm_password;
        private MetroComboBox role;
        private MetroFramework.Controls.MetroButton changeloginCredentials;
        private System.Windows.Forms.TextBox email_textbox;
        private System.Windows.Forms.TextBox phone_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}