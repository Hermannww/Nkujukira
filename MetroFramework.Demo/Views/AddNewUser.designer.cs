namespace MetroFramework.Demo
{
    partial class AddNewUser
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(103, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(105, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "PassWord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(54, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm PassWord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(137, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
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
            this.pass_word.Location = new System.Drawing.Point(181, 129);
            this.pass_word.Name = "pass_word";
            this.pass_word.PasswordChar = '*';
            this.pass_word.Size = new System.Drawing.Size(211, 26);
            this.pass_word.TabIndex = 5;
            // 
            // confirm_password
            // 
            this.confirm_password.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_password.Location = new System.Drawing.Point(180, 162);
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
            this.role.Location = new System.Drawing.Point(180, 92);
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
            this.changeloginCredentials.Location = new System.Drawing.Point(222, 194);
            this.changeloginCredentials.Name = "changeloginCredentials";
            this.changeloginCredentials.Size = new System.Drawing.Size(132, 32);
            this.changeloginCredentials.TabIndex = 19;
            this.changeloginCredentials.Text = "Create";
            this.changeloginCredentials.UseSelectable = true;
            this.changeloginCredentials.Click += new System.EventHandler(this.changeloginCredentials_Click);
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 262);
            this.Controls.Add(this.changeloginCredentials);
            this.Controls.Add(this.role);
            this.Controls.Add(this.confirm_password);
            this.Controls.Add(this.pass_word);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewUser";
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
        private Controls.MetroComboBox role;
        private Controls.MetroButton changeloginCredentials;
    }
}