namespace MetroFramework.Demo
{
    partial class ChangeUserTypeDialog
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
            this.changeUserRole = new MetroFramework.Controls.MetroButton();
            this.role = new MetroFramework.Controls.MetroComboBox();
            this.user_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeUserRole
            // 
            this.changeUserRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeUserRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeUserRole.Location = new System.Drawing.Point(198, 136);
            this.changeUserRole.Name = "changeUserRole";
            this.changeUserRole.Size = new System.Drawing.Size(211, 32);
            this.changeUserRole.TabIndex = 24;
            this.changeUserRole.Text = "Change";
            this.changeUserRole.UseSelectable = true;
            this.changeUserRole.Click += new System.EventHandler(this.changeUserRole_Click);
            // 
            // role
            // 
            this.role.FormattingEnabled = true;
            this.role.ItemHeight = 23;
            this.role.Items.AddRange(new object[] {
            "Admin",
            "Normal User"});
            this.role.Location = new System.Drawing.Point(198, 101);
            this.role.Name = "role";
            this.role.PromptText = "Admin";
            this.role.Size = new System.Drawing.Size(212, 29);
            this.role.TabIndex = 23;
            this.role.UseSelectable = true;
            // 
            // user_name
            // 
            this.user_name.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.Location = new System.Drawing.Point(199, 63);
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Size = new System.Drawing.Size(211, 26);
            this.user_name.TabIndex = 22;
            this.user_name.TextChanged += new System.EventHandler(this.user_name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(155, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Role";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(121, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "UserName";
            // 
            // ChangeUserTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 262);
            this.Controls.Add(this.changeUserRole);
            this.Controls.Add(this.role);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ChangeUserTypeDialog";
            this.Text = "Change User Role";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ChangeUserTypeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MetroButton changeUserRole;
        private Controls.MetroComboBox role;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}